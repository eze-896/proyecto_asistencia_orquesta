using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace GUI_Login.modelo
{
    /// <summary>
    /// Modelo para gestionar las operaciones de base de datos relacionadas con profesores
    /// Maneja CRUD completo y validaciones de datos a nivel de base de datos
    /// </summary>
    public class ModeloProfesor
    {
        private readonly Conexion conexion;

        /// <summary>
        /// Constructor que inicializa la conexión a la base de datos
        /// </summary>
        public ModeloProfesor()
        {
            conexion = new Conexion();
        }

        // ==================== OPERACIONES CRUD ====================

        /// <summary>
        /// Inserta un nuevo profesor en la base de datos
        /// </summary>
        /// <param name="profesor">Objeto Profesor con los datos a insertar</param>
        /// <returns>True si la inserción fue exitosa</returns>
        public bool InsertarProfesor(Profesor profesor)
        {
            bool resultado = false;
            string query = "INSERT INTO profesor (dni, nombre, apellido, telefono, email, id_instrumento) " +
                           "VALUES (@dni, @nombre, @apellido, @telefono, @email, @id_instrumento)";

            using (MySqlConnection conn = conexion.getConexion())
            {
                try
                {
                    conn.Open();
                    using MySqlCommand cmd = new(query, conn);
                    cmd.Parameters.AddWithValue("@dni", profesor.Dni);
                    cmd.Parameters.AddWithValue("@nombre", profesor.Nombre ?? "");
                    cmd.Parameters.AddWithValue("@apellido", profesor.Apellido ?? "");
                    cmd.Parameters.AddWithValue("@telefono", profesor.Telefono ?? "");
                    cmd.Parameters.AddWithValue("@email", profesor.Email ?? "");
                    cmd.Parameters.AddWithValue("@id_instrumento", profesor.Id_instrumento);

                    int filas = cmd.ExecuteNonQuery();
                    resultado = filas > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al insertar profesor: " + ex.Message);
                }
            }
            return resultado;
        }

        /// <summary>
        /// Obtiene la lista completa de todos los profesores
        /// </summary>
        /// <returns>Lista de objetos Profesor</returns>
        public List<Profesor> ListarProfesores()
        {
            var profesores = new List<Profesor>();
            string query = "SELECT * FROM profesor";

            using (MySqlConnection conn = conexion.getConexion())
            {
                try
                {
                    conn.Open();
                    using MySqlCommand cmd = new(query, conn);
                    using MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var profesor = new Profesor
                        {
                            Id = reader.GetInt32("id"),
                            Dni = reader.GetInt32("dni"),
                            Nombre = reader.IsDBNull(reader.GetOrdinal("nombre")) ? "" : reader.GetString("nombre"),
                            Apellido = reader.IsDBNull(reader.GetOrdinal("apellido")) ? "" : reader.GetString("apellido"),
                            Telefono = reader.IsDBNull(reader.GetOrdinal("telefono")) ? "" : reader.GetString("telefono"),
                            Email = reader.IsDBNull(reader.GetOrdinal("email")) ? "" : reader.GetString("email"),
                            Id_instrumento = reader.GetInt32("id_instrumento")
                        };
                        profesores.Add(profesor);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al listar profesores: " + ex.Message);
                }
            }
            return profesores;
        }

        /// <summary>
        /// Busca un profesor específico por su ID
        /// </summary>
        /// <param name="id">ID del profesor a buscar</param>
        /// <returns>Objeto Profesor si se encuentra, null si no existe</returns>
        public Profesor? BuscarProfesor(int id)
        {
            Profesor? profesor = null;
            string query = "SELECT * FROM profesor WHERE id = @id";

            using (MySqlConnection conn = conexion.getConexion())
            {
                try
                {
                    conn.Open();
                    using MySqlCommand cmd = new(query, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    using MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        profesor = new Profesor
                        {
                            Id = reader.GetInt32("id"),
                            Dni = reader.GetInt32("dni"),
                            Nombre = reader.IsDBNull(reader.GetOrdinal("nombre")) ? "" : reader.GetString("nombre"),
                            Apellido = reader.IsDBNull(reader.GetOrdinal("apellido")) ? "" : reader.GetString("apellido"),
                            Telefono = reader.IsDBNull(reader.GetOrdinal("telefono")) ? "" : reader.GetString("telefono"),
                            Email = reader.IsDBNull(reader.GetOrdinal("email")) ? "" : reader.GetString("email"),
                            Id_instrumento = reader.GetInt32("id_instrumento")
                        };
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al buscar profesor: " + ex.Message);
                }
            }
            return profesor;
        }

        /// <summary>
        /// Actualiza los datos de un profesor existente
        /// </summary>
        /// <param name="profesor">Objeto Profesor con los datos actualizados</param>
        /// <returns>True si la modificación fue exitosa</returns>
        public bool ModificarProfesor(Profesor profesor)
        {
            bool resultado = false;
            string query = "UPDATE profesor SET dni = @dni, nombre = @nombre, apellido = @apellido, " +
                           "telefono = @telefono, email = @email, id_instrumento = @id_instrumento " +
                           "WHERE id = @id";

            using (MySqlConnection conn = conexion.getConexion())
            {
                try
                {
                    conn.Open();
                    using MySqlCommand cmd = new(query, conn);
                    cmd.Parameters.AddWithValue("@dni", profesor.Dni);
                    cmd.Parameters.AddWithValue("@nombre", profesor.Nombre ?? "");
                    cmd.Parameters.AddWithValue("@apellido", profesor.Apellido ?? "");
                    cmd.Parameters.AddWithValue("@telefono", profesor.Telefono ?? "");
                    cmd.Parameters.AddWithValue("@email", profesor.Email ?? "");
                    cmd.Parameters.AddWithValue("@id_instrumento", profesor.Id_instrumento);
                    cmd.Parameters.AddWithValue("@id", profesor.Id);

                    int filas = cmd.ExecuteNonQuery();
                    resultado = filas > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al modificar profesor: " + ex.Message);
                }
            }
            return resultado;
        }

        /// <summary>
        /// Elimina un profesor de la base de datos
        /// </summary>
        /// <param name="id">ID del profesor a eliminar</param>
        /// <returns>True si la eliminación fue exitosa</returns>
        public bool EliminarProfesor(int id)
        {
            bool resultado = false;
            string query = "DELETE FROM profesor WHERE id = @id";

            using (MySqlConnection conn = conexion.getConexion())
            {
                try
                {
                    conn.Open();
                    using MySqlCommand cmd = new(query, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    int filas = cmd.ExecuteNonQuery();
                    resultado = filas > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar profesor: " + ex.Message);
                }
            }
            return resultado;
        }

        // ==================== CONSULTAS ESPECIALIZADAS ====================

        /// <summary>
        /// Obtiene los datos de profesores en formato DataTable para mostrar en GridView
        /// Incluye información de instrumentos y cátedras mediante JOIN
        /// </summary>
        /// <returns>DataTable con los datos formateados para visualización</returns>
        public DataTable ObtenerTablaProfesores()
        {
            DataTable tabla = new();
            try
            {
                using MySqlConnection conn = conexion.getConexion();
                conn.Open();

                string query = @"
                SELECT 
                    profesor.id,
                    profesor.dni,
                    profesor.nombre,
                    profesor.apellido,
                    profesor.telefono,
                    profesor.email,
                    instrumento.nombre AS instrumento,
                    instrumento.catedra AS catedra
                FROM profesor
                INNER JOIN instrumento_orquesta 
                    ON profesor.id_instrumento = instrumento_orquesta.id
                INNER JOIN instrumento 
                    ON instrumento_orquesta.id = instrumento.id";

                using MySqlCommand cmd = new(query, conn);
                using MySqlDataAdapter adapter = new(cmd);
                adapter.Fill(tabla);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener tabla de profesores: " + ex.Message);
            }

            return tabla;
        }

        // ==================== VALIDACIONES DE UNICIDAD ====================

        /// <summary>
        /// Verifica si ya existe un profesor con el mismo DNI
        /// </summary>
        /// <param name="dni">DNI a verificar</param>
        /// <param name="idExcluir">ID a excluir (para modificaciones)</param>
        /// <returns>True si el DNI ya existe</returns>
        public bool ExisteDni(int dni, int idExcluir = 0)
        {
            using MySqlConnection conn = conexion.getConexion();
            conn.Open();

            string query = "SELECT COUNT(*) FROM profesor WHERE dni = @dni AND id != @idExcluir";
            using MySqlCommand command = new(query, conn);
            command.Parameters.AddWithValue("@dni", dni);
            command.Parameters.AddWithValue("@idExcluir", idExcluir);

            int count = Convert.ToInt32(command.ExecuteScalar());
            return count > 0;
        }

        /// <summary>
        /// Verifica si ya existe un profesor con el mismo email
        /// </summary>
        /// <param name="email">Email a verificar</param>
        /// <param name="idExcluir">ID a excluir (para modificaciones)</param>
        /// <returns>True si el email ya existe</returns>
        public bool ExisteEmail(string email, int idExcluir = 0)
        {
            using MySqlConnection conn = conexion.getConexion();
            conn.Open();

            string query = "SELECT COUNT(*) FROM profesor WHERE email = @email AND id != @idExcluir";
            using MySqlCommand command = new(query, conn);
            command.Parameters.AddWithValue("@email", email);
            command.Parameters.AddWithValue("@idExcluir", idExcluir);

            int count = Convert.ToInt32(command.ExecuteScalar());
            return count > 0;
        }

        /// <summary>
        /// Verifica si ya existe un profesor con el mismo teléfono
        /// </summary>
        /// <param name="telefono">Teléfono a verificar</param>
        /// <param name="idExcluir">ID a excluir (para modificaciones)</param>
        /// <returns>True si el teléfono ya existe</returns>
        public bool ExisteTelefono(string telefono, int idExcluir = 0)
        {
            using MySqlConnection conn = conexion.getConexion();
            conn.Open();

            string query = "SELECT COUNT(*) FROM profesor WHERE telefono = @telefono AND id != @idExcluir";
            using MySqlCommand command = new(query, conn);
            command.Parameters.AddWithValue("@telefono", telefono);
            command.Parameters.AddWithValue("@idExcluir", idExcluir);

            int count = Convert.ToInt32(command.ExecuteScalar());
            return count > 0;
        }
    }
}