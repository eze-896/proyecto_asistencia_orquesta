using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace GUI_Login.modelo
{
    public class ModeloInstrumento
    {
        private readonly Conexion conexion;

        public ModeloInstrumento()
        {
            conexion = new Conexion();
        }

        // ==================== OPERACIONES CRUD ====================

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
                // CORREGIDO: Lanzar excepción en lugar de MessageBox
                throw new Exception($"Error al eliminar instrumento de la orquesta: {ex.Message}");
            }
        }

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
                // CORREGIDO: Aunque es poco probable, manejamos el error 1062 por si acaso
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
                    // CORREGIDO: Si no se puede parsear, lanzar excepción en lugar de usar valor por defecto
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
                    // CORREGIDO: Si no se puede parsear, lanzar excepción en lugar de usar valor por defecto
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