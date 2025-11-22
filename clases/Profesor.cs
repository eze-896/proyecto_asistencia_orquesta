/// <summary>
/// Clase que representa a un profesor de la orquesta escuela
/// Contiene información personal y profesional del docente
/// </summary>
public class Profesor
{
    // Atributos
    private int id;
    private int dni;
    private string nombre;
    private string apellido;
    private string telefono;
    private string email;
    private int id_instrumento; // Instrumento que enseña el profesor

    // Getters y Setters
    public int Id { get => id; set => id = value; }
    public int Dni { get => dni; set => dni = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public string Apellido { get => apellido; set => apellido = value; }
    public string Telefono { get => telefono; set => telefono = value; }
    public string Email { get => email; set => email = value; }
    public int Id_instrumento { get => id_instrumento; set => id_instrumento = value; }
}