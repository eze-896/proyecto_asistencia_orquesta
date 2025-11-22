using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace GUI_Login.modelo
{
    public class ModeloAsistencia
    {
        private readonly Conexion conexion;

        public ModeloAsistencia()
        {
            conexion = new Conexion();
        }

        // ==================== CONSULTAS DE ALUMNOS ====================

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
                // CORREGIDO: Lanzar excepción en lugar de MessageBox
                throw new Exception($"Error al obtener lista de alumnos: {ex.Message}");
            }

            return alumnos;
        }

        // ==================== OPERACIONES CRUD ====================

        public bool MarcarAsistencia(Asistencia asistencia)
        {
            if (asistencia == null)
            {
                // CORREGIDO: Lanzar excepción en lugar de MessageBox
                throw new ArgumentNullException(nameof(asistencia), "Los datos de asistencia no pueden ser nulos.");
            }

            try
            {
                using MySqlConnection conn = conexion.getConexion();
                conn.Open();

                // CORREGIDO: Usar INSERT ON DUPLICATE KEY UPDATE para simplificar
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
                // CORREGIDO: Lanzar excepción en lugar de MessageBox
                throw new Exception($"Error al marcar asistencia: {ex.Message}");
            }
        }

        // ==================== CÁLCULOS Y ESTADÍSTICAS ====================

        public double CalcularPorcentajeAsistencia(int idAlumno)
        {
            double porcentaje = 0;

            try
            {
                using MySqlConnection conn = conexion.getConexion();
                conn.Open();

                string sql = @"
                SELECT 
                    SUM(presente = 1) AS cantidad_presentes,
                    COUNT(*) AS total
                FROM asistencia
                WHERE id_alumno = @idAlumno";

                using MySqlCommand cmd = new(sql, conn);
                cmd.Parameters.AddWithValue("@idAlumno", idAlumno);
                using MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    int presentes = Convert.ToInt32(reader["cantidad_presentes"]);
                    int total = Convert.ToInt32(reader["total"]);

                    if (total > 0)
                        porcentaje = (double)presentes / total * 100;
                }
            }
            catch (Exception ex)
            {
                // CORREGIDO: Lanzar excepción en lugar de MessageBox
                throw new Exception($"Error calculando porcentaje de asistencia: {ex.Message}");
            }

            return Math.Round(porcentaje, 2);
        }

        // ==================== CONSULTAS PARA REPORTES ====================

        public DataTable ObtenerTablaAsistencia()
        {
            DataTable tabla = new DataTable();

            try
            {
                using (MySqlConnection conn = conexion.getConexion())
                {
                    conn.Open();

                    // CORREGIDO: Query optimizada sin cantidad_instrumentos
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

                // Agregar columna de porcentaje
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
                        // CORREGIDO: Lanzar excepción en lugar de MessageBox
                        throw new Exception($"Error calculando porcentaje para alumno ID {fila["id_alumno"]}: {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                // CORREGIDO: Lanzar excepción en lugar de MessageBox
                throw new Exception($"Error al obtener tabla de asistencias: {ex.Message}");
            }

            return tabla;
        }
    }
}