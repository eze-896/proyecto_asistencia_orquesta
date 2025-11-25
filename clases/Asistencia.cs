/// <summary>
/// Clase que registra la asistencia de alumnos a diferentes actividades
/// Lleva control de presencia/ausencia en eventos del orquesta
/// </summary>
public class Asistencia
{
    /// <summary>
    /// Enum que define los tipos de actividades disponibles en el sistema
    /// </summary>
    public enum Tipo_Actividad
    {
        ensayo,
        clase_instrumento, // Clase individual de instrumento
        clase_lenguaje,   // Clase de lenguaje musical
        concierto
    }

    // Atributos
    private int idActividad;
    private int idAlumno;
    private DateTime fecha;
    private bool presente;           // True = presente, False = ausente
    private Tipo_Actividad tipoActividad;

    // Getters y Setters
    public int IdActividad { get => idActividad; set => idActividad = value; }
    public int IdAlumno { get => idAlumno; set => idAlumno = value; }
    public DateTime Fecha { get => fecha; set => fecha = value; }
    public bool Presente { get => presente; set => presente = value; }
    public Tipo_Actividad TipoActividad { get => tipoActividad; set => tipoActividad = value; }
}