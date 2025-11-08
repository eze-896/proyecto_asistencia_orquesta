using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace GUI_Login.modelo
{
    public class ModeloInstrumento
    {
        private readonly Conexion conexion;

        public ModeloInstrumento()
        {
            conexion = new Conexion();
        }

        // Método para eliminar instrumento de la orquesta
        public bool EliminarInstrumentoOrquesta(int idInstrumento)
        {
            using MySqlConnection conn = conexion.getConexion();
            conn.Open();

            string sql = "DELETE FROM instrumento_orquesta WHERE id = @id";
            using MySqlCommand cmd = new(sql, conn);
            cmd.Parameters.AddWithValue("@id", idInstrumento);

            try
            {
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error al eliminar instrumento de la orquesta: " + ex.Message);
                return false;
            }
        }

        // Verificar si el instrumento está siendo usado por algún profesor
        public bool EstaInstrumentoEnUso(int idInstrumento)
        {
            using MySqlConnection conn = conexion.getConexion();
            conn.Open();

            string sql = "SELECT COUNT(*) FROM profesor WHERE id_instrumento = @id";
            using MySqlCommand cmd = new(sql, conn);
            cmd.Parameters.AddWithValue("@id", idInstrumento);
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            return count > 0;
        }

        // Verificar si el instrumento está siendo usado por algún alumno
        public bool EstaInstrumentoEnUsoPorAlumnos(int idInstrumento)
        {
            using MySqlConnection conn = conexion.getConexion();
            conn.Open();

            string sql = "SELECT COUNT(*) FROM alumno_instrumento WHERE id_instrumento = @id";
            using MySqlCommand cmd = new(sql, conn);
            cmd.Parameters.AddWithValue("@id", idInstrumento);
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            return count > 0;
        }

        // Resto de los métodos existentes...
        public bool AgregarInstrumentoOrquesta(int idInstrumento)
        {
            using MySqlConnection conn = conexion.getConexion();
            conn.Open();

            string sql = "INSERT INTO instrumento_orquesta (id) VALUES (@id)";
            using MySqlCommand cmd = new(sql, conn);
            cmd.Parameters.AddWithValue("@id", idInstrumento);

            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error al agregar instrumento a la orquesta: " + ex.Message);
                return false;
            }
        }

        public List<Instrumento> ListarInstrumentosOrquesta()
        {
            List<Instrumento> lista = [];

            using (MySqlConnection conn = conexion.getConexion())
            {
                conn.Open();

                string sql = @"
                SELECT instrumento_orquesta.id, instrumento.nombre, instrumento.catedra
                FROM instrumento_orquesta
                INNER JOIN instrumento ON instrumento_orquesta.id = instrumento.id";

                using MySqlCommand cmd = new(sql, conn);
                using MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Instrumento inst = new()
                    {
                        Id = reader.GetInt32("id"),
                        Nombre = reader.GetString("nombre"),
                        Catedra = (Instrumento.Tipo_Catedra)Enum.Parse(
                                      typeof(Instrumento.Tipo_Catedra),
                                      reader.GetString("catedra"))
                    };

                    lista.Add(inst);
                }
            }

            return lista;
        }

        public List<Instrumento> ListarInstrumentosDisponibles()
        {
            List<Instrumento> lista = [];

            using (MySqlConnection conn = conexion.getConexion())
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
                    Instrumento inst = new()
                    {
                        Id = reader.GetInt32("id"),
                        Nombre = reader.GetString("nombre"),
                        Catedra = (Instrumento.Tipo_Catedra)Enum.Parse(
                                      typeof(Instrumento.Tipo_Catedra),
                                      reader.GetString("catedra"))
                    };

                    lista.Add(inst);
                }
            }

            return lista;
        }
    }
}