using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace GUI_Login.modelo
{
    public class ModeloProfesor
    {
        private readonly Conexion conexion;

        public ModeloProfesor()
        {
            conexion = new Conexion();
        }

        // ==================== OPERACIONES CRUD ====================

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
                    // CORREGIDO: Lanzar excepción en lugar de MessageBox
                    throw new Exception($"Error al insertar profesor: {ex.Message}");
                }
            }
            return resultado;
        }

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
                            // CORREGIDO: Manejo seguro de valores nulos
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
                    // CORREGIDO: Lanzar excepción en lugar de MessageBox
                    throw new Exception($"Error al listar profesores: {ex.Message}");
                }
            }
            return profesores;
        }

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
                            // CORREGIDO: Manejo seguro de valores nulos
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
                    // CORREGIDO: Lanzar excepción en lugar de MessageBox
                    throw new Exception($"Error al buscar profesor: {ex.Message}");
                }
            }
            return profesor;
        }

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
                    // CORREGIDO: Lanzar excepción en lugar de MessageBox
                    throw new Exception($"Error al modificar profesor: {ex.Message}");
                }
            }
            return resultado;
        }

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
                    // CORREGIDO: Lanzar excepción en lugar de MessageBox
                    throw new Exception($"Error al eliminar profesor: {ex.Message}");
                }
            }
            return resultado;
        }

        // ==================== CONSULTAS ESPECIALIZADAS ====================

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
                // CORREGIDO: Lanzar excepción en lugar de MessageBox
                throw new Exception($"Error al obtener tabla de profesores: {ex.Message}");
            }

            return tabla;
        }

        // ==================== VALIDACIONES DE UNICIDAD ====================

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