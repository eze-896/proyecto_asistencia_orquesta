using MySql.Data.MySqlClient;
// Es importante utilizar la biblioteca de clases MySql,
// en particular, Data.MySqlClient
public class Conexion
{
    //ATRITUBOS DE CLASE
    private const string servidor = "datasource=127.0.0.1";
    private const string puerto = "port=3306";
    private const string username = "username=root";
    private const string password = "password=root";
    private const string bd = "database=bdorquesta";
    //ATRIBUTOS DE INSTANCIA
    private String cadenaConexion;
    //CONSTRUCTOR
    public Conexion()
    {

        cadenaConexion = servidor + ";" + puerto + ";" + username
        + ";" + password + ";" + bd;

    }
    //SERVICIOS
    public MySqlConnection getConexion()
    {
        return new MySqlConnection(cadenaConexion);
    }
}