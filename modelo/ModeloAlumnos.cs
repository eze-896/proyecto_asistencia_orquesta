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

        public int InsertarAlumno(Alumno alumno)
        {
            int idGenerado = -1;

            string query = @"
            INSERT INTO alumno (dni, nombre, apellido, telefono_padres)
            VALUES (@dni, @nombre, @apellido, @telefono_padres);
            SELECT LAST_INSERT_ID();";

            using (MySqlConnection conn = conexion.getConexion())
            {
                try
                {
                    conn.Open();
                    using MySqlCommand cmd = new(query, conn);
                    cmd.Parameters.AddWithValue("@dni", alumno.Dni);
                    cmd.Parameters.AddWithValue("@nombre", alumno.Nombre);
                    cmd.Parameters.AddWithValue("@apellido", alumno.Apellido);
                    cmd.Parameters.AddWithValue("@telefono_padres", alumno.Telefono_padres);

                    object result = cmd.ExecuteScalar();
                    if (result != null)
                        idGenerado = Convert.ToInt32(result);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al insertar alumno: " + ex.Message);
                }
            }

            return idGenerado;
        }

        public List<Alumno> ObtenerAlumnosComoLista()
        {
            List<Alumno> lista = [];

            try
            {
                using MySqlConnection conn = conexion.getConexion();
                conn.Open();
                string query = "SELECT id, dni, nombre, apellido, telefono_padres FROM alumno";
                using MySqlCommand cmd = new(query, conn);
                using MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Alumno alumno = new()
                    {
                        Id = reader.GetInt32("id"),
                        Dni = reader.GetInt32("dni"),
                        Nombre = reader.GetString("nombre"),
                        Apellido = reader.GetString("apellido"),
                        Telefono_padres = reader.GetString("telefono_padres")
                    };
                    lista.Add(alumno);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener alumnos: " + ex.Message);
            }

            return lista;
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
                MessageBox.Show("Error al obtener alumnos: " + ex.Message);
            }
            return tabla;
        }

        public bool ActualizarAlumno(Alumno alumno)
        {
            bool exito = false;
            string query = @"
            UPDATE alumno
            SET dni = @dni, nombre = @nombre, apellido = @apellido, telefono_padres = @telefono_padres
            WHERE id = @id";

            using (MySqlConnection conn = conexion.getConexion())
            {
                try
                {
                    conn.Open();
                    using MySqlCommand cmd = new(query, conn);
                    cmd.Parameters.AddWithValue("@dni", alumno.Dni);
                    cmd.Parameters.AddWithValue("@nombre", alumno.Nombre);
                    cmd.Parameters.AddWithValue("@apellido", alumno.Apellido);
                    cmd.Parameters.AddWithValue("@telefono_padres", alumno.Telefono_padres);
                    cmd.Parameters.AddWithValue("@id", alumno.Id);

                    exito = cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar alumno: " + ex.Message);
                }
            }
            return exito;
        }

        public bool EliminarAlumno(int idAlumno)
        {
            bool exito = false;
            try
            {
                using MySqlConnection conn = conexion.getConexion();
                conn.Open();

                // Primero eliminamos las asistencias del alumno
                string deleteAsistencias = "DELETE FROM asistencia WHERE id_alumno = @id";
                using (MySqlCommand cmdAsis = new(deleteAsistencias, conn))
                {
                    cmdAsis.Parameters.AddWithValue("@id", idAlumno);
                    cmdAsis.ExecuteNonQuery();
                }

                // Luego eliminamos sus relaciones con instrumentos
                string deleteRelaciones = "DELETE FROM alumno_instrumento WHERE id_alumno = @id";
                using (MySqlCommand cmdRel = new(deleteRelaciones, conn))
                {
                    cmdRel.Parameters.AddWithValue("@id", idAlumno);
                    cmdRel.ExecuteNonQuery();
                }

                // Finalmente eliminamos al alumno
                string deleteAlumno = "DELETE FROM alumno WHERE id = @id";
                using MySqlCommand cmdAlu = new(deleteAlumno, conn);
                cmdAlu.Parameters.AddWithValue("@id", idAlumno);
                int filas = cmdAlu.ExecuteNonQuery();

                if (filas > 0)
                {
                    MessageBox.Show("Alumno eliminado correctamente.");
                    exito = true;
                }
                else
                {
                    MessageBox.Show("No se encontró el alumno a eliminar.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar alumno: " + ex.Message);
            }
            return exito;
        }


    }
}