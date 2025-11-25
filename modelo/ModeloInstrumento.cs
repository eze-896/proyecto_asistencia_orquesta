using MySql.Data.MySqlClient;

namespace GUI_Login.modelo
{
    /// <summary>
    /// Modelo para gestionar las operaciones de base de datos relacionadas con instrumentos
    /// </summary>
    public class ModeloInstrumento
    {
        private readonly Conexion conexion;

        /// <summary>
        /// Constructor que inicializa la conexión a la base de datos
        /// </summary>
        public ModeloInstrumento()
        {
            conexion = new Conexion();
        }

        // ==================== OPERACIONES CRUD ====================

        /// <summary>
        /// Elimina un instrumento de la tabla instrumento_orquesta
        /// </summary>
        /// <param name="idInstrumento">ID del instrumento a eliminar</param>
        /// <returns>True si la eliminación fue exitosa</returns>
        public bool EliminarInstrumentoOrquesta(int idInstrumento)
        {
            using MySqlConnection conn = conexion.getConexion();

            try
            {
                conn.Open();
                string sql = "DELETE FROM instrumento_orquesta WHERE id = @id";

                using MySqlCommand cmd = new(sql, conn);
                cmd.Parameters.AddWithValue("@id", idInstrumento);

                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al eliminar instrumento de la orquesta: {ex.Message}");
            }
        }

        /// <summary>
        /// Agrega un instrumento a la tabla instrumento_orquesta
        /// </summary>
        /// <param name="idInstrumento">ID del instrumento a agregar</param>
        /// <returns>True si la inserción fue exitosa</returns>
        public bool AgregarInstrumentoOrquesta(int idInstrumento)
        {
            using MySqlConnection conn = conexion.getConexion();

            try
            {
                conn.Open();
                string sql = "INSERT INTO instrumento_orquesta (id) VALUES (@id)";

                using MySqlCommand cmd = new(sql, conn);
                cmd.Parameters.AddWithValue("@id", idInstrumento);

                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1062)
                {
                    throw new Exception("El instrumento ya está en la orquesta.");
                }
                throw new Exception($"Error de base de datos al agregar instrumento: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error inesperado al agregar instrumento: {ex.Message}");
            }
        }

        // ==================== VALIDACIONES DE USO ====================

        /// <summary>
        /// Verifica si un instrumento está siendo utilizado por algún profesor
        /// </summary>
        /// <param name="idInstrumento">ID del instrumento a verificar</param>
        /// <returns>True si el instrumento está en uso por profesores</returns>
        public bool EstaInstrumentoEnUso(int idInstrumento)
        {
            using MySqlConnection conn = conexion.getConexion();

            try
            {
                conn.Open();
                string sql = "SELECT COUNT(*) FROM profesor WHERE id_instrumento = @id";

                using MySqlCommand cmd = new(sql, conn);
                cmd.Parameters.AddWithValue("@id", idInstrumento);

                long count = Convert.ToInt64(cmd.ExecuteScalar());
                return count > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al verificar uso del instrumento: {ex.Message}");
            }
        }

        /// <summary>
        /// Verifica si un instrumento está siendo utilizado por algún alumno
        /// </summary>
        /// <param name="idInstrumento">ID del instrumento a verificar</param>
        /// <returns>True si el instrumento está en uso por alumnos</returns>
        public bool EstaInstrumentoEnUsoPorAlumnos(int idInstrumento)
        {
            using MySqlConnection conn = conexion.getConexion();

            try
            {
                conn.Open();
                string sql = "SELECT COUNT(*) FROM alumno_instrumento WHERE id_instrumento = @id";

                using MySqlCommand cmd = new(sql, conn);
                cmd.Parameters.AddWithValue("@id", idInstrumento);

                long count = Convert.ToInt64(cmd.ExecuteScalar());
                return count > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al verificar uso del instrumento por alumnos: {ex.Message}");
            }
        }

        // ==================== CONSULTAS ====================

        /// <summary>
        /// Obtiene la lista de instrumentos que están en la orquesta
        /// </summary>
        /// <returns>Lista de objetos Instrumento de la orquesta</returns>
        public List<Instrumento> ListarInstrumentosOrquesta()
        {
            List<Instrumento> lista = new List<Instrumento>();

            using MySqlConnection conn = conexion.getConexion();

            try
            {
                conn.Open();
                string sql = @"
                SELECT instrumento_orquesta.id, instrumento.nombre, instrumento.catedra
                FROM instrumento_orquesta
                INNER JOIN instrumento ON instrumento_orquesta.id = instrumento.id
                ORDER BY instrumento.catedra, instrumento.nombre";

                using MySqlCommand cmd = new(sql, conn);
                using MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string catedraStr = reader.GetString("catedra");

                    if (!Enum.TryParse(catedraStr, out Instrumento.Tipo_Catedra catedra))
                    {
                        throw new Exception($"Valor de cátedra no válido en la base de datos: '{catedraStr}' para el instrumento '{reader.GetString("nombre")}'");
                    }

                    Instrumento inst = new()
                    {
                        Id = reader.GetInt32("id"),
                        Nombre = reader.GetString("nombre"),
                        Catedra = catedra
                    };
                    lista.Add(inst);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener instrumentos de la orquesta: {ex.Message}");
            }

            return lista;
        }

        /// <summary>
        /// Obtiene la lista de instrumentos disponibles (no en la orquesta)
        /// </summary>
        /// <returns>Lista de objetos Instrumento disponibles</returns>
        public List<Instrumento> ListarInstrumentosDisponibles()
        {
            List<Instrumento> lista = new List<Instrumento>();

            using MySqlConnection conn = conexion.getConexion();

            try
            {
                conn.Open();
                string sql = @"
                SELECT i.id, i.nombre, i.catedra
                FROM instrumento i
                LEFT JOIN instrumento_orquesta io ON i.id = io.id
                WHERE io.id IS NULL
                ORDER BY i.catedra, i.nombre";

                using MySqlCommand cmd = new(sql, conn);
                using MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string catedraStr = reader.GetString("catedra");

                    if (!Enum.TryParse(catedraStr, out Instrumento.Tipo_Catedra catedra))
                    {
                        throw new Exception($"Valor de cátedra no válido en la base de datos: '{catedraStr}' para el instrumento '{reader.GetString("nombre")}'");
                    }

                    Instrumento inst = new()
                    {
                        Id = reader.GetInt32("id"),
                        Nombre = reader.GetString("nombre"),
                        Catedra = catedra
                    };
                    lista.Add(inst);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener instrumentos disponibles: {ex.Message}");
            }

            return lista;
        }
    }
}