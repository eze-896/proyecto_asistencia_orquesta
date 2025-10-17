using System.Data;
using System.Text.RegularExpressions;

public class ControlAlumno
{
    private ModeloAlumno modeloAlumno;

    public ControlAlumno()
    {
        modeloAlumno = new ModeloAlumno();
    }

    public int RegistrarAlumnoYObtenerId(Alumno alumno)
    {
        if (!ValidarAlumno(alumno)) return -1;
        return modeloAlumno.InsertarAlumno(alumno);
    }

    public bool ModificarAlumno(Alumno alumno)
    {
        if (!ValidarAlumno(alumno)) return false;
        return modeloAlumno.ActualizarAlumno(alumno);
    }

    public bool EliminarAlumno(int id)
    {
        if (id <= 0)
        {
            System.Windows.Forms.MessageBox.Show("Seleccione un alumno válido para eliminar.");
            return false;
        }
        return modeloAlumno.EliminarAlumno(id);
    }

    public DataTable ObtenerAlumnosparaGrid()
    {
        try
        {
            return modeloAlumno.ObtenerTablaAlumnos();
        }
        catch (Exception ex)
        {
            System.Windows.Forms.MessageBox.Show("Error en ObtenerAlumnosparaGrid: " + ex.Message);
            return new DataTable();
        }
    }

    public List<Alumno> ObtenerAlumnos()
    {
        return modeloAlumno.ObtenerAlumnosComoLista();
    }

    private bool ValidarAlumno(Alumno alumno)
    {
        if (alumno.Dni <= 0 || alumno.Dni.ToString().Length > 8)
        {
            System.Windows.Forms.MessageBox.Show("El DNI debe contener solo números y hasta 8 dígitos.");
            return false;
        }
        if (string.IsNullOrWhiteSpace(alumno.Telefono_padres) || alumno.Telefono_padres.Length > 15)
        {
            System.Windows.Forms.MessageBox.Show("El teléfono debe contener solo números y hasta 15 dígitos.");
            return false;
        }
        if (string.IsNullOrWhiteSpace(alumno.Nombre) || alumno.Nombre.Length > 25 || !Regex.IsMatch(alumno.Nombre, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$"))
        {
            System.Windows.Forms.MessageBox.Show("El nombre solo puede contener letras y hasta 25 caracteres.");
            return false;
        }
        if (string.IsNullOrWhiteSpace(alumno.Apellido) || alumno.Apellido.Length > 25 || !Regex.IsMatch(alumno.Apellido, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$"))
        {
            System.Windows.Forms.MessageBox.Show("El apellido solo puede contener letras y hasta 25 caracteres.");
            return false;
        }
        return true;
    }
}
