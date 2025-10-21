using System;
using System.Windows.Forms;

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
        try
        {
            AlumnoInstrumento relacion = new AlumnoInstrumento
            {
                IdAlumno = idAlumno,
                IdInstrumento = idInstrumento
            };

            bool resultado = modeloAlumnoInstrumento.InsertarAlumnoInstrumento(relacion);

            if (!resultado)
            {
                MessageBox.Show("Error al registrar la relación alumno-instrumento.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return resultado;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error inesperado al registrar relación: {ex.Message}",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
    }

    // Actualizar relación existente o insertar si no existe
    public bool ActualizarRelacion(int idAlumno, int idInstrumento)
    {
        try
        {
            AlumnoInstrumento relacion = new AlumnoInstrumento
            {
                IdAlumno = idAlumno,
                IdInstrumento = idInstrumento
            };

            bool resultado = modeloAlumnoInstrumento.ActualizarAlumnoInstrumento(relacion);

            if (!resultado)
            {
                MessageBox.Show("Error al actualizar la relación alumno-instrumento.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return resultado;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error inesperado al actualizar relación: {ex.Message}",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
    }

    // Eliminar relación por alumno
    public bool EliminarRelacionPorAlumno(int idAlumno)
    {
        try
        {
            return modeloAlumnoInstrumento.EliminarRelacionPorAlumno(idAlumno);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al eliminar relación alumno-instrumento: {ex.Message}",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
    }

    // Obtener el instrumento actual de un alumno
    public int ObtenerInstrumentoPorAlumno(int idAlumno)
    {
        try
        {
            return modeloAlumnoInstrumento.ObtenerInstrumentoPorAlumno(idAlumno);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al obtener instrumento del alumno: {ex.Message}",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return -1;
        }
    }
}