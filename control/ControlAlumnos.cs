using System;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;

public class ControlAlumno
{
    private ModeloAlumno modeloAlumno;
    private ControlAlumnoInstrumento controlAlumnoInstrumento;

    public ControlAlumno()
    {
        modeloAlumno = new ModeloAlumno();
        controlAlumnoInstrumento = new ControlAlumnoInstrumento();
    }

    // Registrar alumno con instrumento
    public bool RegistrarAlumnoConInstrumento(Alumno alumno, int idInstrumento)
    {
        if (!ValidarAlumno(alumno))
            return false;

        try
        {
            int idAlumno = modeloAlumno.InsertarAlumno(alumno);
            if (idAlumno > 0)
            {
                bool relacionInsertada = controlAlumnoInstrumento.RegistrarRelacion(idAlumno, idInstrumento);
                if (relacionInsertada)
                {
                    MessageBox.Show("Alumno registrado correctamente junto a su instrumento.",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    // Rollback: eliminar alumno si falla la relación
                    modeloAlumno.EliminarAlumno(idAlumno);
                    MessageBox.Show("Error al asociar el instrumento al alumno.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Error al registrar el alumno en la base de datos.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error inesperado al registrar alumno: {ex.Message}",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
    }

    // Modificar alumno con instrumento
    public bool ModificarAlumnoConInstrumento(Alumno alumno, int idInstrumento)
    {
        if (!ValidarAlumno(alumno))
            return false;

        if (alumno.Id <= 0)
        {
            MessageBox.Show("ID de alumno no válido.",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        try
        {
            bool alumnoModificado = modeloAlumno.ActualizarAlumno(alumno);
            bool relActualizada = controlAlumnoInstrumento.ActualizarRelacion(alumno.Id, idInstrumento);

            if (alumnoModificado && relActualizada)
            {
                MessageBox.Show("Alumno y su instrumento modificados correctamente.",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            else
            {
                MessageBox.Show("Error al modificar el alumno o su instrumento.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error inesperado al modificar alumno: {ex.Message}",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
    }

    // Eliminar alumno
    public bool EliminarAlumno(int id)
    {
        if (id <= 0)
        {
            MessageBox.Show("Seleccione un alumno válido para eliminar.",
                "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        try
        {
            // Primero eliminar la relación con instrumentos
            bool relacionEliminada = controlAlumnoInstrumento.EliminarRelacionPorAlumno(id);

            // Luego eliminar el alumno
            bool alumnoEliminado = modeloAlumno.EliminarAlumno(id);

            if (alumnoEliminado)
            {
                MessageBox.Show("Alumno eliminado correctamente.",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            else
            {
                MessageBox.Show("Error al eliminar el alumno de la base de datos.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error inesperado al eliminar alumno: {ex.Message}",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
    }

    // Obtener datos para grid
    public DataTable ObtenerAlumnosParaGrid()
    {
        try
        {
            return modeloAlumno.ObtenerTablaAlumnos();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al cargar los alumnos: {ex.Message}",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return new DataTable();
        }
    }

    // Obtener lista de alumnos
    public List<Alumno> ObtenerAlumnos()
    {
        try
        {
            return modeloAlumno.ObtenerAlumnosComoLista();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al obtener la lista de alumnos: {ex.Message}",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return new List<Alumno>();
        }
    }

    // Obtener instrumento actual de un alumno
    public int ObtenerInstrumentoPorAlumno(int idAlumno)
    {
        try
        {
            return controlAlumnoInstrumento.ObtenerInstrumentoPorAlumno(idAlumno);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al obtener el instrumento del alumno: {ex.Message}",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return -1;
        }
    }

    // Validaciones
    private bool ValidarAlumno(Alumno alumno)
    {
        // Validar DNI
        if (alumno.Dni <= 0 || alumno.Dni.ToString().Length > 8)
        {
            MessageBox.Show("El DNI debe contener solo números y hasta 8 dígitos.",
                "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        // Validar teléfono
        if (string.IsNullOrWhiteSpace(alumno.Telefono_padres) || alumno.Telefono_padres.Length > 15)
        {
            MessageBox.Show("El teléfono debe contener solo números y hasta 15 dígitos.",
                "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        // Validar nombre
        if (string.IsNullOrWhiteSpace(alumno.Nombre) || alumno.Nombre.Length > 25 || !Regex.IsMatch(alumno.Nombre, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$"))
        {
            MessageBox.Show("El nombre solo puede contener letras y hasta 25 caracteres.",
                "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        // Validar apellido
        if (string.IsNullOrWhiteSpace(alumno.Apellido) || alumno.Apellido.Length > 25 || !Regex.IsMatch(alumno.Apellido, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$"))
        {
            MessageBox.Show("El apellido solo puede contener letras y hasta 25 caracteres.",
                "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        return true;
    }

    // Validar campos obligatorios para formulario
    public bool ValidarCamposObligatorios(string nombre, string apellido, string dni, string telefono, int? idInstrumento)
    {
        if (string.IsNullOrWhiteSpace(nombre) ||
            string.IsNullOrWhiteSpace(apellido) ||
            string.IsNullOrWhiteSpace(dni) ||
            string.IsNullOrWhiteSpace(telefono) ||
            idInstrumento == null || idInstrumento <= 0)
        {
            MessageBox.Show("Todos los campos son obligatorios.",
                "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        // Validar formato DNI
        if (!int.TryParse(dni, out int dniNum) || dniNum <= 0)
        {
            MessageBox.Show("El DNI debe ser un número válido.",
                "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        // Validar formato teléfono
        if (!long.TryParse(telefono, out _))
        {
            MessageBox.Show("El teléfono debe ser un número válido.",
                "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        return true;
    }
}