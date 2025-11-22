using MySql.Data.MySqlClient;
using System.Data;

namespace GUI_Login.modelo
{
    public class ModeloAlumno
    {
        private readonly Conexion conexion;

        public ModeloAlumno()
        {
            conexion = new Conexion();
        }

        // ==================== OPERACIONES CRUD ====================

        public int InsertarAlumno(Alumno alumno)
        {
            int idGenerado = -1;

            string query = @"
            INSERT INTO alumno (dni, nombre, apellido, telefono_padres)
            VALUES (@dni, @nombre, @apellido, @telefono_padres);
            SELECT LAST_INSERT_ID();";

            using MySqlConnection conn = conexion.getConexion();
            try
            {
                conn.Open();
                using MySqlCommand cmd = new(query, conn);
                cmd.Parameters.AddWithValue("@dni", alumno.Dni);
                cmd.Parameters.AddWithValue("@nombre", alumno.Nombre ?? "");
                cmd.Parameters.AddWithValue("@apellido", alumno.Apellido ?? "");
                cmd.Parameters.AddWithValue("@telefono_padres", alumno.Telefono_padres ?? "");

                object? result = cmd.ExecuteScalar();
                if (result != null)
                    idGenerado = Convert.ToInt32(result);
            }
            catch (Exception ex)
            {
                // CORREGIDO: Lanzar excepción en lugar de MessageBox
                throw new Exception($"Error al insertar alumno: {ex.Message}");
            }

            return idGenerado;
        }

        public bool ActualizarAlumno(Alumno alumno)
        {
            bool exito = false;
            string query = @"
            UPDATE alumno
            SET dni = @dni, nombre = @nombre, apellido = @apellido, telefono_padres = @telefono_padres
            WHERE id = @id";

            using MySqlConnection conn = conexion.getConexion();
            try
            {
                conn.Open();
                using MySqlCommand cmd = new(query, conn);
                cmd.Parameters.AddWithValue("@dni", alumno.Dni);
                cmd.Parameters.AddWithValue("@nombre", alumno.Nombre ?? "");
                cmd.Parameters.AddWithValue("@apellido", alumno.Apellido ?? "");
                cmd.Parameters.AddWithValue("@telefono_padres", alumno.Telefono_padres ?? "");
                cmd.Parameters.AddWithValue("@id", alumno.Id);

                exito = cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                // CORREGIDO: Lanzar excepción en lugar de MessageBox
                throw new Exception($"Error al actualizar alumno: {ex.Message}");
            }
            return exito;
        }

        public bool EliminarAlumno(int idAlumno)
        {
            bool exito = false;

            using MySqlConnection conn = conexion.getConexion();
            try
            {
                conn.Open();
                using MySqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // Eliminar asistencias
                    string deleteAsistencias = "DELETE FROM asistencia WHERE id_alumno = @id";
                    using (MySqlCommand cmdAsis = new(deleteAsistencias, conn, transaction))
                    {
                        cmdAsis.Parameters.AddWithValue("@id", idAlumno);
                        cmdAsis.ExecuteNonQuery();
                    }

                    // Eliminar relaciones con instrumentos
                    string deleteRelaciones = "DELETE FROM alumno_instrumento WHERE id_alumno = @id";
                    using (MySqlCommand cmdRel = new(deleteRelaciones, conn, transaction))
                    {
                        cmdRel.Parameters.AddWithValue("@id", idAlumno);
                        cmdRel.ExecuteNonQuery();
                    }

                    // Eliminar alumno
                    string deleteAlumno = "DELETE FROM alumno WHERE id = @id";
                    using MySqlCommand cmdAlu = new(deleteAlumno, conn, transaction);
                    cmdAlu.Parameters.AddWithValue("@id", idAlumno);
                    int filas = cmdAlu.ExecuteNonQuery();

                    if (filas > 0)
                    {
                        transaction.Commit();
                        exito = true;
                    }
                    else
                    {
                        transaction.Rollback();
                        // CORREGIDO: Lanzar excepción en lugar de MessageBox
                        throw new Exception("No se encontró el alumno a eliminar.");
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception($"Error en transacción de eliminación: {ex.Message}");
                }
            }
            catch (Exception ex)
            {
                // CORREGIDO: Lanzar excepción en lugar de MessageBox
                throw new Exception($"Error al eliminar alumno: {ex.Message}");
            }
            return exito;
        }

        // ==================== CONSULTAS CON MANEJO DE NULOS ====================

        public List<Alumno> ObtenerAlumnosComoLista()
        {
            List<Alumno> lista = new();

            try
            {
                using MySqlConnection conn = conexion.getConexion();
                conn.Open();
                string query = "SELECT id, dni, nombre, apellido, telefono_padres FROM alumno";
                using MySqlCommand cmd = new(query, conn);
                using MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    // CORREGIDO: Manejo seguro de valores nulos
                    Alumno alumno = new()
                    {
                        Id = reader.GetInt32("id"),
                        Dni = reader.GetInt32("dni"),
                        Nombre = reader.IsDBNull(reader.GetOrdinal("nombre")) ? string.Empty : reader.GetString("nombre"),
                        Apellido = reader.IsDBNull(reader.GetOrdinal("apellido")) ? string.Empty : reader.GetString("apellido"),
                        Telefono_padres = reader.IsDBNull(reader.GetOrdinal("telefono_padres")) ? string.Empty : reader.GetString("telefono_padres")
                    };
                    lista.Add(alumno);
                }
            }
            catch (Exception ex)
            {
                // CORREGIDO: Lanzar excepción en lugar de MessageBox
                throw new Exception($"Error al obtener alumnos: {ex.Message}");
            }

            return lista;
        }

        public Alumno? BuscarAlumno(int id)
        {
            Alumno? alumno = null;
            string query = "SELECT id, dni, nombre, apellido, telefono_padres FROM alumno WHERE id = @id";

            using MySqlConnection conn = conexion.getConexion();
            try
            {
                conn.Open();
                using MySqlCommand cmd = new(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                using MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    // CORREGIDO: Manejo seguro de valores nulos
                    alumno = new Alumno
                    {
                        Id = reader.GetInt32("id"),
                        Dni = reader.GetInt32("dni"),
                        Nombre = reader.IsDBNull(reader.GetOrdinal("nombre")) ? string.Empty : reader.GetString("nombre"),
                        Apellido = reader.IsDBNull(reader.GetOrdinal("apellido")) ? string.Empty : reader.GetString("apellido"),
                        Telefono_padres = reader.IsDBNull(reader.GetOrdinal("telefono_padres")) ? string.Empty : reader.GetString("telefono_padres")
                    };
                }
            }
            catch (Exception ex)
            {
                // CORREGIDO: Lanzar excepción en lugar de MessageBox
                throw new Exception($"Error al buscar alumno: {ex.Message}");
            }
            return alumno;
        }

        public DataTable ObtenerTablaAlumnos()
        {
            DataTable tabla = new();
            try
            {
                using MySqlConnection conn = conexion.getConexion();
                conn.Open();
                string query = "SELECT id, dni, nombre, apellido, telefono_padres FROM alumno";
                using MySqlCommand cmd = new(query, conn);
                using MySqlDataAdapter adapter = new(cmd);
                adapter.Fill(tabla);
            }
            catch (Exception ex)
            {
                // CORREGIDO: Lanzar excepción en lugar de MessageBox
                throw new Exception($"Error al obtener tabla de alumnos: {ex.Message}");
            }
            return tabla;
        }

        // ==================== VALIDACIONES DE UNICIDAD ====================

        public bool ExisteDni(int dni, int idExcluir = 0)
        {
            using MySqlConnection conn = conexion.getConexion();
            conn.Open();

            string query = "SELECT COUNT(*) FROM alumno WHERE dni = @dni AND id != @idExcluir";
            using MySqlCommand command = new(query, conn);
            command.Parameters.AddWithValue("@dni", dni);
            command.Parameters.AddWithValue("@idExcluir", idExcluir);

            int count = Convert.ToInt32(command.ExecuteScalar());
            return count > 0;
        }

        public bool ExisteTelefono(string telefono, int idExcluir = 0)
        {
            using MySqlConnection conn = conexion.getConexion();
            conn.Open();

            string query = "SELECT COUNT(*) FROM alumno WHERE telefono_padres = @telefono AND id != @idExcluir";
            using MySqlCommand command = new(query, conn);
            command.Parameters.AddWithValue("@telefono", telefono);
            command.Parameters.AddWithValue("@idExcluir", idExcluir);

            int count = Convert.ToInt32(command.ExecuteScalar());
            return count > 0;
        }
    }
}