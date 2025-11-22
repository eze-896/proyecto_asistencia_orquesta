/// <summary>
/// Clase que representa la relación entre alumnos e instrumentos
/// Funciona como tabla intermedia para la relación muchos a muchos
/// </summary>
public class AlumnoInstrumento
{
    // Atributos
    private int idAlumno;
    private int idInstrumento;

    // Getters y Setters
    public int IdAlumno { get => idAlumno; set => idAlumno = value; }
    public int IdInstrumento { get => idInstrumento; set => idInstrumento = value; }
}