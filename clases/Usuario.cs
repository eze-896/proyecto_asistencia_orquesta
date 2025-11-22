/// <summary>
/// Clase que representa un usuario(preceptor de la orquesta escuela)
/// Maneja la información de autenticación y acceso
/// </summary>
class Usuario
{
    // Atributos para el control de acceso al sistema
    private int id;           // Identificador único del usuario
    private string contrasena; // Contraseña para autenticación
    private string nombre;     // Nombre del usuario para mostrar

    // Getters y Setters
    public int Id { get => id; set => id = value; }
    public string Contrasena { get => contrasena; set => contrasena = value; }
    public string Nombre { get => nombre; set => nombre = value; }
}