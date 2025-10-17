using MySql.Data.MySqlClient;
using System;

public class ModeloAlumnoInstrumento
{
    private Conexion conexion = new Conexion();

    // Insertar relación nueva
    public bool InsertarAlumnoInstrumento(AlumnoInstrumento relacion)
    {
        bool insertado = false;

        using (MySqlConnection conn = conexion.getConexion())
        {
            conn.Open();
            string sql = "INSERT INTO alumno_instrumento (id_alumno, id_instrumento) VALUES (@idAlumno, @idInstrumento)";

            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@idAlumno", relacion.IdAlumno);
                cmd.Parameters.AddWithValue("@idInstrumento", relacion.IdInstrumento);

                insertado = cmd.ExecuteNonQuery() > 0;
            }
        }

        return insertado;
    }

    // Actualizar relación (si no existe, inserta)
    public bool ActualizarAlumnoInstrumento(AlumnoInstrumento relacion)
    {
        bool resultado = false;

        using (MySqlConnection conn = conexion.getConexion())
        {
            conn.Open();

            // Verificar si existe la relación
            string existeSql = "SELECT COUNT(*) FROM alumno_instrumento WHERE id_alumno = @idAlumno";
            using (MySqlCommand cmdExiste = new MySqlCommand(existeSql, conn))
            {
                cmdExiste.Parameters.AddWithValue("@idAlumno", relacion.IdAlumno);
                long count = (long)cmdExiste.ExecuteScalar();

                if (count > 0)
                {
                    // Actualizar
                    string updateSql = "UPDATE alumno_instrumento SET id_instrumento = @idInstrumento WHERE id_alumno = @idAlumno";
                    using (MySqlCommand cmdUpdate = new MySqlCommand(updateSql, conn))
                    {
                        cmdUpdate.Parameters.AddWithValue("@idAlumno", relacion.IdAlumno);
                        cmdUpdate.Parameters.AddWithValue("@idInstrumento", relacion.IdInstrumento);
                        resultado = cmdUpdate.ExecuteNonQuery() > 0;
                    }
                }
                else
                {
                    // Insertar nueva relación
                    resultado = InsertarAlumnoInstrumento(relacion);
                }
            }
        }

        return resultado;
    }

    // Obtener el instrumento de un alumno
    public int ObtenerInstrumentoPorAlumno(int idAlumno)
    {
        int idInstrumento = -1;

        using (MySqlConnection conn = conexion.getConexion())
        {
            conn.Open();
            string sql = "SELECT id_instrumento FROM alumno_instrumento WHERE id_alumno = @idAlumno LIMIT 1";
            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@idAlumno", idAlumno);
                object result = cmd.ExecuteScalar();
                if (result != null)
                    idInstrumento = Convert.ToInt32(result);
            }
        }

        return idInstrumento;
    }
}
