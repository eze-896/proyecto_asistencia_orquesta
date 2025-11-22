using MySql.Data.MySqlClient;

/// <summary>
/// Clase encargada de gestionar la conexión con la base de datos MySQL
/// Proporciona los parámetros de conexión y crea objetos de conexión
/// </summary>
public class Conexion
{
    // Constantes con los datos de configuración de la base de datos
    private const string servidor = "datasource=127.0.0.1";  // Dirección del servidor
    private const string puerto = "port=3306";               // Puerto de MySQL
    private const string username = "username=root";         // Usuario de la base de datos
    private const string password = "password=root";         // Contraseña del usuario
    private const string bd = "database=bdorquesta";         // Nombre de la base de datos

    // Cadena de conexión completa
    private String cadenaConexion;

    /// <summary>
    /// Constructor que inicializa la cadena de conexión
    /// </summary>
    public Conexion()
    {
        cadenaConexion = servidor + ";" + puerto + ";" + username
        + ";" + password + ";" + bd;
    }

    /// <summary>
    /// Método que crea y retorna una nueva conexión a la base de datos
    /// </summary>
    /// <returns>Objeto MySqlConnection listo para usar</returns>
    public MySqlConnection getConexion()
    {
        return new MySqlConnection(cadenaConexion);
    }
}