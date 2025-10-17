using System;
using System.Data;
using MySql.Data.MySqlClient;

public class ModeloProfesor
{
    private Conexion conexion;

    public ModeloProfesor()
    {
        conexion = new Conexion();
    }

    // Insertar profesor
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
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@dni", profesor.Dni);
                    cmd.Parameters.AddWithValue("@nombre", profesor.Nombre);
                    cmd.Parameters.AddWithValue("@apellido", profesor.Apellido);
                    cmd.Parameters.AddWithValue("@telefono", profesor.Telefono);
                    cmd.Parameters.AddWithValue("@email", profesor.Email);
                    cmd.Parameters.AddWithValue("@id_instrumento", profesor.Id_instrumento);

                    int filas = cmd.ExecuteNonQuery();
                    resultado = filas > 0;
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error al insertar profesor: " + ex.Message);
            }
        }
        return resultado;
    }

    // Listar profesores
    public System.Collections.Generic.List<Profesor> ListarProfesores()
    {
        var profesores = new System.Collections.Generic.List<Profesor>();
        string query = "SELECT * FROM profesor";

        using (MySqlConnection conn = conexion.getConexion())
        {
            try
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var profesor = new Profesor
                            {
                                Id = reader.GetInt32("id"),
                                Dni = reader.GetInt32("dni"),
                                Nombre = reader.GetString("nombre"),
                                Apellido = reader.GetString("apellido"),
                                Telefono = reader.GetString("telefono"),
                                Email = reader.GetString("email"),
                                Id_instrumento = reader.GetInt32("id_instrumento")
                            };
                            profesores.Add(profesor);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error al listar profesores: " + ex.Message);
            }
        }
        return profesores;
    }

    // Buscar profesor por ID
    public Profesor BuscarProfesor(int id)
    {
        Profesor profesor = null;
        string query = "SELECT * FROM profesor WHERE id = @id";

        using (MySqlConnection conn = conexion.getConexion())
        {
            try
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            profesor = new Profesor
                            {
                                Id = reader.GetInt32("id"),
                                Dni = reader.GetInt32("dni"),
                                Nombre = reader.GetString("nombre"),
                                Apellido = reader.GetString("apellido"),
                                Telefono = reader.GetString("telefono"),
                                Email = reader.GetString("email"),
                                Id_instrumento = reader.GetInt32("id_instrumento")
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error al buscar profesor: " + ex.Message);
            }
        }
        return profesor;
    }

    // Modificar profesor
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
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@dni", profesor.Dni);
                    cmd.Parameters.AddWithValue("@nombre", profesor.Nombre);
                    cmd.Parameters.AddWithValue("@apellido", profesor.Apellido);
                    cmd.Parameters.AddWithValue("@telefono", profesor.Telefono);
                    cmd.Parameters.AddWithValue("@email", profesor.Email);
                    cmd.Parameters.AddWithValue("@id_instrumento", profesor.Id_instrumento);
                    cmd.Parameters.AddWithValue("@id", profesor.Id);

                    int filas = cmd.ExecuteNonQuery();
                    resultado = filas > 0;
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error al modificar profesor: " + ex.Message);
            }
        }
        return resultado;
    }

    // Eliminar profesor
    public bool EliminarProfesor(int id)
    {
        bool resultado = false;
        string query = "DELETE FROM profesor WHERE id = @id";

        using (MySqlConnection conn = conexion.getConexion())
        {
            try
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    int filas = cmd.ExecuteNonQuery();
                    resultado = filas > 0;
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error al eliminar profesor: " + ex.Message);
            }
        }
        return resultado;
    }

    // Obtener tabla para DataGridView
    public DataTable ObtenerTablaProfesores()
    {
        DataTable tabla = new DataTable();
        try
        {
            using (MySqlConnection conn = conexion.getConexion())
            {
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

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(tabla);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            System.Windows.Forms.MessageBox.Show("Error al obtener tabla de profesores: " + ex.Message);
        }

        return tabla;
    }

}
