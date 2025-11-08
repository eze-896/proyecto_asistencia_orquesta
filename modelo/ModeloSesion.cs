using MySql.Data.MySqlClient;

class ModeloSesion
{
    private string sql = "";

    public Usuario? MiUsuario(string usuario)
    {
        Usuario? miUser = null;
        Conexion miConexion = new();
        MySqlConnection c1 = miConexion.getConexion();
        c1.Open();

        sql = "SELECT * FROM Usuario WHERE nombre = @nombre";
        MySqlCommand comando = new(sql, c1);
        comando.Parameters.AddWithValue("@nombre", usuario);

        MySqlDataReader reader = comando.ExecuteReader();

        if (reader.HasRows)
        {
            while (reader.Read())
            {
                miUser = new Usuario
                {
                    Id = int.Parse(reader["id"].ToString() ?? "0"),
                    Contrasena = reader["contrasena"].ToString() ?? "",
                    Nombre = reader["nombre"].ToString() ?? ""
                };
            }
        }

        reader.Close();
        c1.Close();
        return miUser;
    }

    public static bool RegistrarUsuario(Usuario nuevoUser)
    {
        bool exito = false;
        Conexion miConexion = new();
        MySqlConnection c1 = miConexion.getConexion();
        c1.Open();

        string sql = "INSERT INTO Usuario (nombre, contrasena) VALUES (@nombre, @contrasena)";
        MySqlCommand comando = new(sql, c1);
        comando.Parameters.AddWithValue("@nombre", nuevoUser.Nombre ?? "");
        comando.Parameters.AddWithValue("@contrasena", nuevoUser.Contrasena ?? "");

        int filas = comando.ExecuteNonQuery();

        if (filas > 0) exito = true;

        c1.Close();
        return exito;
    }
}
