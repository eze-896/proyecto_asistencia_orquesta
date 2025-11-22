/// <summary>
/// Clase que representa a un alumno de la orquesta escuela
/// </summary>
public class Alumno
{
    // Atributos
    private int id;
    private int dni;
    private string nombre;
    private string apellido;
    private string telefono_padres;

    // Getters y Setters
    public int Id { get => id; set => id = value; }
    public int Dni { get => dni; set => dni = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public string Apellido { get => apellido; set => apellido = value; }
    public string Telefono_padres { get => telefono_padres; set => telefono_padres = value; }
}