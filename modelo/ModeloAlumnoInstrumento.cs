using MySql.Data.MySqlClient;
using System;

namespace GUI_Login.modelo
{
    public class ModeloAlumnoInstrumento
    {
        private readonly Conexion conexion = new();

        // Insertar relación nueva
        public bool InsertarAlumnoInstrumento(AlumnoInstrumento relacion)
        {
            bool insertado = false;

            using (MySqlConnection conn = conexion.getConexion())
            {
                conn.Open();
                string sql = "INSERT INTO alumno_instrumento (id_alumno, id_instrumento) VALUES (@idAlumno, @idInstrumento)";

                using MySqlCommand cmd = new(sql, conn);
                cmd.Parameters.AddWithValue("@idAlumno", relacion.IdAlumno);
                cmd.Parameters.AddWithValue("@idInstrumento", relacion.IdInstrumento);

                insertado = cmd.ExecuteNonQuery() > 0;
            }

            return insertado;
        }

        public bool RegistrarInstrumentosParaAlumno(int idAlumno, List<int> idsInstrumentos)
        {
            bool resultado = false;

            using (MySqlConnection conn = conexion.getConexion())
            {
                conn.Open();
                using MySqlTransaction transaction = conn.BeginTransaction();
                try
                {
                    string insertSql = "INSERT INTO alumno_instrumento (id_alumno, id_instrumento) VALUES (@idAlumno, @idInstrumento)";

                    foreach (int idInstrumento in idsInstrumentos)
                    {
                        using MySqlCommand cmdInsert = new(insertSql, conn, transaction);
                        cmdInsert.Parameters.AddWithValue("@idAlumno", idAlumno);
                        cmdInsert.Parameters.AddWithValue("@idInstrumento", idInstrumento);
                        cmdInsert.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    resultado = true;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }

            return resultado;
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
                using MySqlCommand cmdExiste = new(existeSql, conn);
                cmdExiste.Parameters.AddWithValue("@idAlumno", relacion.IdAlumno);
                long count = (long)cmdExiste.ExecuteScalar();

                if (count > 0)
                {
                    // Actualizar
                    string updateSql = "UPDATE alumno_instrumento SET id_instrumento = @idInstrumento WHERE id_alumno = @idAlumno";
                    using MySqlCommand cmdUpdate = new(updateSql, conn);
                    cmdUpdate.Parameters.AddWithValue("@idAlumno", relacion.IdAlumno);
                    cmdUpdate.Parameters.AddWithValue("@idInstrumento", relacion.IdInstrumento);
                    resultado = cmdUpdate.ExecuteNonQuery() > 0;
                }
                else
                {
                    // Insertar nueva relación
                    resultado = InsertarAlumnoInstrumento(relacion);
                }
            }

            return resultado;
        }

        public bool ActualizarInstrumentosDeAlumno(int idAlumno, List<int> idsInstrumentos)
        {
            bool resultado = false;

            using (MySqlConnection conn = conexion.getConexion())
            {
                conn.Open();
                using MySqlTransaction transaction = conn.BeginTransaction();
                try
                {
                    // Eliminar todas las relaciones actuales del alumno
                    string deleteSql = "DELETE FROM alumno_instrumento WHERE id_alumno = @idAlumno";
                    using MySqlCommand cmdDelete = new(deleteSql, conn, transaction);
                    cmdDelete.Parameters.AddWithValue("@idAlumno", idAlumno);
                    cmdDelete.ExecuteNonQuery();

                    // Insertar las nuevas relaciones
                    string insertSql = "INSERT INTO alumno_instrumento (id_alumno, id_instrumento) VALUES (@idAlumno, @idInstrumento)";
                    foreach (int idInstrumento in idsInstrumentos)
                    {
                        using MySqlCommand cmdInsert = new(insertSql, conn, transaction);
                        cmdInsert.Parameters.AddWithValue("@idAlumno", idAlumno);
                        cmdInsert.Parameters.AddWithValue("@idInstrumento", idInstrumento);
                        cmdInsert.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    resultado = true;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }

            return resultado;
        }

        // Obtener el instrumento de un alumno
        public List<int> ObtenerInstrumentosPorAlumno(int idAlumno)
        {
            List<int> instrumentos = [];

            using (MySqlConnection conn = conexion.getConexion())
            {
                conn.Open();
                string sql = "SELECT id_instrumento FROM alumno_instrumento WHERE id_alumno = @idAlumno";
                using MySqlCommand cmd = new(sql, conn);
                cmd.Parameters.AddWithValue("@idAlumno", idAlumno);

                using MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    instrumentos.Add(reader.GetInt32("id_instrumento"));
                }
            }

            return instrumentos;
        }

        // Eliminar relación por alumno
        public bool EliminarRelacionPorAlumno(int idAlumno)
        {
            bool eliminado = false;

            using (MySqlConnection conn = conexion.getConexion())
            {
                conn.Open();
                string sql = "DELETE FROM alumno_instrumento WHERE id_alumno = @idAlumno";

                using MySqlCommand cmd = new(sql, conn);
                cmd.Parameters.AddWithValue("@idAlumno", idAlumno);
                eliminado = cmd.ExecuteNonQuery() > 0;
            }

            return eliminado;
        }
    }
}