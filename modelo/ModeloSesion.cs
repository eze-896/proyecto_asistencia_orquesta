using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace GUI_Login.modelo
{
    public class ModeloSesion
    {
        private readonly Conexion conexion;

        public ModeloSesion()
        {
            conexion = new Conexion();
        }

        // ==================== CONSULTAS ====================

        public Usuario? ObtenerUsuarioPorNombre(string usuario)
        {
            Usuario? miUser = null;

            using MySqlConnection c1 = conexion.getConexion();
            try
            {
                c1.Open();
                // Usar LIMIT 1 para asegurar un solo resultado
                string sql = "SELECT * FROM Usuario WHERE nombre = @nombre LIMIT 1";

                using MySqlCommand comando = new(sql, c1);
                comando.Parameters.AddWithValue("@nombre", usuario);

                using MySqlDataReader reader = comando.ExecuteReader();

                if (reader.Read()) // Solo el primero si hay múltiples
                {
                    miUser = new Usuario
                    {
                        Id = reader.GetInt32("id"),
                        Contrasena = reader.GetString("contrasena"),
                        Nombre = reader.GetString("nombre")
                    };
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al buscar usuario: {ex.Message}");
            }

            return miUser;
        }

        // ==================== OPERACIONES CRUD ====================

        public bool RegistrarUsuario(Usuario nuevoUser)
        {
            using MySqlConnection c1 = conexion.getConexion();
            try
            {
                c1.Open();

                // Verificar si ya existe el usuario ANTES de insertar
                string sqlVerificar = "SELECT COUNT(*) FROM Usuario WHERE nombre = @nombre";
                using (MySqlCommand cmdVerificar = new(sqlVerificar, c1))
                {
                    cmdVerificar.Parameters.AddWithValue("@nombre", nuevoUser.Nombre);
                    long existe = Convert.ToInt64(cmdVerificar.ExecuteScalar());

                    if (existe > 0)
                    {
                        throw new Exception("El nombre de usuario ya está en uso.");
                    }
                }

                // Si no existe, insertar
                string sqlInsert = "INSERT INTO Usuario (nombre, contrasena) VALUES (@nombre, @contrasena)";
                using MySqlCommand comando = new(sqlInsert, c1);
                comando.Parameters.AddWithValue("@nombre", nuevoUser.Nombre ?? "");
                comando.Parameters.AddWithValue("@contrasena", nuevoUser.Contrasena ?? "");

                int filas = comando.ExecuteNonQuery();
                return filas > 0;
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1062) // Duplicate entry
                {
                    throw new Exception("El nombre de usuario ya está en uso.");
                }
                throw new Exception($"Error al registrar usuario: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error inesperado al registrar usuario: {ex.Message}");
            }
        }
    }
}