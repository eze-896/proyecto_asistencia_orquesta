using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

public class ModeloAsistencia
{
    private Conexion conexion;

    public ModeloAsistencia()
    {
        conexion = new Conexion();
    }

    public List<Alumno> ListarAlumnos()
    {
        List<Alumno> alumnos = new List<Alumno>();

        try
        {
            using (MySqlConnection conn = conexion.getConexion())
            {
                conn.Open();
                string sql = "SELECT id, nombre, apellido FROM alumno ORDER BY apellido, nombre";
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Alumno alumno = new Alumno
                        {
                            Id = reader.GetInt32("id"),
                            Nombre = reader.GetString("nombre"),
                            Apellido = reader.GetString("apellido")
                        };
                        alumnos.Add(alumno);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error en ListarAlumnos: " + ex.Message);
        }

        return alumnos;
    }

    public bool MarcarAsistencia(Asistencia asistencia)
    {
        if (asistencia == null) return false;

        try
        {
            using (MySqlConnection conn = conexion.getConexion())
            {
                conn.Open();

                // Verificar si ya existe el registro
                string sqlVerificar = @"
                SELECT COUNT(*) 
                FROM asistencia
                WHERE id_alumno = @idAlumno 
                  AND DATE(fecha) = DATE(@fecha)
                  AND actividad_orquestal = @actividadOrquestal";

                int existe = 0;
                using (MySqlCommand cmdVerificar = new MySqlCommand(sqlVerificar, conn))
                {
                    cmdVerificar.Parameters.AddWithValue("@idAlumno", asistencia.IdAlumno);
                    cmdVerificar.Parameters.AddWithValue("@fecha", asistencia.Fecha);
                    cmdVerificar.Parameters.AddWithValue("@actividadOrquestal", asistencia.TipoActividad.ToString());

                    object resultado = cmdVerificar.ExecuteScalar();
                    existe = resultado != null ? Convert.ToInt32(resultado) : 0;
                }

                string query;
                if (existe > 0)
                {
                    query = @"
                    UPDATE asistencia
                    SET presente = @presente
                    WHERE id_alumno = @idAlumno 
                      AND DATE(fecha) = DATE(@fecha)
                      AND actividad_orquestal = @actividadOrquestal";
                }
                else
                {
                    query = @"
                    INSERT INTO asistencia (id_alumno, fecha, actividad_orquestal, presente)
                    VALUES (@idAlumno, @fecha, @actividadOrquestal, @presente)";
                }

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@idAlumno", asistencia.IdAlumno);
                    cmd.Parameters.AddWithValue("@fecha", asistencia.Fecha);
                    cmd.Parameters.AddWithValue("@actividadOrquestal", asistencia.TipoActividad.ToString());
                    cmd.Parameters.AddWithValue("@presente", asistencia.Presente);

                    int filasAfectadas = cmd.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error en MarcarAsistencia: " + ex.Message);
            return false;
        }
    }

    public double CalcularPorcentajeAsistencia(int idAlumno)
    {
        double porcentaje = 0;

        try
        {
            using (MySqlConnection conn = conexion.getConexion())
            {
                conn.Open();

                string sql = @"
                SELECT 
                    SUM(presente = 1) AS cantidad_presentes,
                    COUNT(*) AS total
                FROM asistencia
                WHERE id_alumno = @idAlumno";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@idAlumno", idAlumno);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int presentes = Convert.ToInt32(reader["cantidad_presentes"]);
                            int total = Convert.ToInt32(reader["total"]);

                            if (total > 0)
                                porcentaje = (double)presentes / total * 100;
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error calculando porcentaje: " + ex.Message);
        }

        return Math.Round(porcentaje, 2);
    }


    public DataTable ObtenerTablaAsistencia()
    {
        DataTable tabla = new DataTable();

        try
        {
            using (MySqlConnection conn = conexion.getConexion())
            {
                conn.Open();
                string sql = @"
            SELECT 
                a.id AS id_alumno,
                a.nombre AS nombre_alumno,
                a.apellido AS apellido_alumno,
                i.nombre AS nombre_instrumento,
                COALESCE(p.nombre, 'Sin asignar') AS nombre_profesor,
                COALESCE(p.apellido, '') AS apellido_profesor
            FROM alumno a
            LEFT JOIN alumno_instrumento ai ON a.id = ai.id_alumno
            LEFT JOIN instrumento_orquesta io ON ai.id_instrumento = io.id
            LEFT JOIN instrumento i ON io.id = i.id
            LEFT JOIN profesor p ON io.id = p.id_instrumento
            ORDER BY a.apellido, a.nombre";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(tabla);
                    }
                }
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
                    Console.WriteLine($"Error calculando porcentaje: {ex.Message}");
                    fila["porcentaje_asistencia"] = 0;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error en ObtenerTablaAsistencia: " + ex.Message);
        }

        return tabla;
    }
}