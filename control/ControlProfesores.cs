using System;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;

public class ControlProfesor
{
    private ModeloProfesor modeloProfesor;

    public ControlProfesor()
    {
        modeloProfesor = new ModeloProfesor();
    }

    // Registrar profesor con validaciones completas
    public bool RegistrarProfesor(Profesor profesor)
    {
        if (!ValidarProfesor(profesor))
            return false;

        try
        {
            bool resultado = modeloProfesor.InsertarProfesor(profesor);
            if (resultado)
            {
                MessageBox.Show("Profesor registrado correctamente.",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error al registrar el profesor en la base de datos.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return resultado;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error inesperado al registrar profesor: {ex.Message}",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
    }

    // Modificar profesor con validaciones
    public bool ModificarProfesor(Profesor profesor)
    {
        if (!ValidarProfesor(profesor))
            return false;

        if (profesor.Id <= 0)
        {
            MessageBox.Show("ID de profesor no válido.",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        try
        {
            bool resultado = modeloProfesor.ModificarProfesor(profesor);
            if (resultado)
            {
                MessageBox.Show("Profesor modificado correctamente.",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error al modificar el profesor en la base de datos.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return resultado;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error inesperado al modificar profesor: {ex.Message}",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
    }

    // Eliminar profesor
    public bool EliminarProfesor(int id)
    {
        if (id <= 0)
        {
            MessageBox.Show("Seleccione un profesor válido para eliminar.",
                "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        try
        {
            bool resultado = modeloProfesor.EliminarProfesor(id);
            if (resultado)
            {
                MessageBox.Show("Profesor eliminado correctamente.",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error al eliminar el profesor de la base de datos.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return resultado;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error inesperado al eliminar profesor: {ex.Message}",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
    }

    // Obtener lista de profesores
    public List<Profesor> ObtenerProfesores()
    {
        try
        {
            return modeloProfesor.ListarProfesores();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al obtener la lista de profesores: {ex.Message}",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return new List<Profesor>();
        }
    }

    // Buscar profesor por ID
    public Profesor BuscarProfesor(int id)
    {
        try
        {
            return modeloProfesor.BuscarProfesor(id);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al buscar el profesor: {ex.Message}",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return null;
        }
    }

    // Obtener datos para grid
    public DataTable ObtenerProfesoresParaGrid()
    {
        try
        {
            return modeloProfesor.ObtenerTablaProfesores();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al cargar los profesores: {ex.Message}",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return new DataTable();
        }
    }

    // Validaciones completas del profesor
    private bool ValidarProfesor(Profesor profesor)
    {
        // Validar DNI
        if (profesor.Dni <= 0 || profesor.Dni.ToString().Length > 8)
        {
            MessageBox.Show("El DNI debe contener solo números y tener hasta 8 dígitos.",
                "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        // Validar teléfono
        if (string.IsNullOrWhiteSpace(profesor.Telefono) || profesor.Telefono.Length > 25)
        {
            MessageBox.Show("El teléfono debe tener hasta 25 caracteres.",
                "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        // Validar nombre
        if (string.IsNullOrWhiteSpace(profesor.Nombre) || profesor.Nombre.Length > 25 ||
            !Regex.IsMatch(profesor.Nombre, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$"))
        {
            MessageBox.Show("El nombre solo puede contener letras y hasta 25 caracteres.",
                "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        // Validar apellido
        if (string.IsNullOrWhiteSpace(profesor.Apellido) || profesor.Apellido.Length > 25 ||
            !Regex.IsMatch(profesor.Apellido, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$"))
        {
            MessageBox.Show("El apellido solo puede contener letras y hasta 25 caracteres.",
                "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        // Validar email
        if (string.IsNullOrWhiteSpace(profesor.Email) || profesor.Email.Length > 50 ||
            !Regex.IsMatch(profesor.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
        {
            MessageBox.Show("El email no tiene un formato válido o excede los 50 caracteres.",
                "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        // Validar instrumento
        if (profesor.Id_instrumento <= 0)
        {
            MessageBox.Show("Debe seleccionar un instrumento válido.",
                "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        return true;
    }

    // Validar campos obligatorios para formulario
    public bool ValidarCamposObligatorios(string nombre, string apellido, string dni, string telefono, string email, int? idInstrumento)
    {
        if (string.IsNullOrWhiteSpace(nombre) ||
            string.IsNullOrWhiteSpace(apellido) ||
            string.IsNullOrWhiteSpace(dni) ||
            string.IsNullOrWhiteSpace(telefono) ||
            string.IsNullOrWhiteSpace(email) ||
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

        // Validar formato email básico
        if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
        {
            MessageBox.Show("El email no tiene un formato válido.",
                "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        return true;
    }

    // Confirmar eliminación
    public bool ConfirmarEliminacion(string nombre, string apellido)
    {
        DialogResult resultado = MessageBox.Show(
            $"¿Está seguro de eliminar a {nombre} {apellido}?",
            "Confirmar Eliminación",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

        return resultado == DialogResult.Yes;
    }

    // Confirmar modificación
    public bool ConfirmarModificacion()
    {
        DialogResult resultado = MessageBox.Show(
            "¿Está seguro que desea modificar los datos del profesor?",
            "Confirmar Modificación",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

        return resultado == DialogResult.Yes;
    }
}