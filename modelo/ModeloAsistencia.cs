using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace GUI_Login.modelo
{
    /// <summary>
    /// Modelo para gestionar las operaciones de base de datos relacionadas con asistencias
    /// </summary>
    public class ModeloAsistencia
    {
        private readonly Conexion conexion;

        /// <summary>
        /// Constructor que inicializa la conexión a la base de datos
        /// </summary>
        public ModeloAsistencia()
        {
            conexion = new Conexion();
        }

        // ==================== CONSULTAS DE ALUMNOS ====================

        /// <summary>
        /// Obtiene la lista de todos los alumnos para el control de asistencia
        /// </summary>
        /// <returns>Lista de objetos Alumno</returns>
        public List<Alumno> ListarAlumnos()
        {
            List<Alumno> alumnos = new List<Alumno>();

            try
            {
                using MySqlConnection conn = conexion.getConexion();
                conn.Open();
                string sql = "SELECT id, nombre, apellido FROM alumno ORDER BY apellido, nombre";
                using MySqlCommand cmd = new(sql, conn);
                using MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Alumno alumno = new()
                    {
                        Id = reader.GetInt32("id"),
                        Nombre = reader.GetString("nombre"),
                        Apellido = reader.GetString("apellido")
                    };
                    alumnos.Add(alumno);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener lista de alumnos: {ex.Message}");
            }

            return alumnos;
        }

        // ==================== OPERACIONES CRUD ====================

        /// <summary>
        /// Marca la asistencia de un alumno en una fecha específica
        /// </summary>
        /// <param name="asistencia">Objeto Asistencia con los datos a guardar</param>
        /// <returns>True si la operación fue exitosa</returns>
        public bool MarcarAsistencia(Asistencia asistencia)
        {
            if (asistencia == null)
            {
                throw new ArgumentNullException(nameof(asistencia), "Los datos de asistencia no pueden ser nulos.");
            }

            try
            {
                using MySqlConnection conn = conexion.getConexion();
                conn.Open();

                // Usar INSERT ON DUPLICATE KEY UPDATE para manejar actualizaciones
                string query = @"
                INSERT INTO asistencia (id_alumno, fecha, actividad_orquestal, presente)
                VALUES (@idAlumno, @fecha, @actividadOrquestal, @presente)
                ON DUPLICATE KEY UPDATE presente = @presente";

                using MySqlCommand cmd = new(query, conn);
                cmd.Parameters.AddWithValue("@idAlumno", asistencia.IdAlumno);
                cmd.Parameters.AddWithValue("@fecha", asistencia.Fecha);
                cmd.Parameters.AddWithValue("@actividadOrquestal", asistencia.TipoActividad.ToString());
                cmd.Parameters.AddWithValue("@presente", asistencia.Presente);

                int filasAfectadas = cmd.ExecuteNonQuery();
                return filasAfectadas > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al marcar asistencia: {ex.Message}");
            }
        }

        // ==================== CÁLCULOS Y ESTADÍSTICAS ====================

        /// <summary>
        /// Calcula el porcentaje de asistencia de un alumno
        /// </summary>
        /// <param name="idAlumno">ID del alumno</param>
        /// <returns>Porcentaje de asistencia redondeado a 2 decimales</returns>
        public double CalcularPorcentajeAsistencia(int idAlumno)
        {
            double porcentaje = 0;

            try
            {
                using MySqlConnection conn = conexion.getConexion();
                conn.Open();

                string sql = @"
                                SELECT 
                                    COALESCE(SUM(presente = 1), 0) AS cantidad_presentes,
                                    COALESCE(COUNT(*), 0) AS total
                                FROM asistencia
                                WHERE id_alumno = @idAlumno";
                using MySqlCommand cmd = new(sql, conn);
                cmd.Parameters.AddWithValue("@idAlumno", idAlumno);
                using MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    int presentes = reader.GetInt32("cantidad_presentes");
                    int total = reader.GetInt32("total");

                    if (total > 0)
                        porcentaje = (double)presentes / total * 100;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error calculando porcentaje de asistencia: {ex.Message}");
            }

            return Math.Round(porcentaje, 2);
        }

        // ==================== CONSULTAS PARA REPORTES ====================

        /// <summary>
        /// Obtiene una tabla completa con datos de alumnos, instrumentos, profesores y porcentajes de asistencia
        /// </summary>
        /// <returns>DataTable con todos los datos para el reporte de asistencias</returns>
        public DataTable ObtenerTablaAsistencia()
        {
            DataTable tabla = new DataTable();

            try
            {
                using (MySqlConnection conn = conexion.getConexion())
                {
                    conn.Open();

                    // Query optimizada para obtener datos consolidados
                    string sql = @"
                    SELECT 
                        a.id AS id_alumno,
                        a.nombre AS nombre_alumno,
                        a.apellido AS apellido_alumno,
                        GROUP_CONCAT(DISTINCT i.nombre ORDER BY i.nombre SEPARATOR '\n') AS instrumentos,
                        GROUP_CONCAT(DISTINCT CONCAT(p.nombre, ' ', p.apellido) ORDER BY p.apellido SEPARATOR '\n') AS profesores
                    FROM alumno a
                    LEFT JOIN alumno_instrumento ai ON a.id = ai.id_alumno
                    LEFT JOIN instrumento_orquesta io ON ai.id_instrumento = io.id
                    LEFT JOIN instrumento i ON io.id = i.id
                    LEFT JOIN profesor p ON io.id = p.id_instrumento
                    GROUP BY a.id, a.nombre, a.apellido
                    ORDER BY a.apellido, a.nombre";

                    using MySqlCommand cmd = new(sql, conn);
                    using MySqlDataAdapter adapter = new(cmd);
                    adapter.Fill(tabla);
                }

                // Agregar columna de porcentaje y calcular para cada alumno
                tabla.Columns.Add("porcentaje_asistencia", typeof(double));

                foreach (DataRow fila in tabla.Rows)
                {
                    try
                    {
                        int idAlumno = Convert.ToInt32(fila["id_alumno"]);
                        fila["porcentaje_asistencia"] = CalcularPorcentajeAsistencia(idAlumno);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"Error calculando porcentaje para alumno ID {fila["id_alumno"]}: {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener tabla de asistencias: {ex.Message}");
            }

            return tabla;
        }
    }
}