using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

public class ModeloInstrumento
{
    private Conexion conexion;

    public ModeloInstrumento()
    {
        conexion = new Conexion();
    }

    // Agregar un instrumento existente (de la tabla instrumento) a la orquesta
    public bool AgregarInstrumentoOrquesta(int idInstrumento)
    {
        using (MySqlConnection conn = conexion.getConexion())
        {
            conn.Open();

            string sql = "INSERT INTO instrumento_orquesta (id) VALUES (@id)";
            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@id", idInstrumento);

                try
                {
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (MySqlException ex)
                {
                    // Por ejemplo: si ya existe ese id en instrumento_orquesta (PK/FK duplicada)
                    Console.WriteLine("Error al agregar instrumento a la orquesta: " + ex.Message);
                    return false;
                }
            }
        }
    }

    // Listar intrumentos que pertenecen a la orquesta
    public List<Instrumento> ListarInstrumentosOrquesta()
    {
        List<Instrumento> lista = new List<Instrumento>();

        using (MySqlConnection conn = conexion.getConexion())
        {
            conn.Open();

            string sql = @"
                SELECT instrumento_orquesta.id, instrumento.nombre, instrumento.catedra
                FROM instrumento_orquesta
                INNER JOIN instrumento ON instrumento_orquesta.id = instrumento.id";

            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Instrumento inst = new Instrumento
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
        }

        return lista;
    }

    // Lista los instrumentos que aún NO están en la orquesta
    public List<Instrumento> ListarInstrumentosDisponibles()
    {
        List<Instrumento> lista = new List<Instrumento>();

        using (MySqlConnection conn = conexion.getConexion())
        {
            conn.Open();

            string sql = @"
                SELECT i.id, i.nombre, i.catedra
                FROM instrumento i
                LEFT JOIN instrumento_orquesta io ON i.id = io.id
                WHERE io.id IS NULL
                ORDER BY i.catedra, i.nombre";

            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Instrumento inst = new Instrumento
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
        }

        return lista;
    }
}
