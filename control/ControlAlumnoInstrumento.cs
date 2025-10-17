public class ControlAlumnoInstrumento
{
    private ModeloAlumnoInstrumento modeloAlumnoInstrumento;

    public ControlAlumnoInstrumento()
    {
        modeloAlumnoInstrumento = new ModeloAlumnoInstrumento();
    }

    // Registrar relación nueva
    public bool RegistrarRelacion(int idAlumno, int idInstrumento)
    {
        AlumnoInstrumento relacion = new AlumnoInstrumento
        {
            IdAlumno = idAlumno,
            IdInstrumento = idInstrumento
        };

        return modeloAlumnoInstrumento.InsertarAlumnoInstrumento(relacion);
    }

    // Actualizar relación existente o insertar si no existe
    public bool ActualizarRelacion(int idAlumno, int idInstrumento)
    {
        AlumnoInstrumento relacion = new AlumnoInstrumento
        {
            IdAlumno = idAlumno,
            IdInstrumento = idInstrumento
        };

        return modeloAlumnoInstrumento.ActualizarAlumnoInstrumento(relacion);
    }

    // Obtener el instrumento actual de un alumno
    public int ObtenerInstrumentoPorAlumno(int idAlumno)
    {
        return modeloAlumnoInstrumento.ObtenerInstrumentoPorAlumno(idAlumno);
    }
}
