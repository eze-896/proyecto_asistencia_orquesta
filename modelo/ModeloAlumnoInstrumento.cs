using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace GUI_Login.modelo
{
    public class ModeloAlumnoInstrumento
    {
        private readonly Conexion conexion = new();

        // ==================== OPERACIONES CRUD ====================

        public bool InsertarAlumnoInstrumento(AlumnoInstrumento relacion)
        {
            bool insertado = false;

            using MySqlConnection conn = conexion.getConexion();
            try
            {
                conn.Open();
                string sql = "INSERT INTO alumno_instrumento (id_alumno, id_instrumento) VALUES (@idAlumno, @idInstrumento)";

                using MySqlCommand cmd = new(sql, conn);
                cmd.Parameters.AddWithValue("@idAlumno", relacion.IdAlumno);
                cmd.Parameters.AddWithValue("@idInstrumento", relacion.IdInstrumento);

                insertado = cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                // CORREGIDO: Lanzar excepción en lugar de MessageBox
                throw new Exception($"Error al insertar relación alumno-instrumento: {ex.Message}");
            }

            return insertado;
        }

        public bool RegistrarInstrumentosParaAlumno(int idAlumno, List<int> idsInstrumentos)
        {
            bool resultado = false;

            using MySqlConnection conn = conexion.getConexion();
            try
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
                catch (Exception ex)
                {
                    // CORREGIDO: Manejo seguro del rollback
                    try
                    {
                        transaction.Rollback();
                    }
                    catch (Exception rollbackEx)
                    {
                        throw new Exception($"Error al hacer rollback: {rollbackEx.Message}. Error original: {ex.Message}");
                    }
                    throw;
                }
            }
            catch (Exception ex)
            {
                // CORREGIDO: Lanzar excepción en lugar de MessageBox
                throw new Exception($"Error al registrar instrumentos para alumno: {ex.Message}");
            }

            return resultado;
        }

        public bool ActualizarAlumnoInstrumento(AlumnoInstrumento relacion)
        {
            bool resultado = false;

            using MySqlConnection conn = conexion.getConexion();
            try
            {
                conn.Open();

                // Verificar si existe la relación
                string existeSql = "SELECT COUNT(*) FROM alumno_instrumento WHERE id_alumno = @idAlumno AND id_instrumento = @idInstrumento";
                using MySqlCommand cmdExiste = new(existeSql, conn);
                cmdExiste.Parameters.AddWithValue("@idAlumno", relacion.IdAlumno);
                cmdExiste.Parameters.AddWithValue("@idInstrumento", relacion.IdInstrumento);
                long count = (long)cmdExiste.ExecuteScalar();

                if (count > 0)
                {
                    // La relación ya existe, no es necesario actualizar
                    resultado = true;
                }
                else
                {
                    // Insertar nueva relación
                    resultado = InsertarAlumnoInstrumento(relacion);
                }
            }
            catch (Exception ex)
            {
                // CORREGIDO: Lanzar excepción en lugar de MessageBox
                throw new Exception($"Error al actualizar relación alumno-instrumento: {ex.Message}");
            }

            return resultado;
        }

        public bool ActualizarInstrumentosDeAlumno(int idAlumno, List<int> idsInstrumentos)
        {
            bool resultado = false;

            using MySqlConnection conn = conexion.getConexion();
            try
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
                catch (Exception ex)
                {
                    // CORREGIDO: Manejo seguro del rollback
                    try
                    {
                        transaction.Rollback();
                    }
                    catch (Exception rollbackEx)
                    {
                        throw new Exception($"Error al hacer rollback: {rollbackEx.Message}. Error original: {ex.Message}");
                    }
                    throw;
                }
            }
            catch (Exception ex)
            {
                // CORREGIDO: Lanzar excepción en lugar de MessageBox
                throw new Exception($"Error al actualizar instrumentos del alumno: {ex.Message}");
            }

            return resultado;
        }

        // ==================== CONSULTAS ====================

        public List<int> ObtenerInstrumentosPorAlumno(int idAlumno)
        {
            List<int> instrumentos = new List<int>();

            using MySqlConnection conn = conexion.getConexion();
            try
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
            catch (Exception ex)
            {
                // CORREGIDO: Lanzar excepción en lugar de MessageBox
                throw new Exception($"Error al obtener instrumentos del alumno: {ex.Message}");
            }

            return instrumentos;
        }

        // ==================== OPERACIONES DE ELIMINACIÓN ====================

        public bool EliminarRelacionPorAlumno(int idAlumno)
        {
            bool eliminado = false;

            using MySqlConnection conn = conexion.getConexion();
            try
            {
                conn.Open();
                string sql = "DELETE FROM alumno_instrumento WHERE id_alumno = @idAlumno";

                using MySqlCommand cmd = new(sql, conn);
                cmd.Parameters.AddWithValue("@idAlumno", idAlumno);
                eliminado = cmd.ExecuteNonQuery() >= 0; // CORREGIDO: >= 0 en lugar de > 0
            }
            catch (Exception ex)
            {
                // CORREGIDO: Lanzar excepción en lugar de MessageBox
                throw new Exception($"Error al eliminar relaciones del alumno: {ex.Message}");
            }

            return eliminado;
        }

        public bool EliminarRelacionEspecifica(int idAlumno, int idInstrumento)
        {
            bool eliminado = false;

            using MySqlConnection conn = conexion.getConexion();
            try
            {
                conn.Open();
                string sql = "DELETE FROM alumno_instrumento WHERE id_alumno = @idAlumno AND id_instrumento = @idInstrumento";

                using MySqlCommand cmd = new(sql, conn);
                cmd.Parameters.AddWithValue("@idAlumno", idAlumno);
                cmd.Parameters.AddWithValue("@idInstrumento", idInstrumento);
                eliminado = cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                // CORREGIDO: Lanzar excepción en lugar de MessageBox
                throw new Exception($"Error al eliminar relación específica: {ex.Message}");
            }

            return eliminado;
        }
    }
}