using System;

public class Asistencia
{
    public enum Tipo_Actividad
    {
        ensayo,
        clase_instrumento,
        clase_lenguaje,
        concierto
    }

    private int idActividad;
    private int idAlumno;
    private DateTime fecha;
    private bool presente;
    private Tipo_Actividad tipoActividad;

    public int IdActividad { get => idActividad; set => idActividad = value; }
    public int IdAlumno { get => idAlumno; set => idAlumno = value; }
    public DateTime Fecha { get => fecha; set => fecha = value; }
    public bool Presente { get => presente; set => presente = value; }
    public Tipo_Actividad TipoActividad { get => tipoActividad; set => tipoActividad = value; }
}
