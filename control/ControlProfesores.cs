using System;
using System.Data;
using System.Text.RegularExpressions;

public class ControlProfesor
{
    private ModeloProfesor modeloProfesor;

    public ControlProfesor()
    {
        modeloProfesor = new ModeloProfesor();
    }

    // Registrar profesor con validaciones
    public bool RegistrarProfesor(Profesor profesor)
    {
        // DNI: solo números y máximo 8 dígitos
        if (profesor.Dni <= 0 || profesor.Dni.ToString().Length > 8)
        {
            System.Windows.Forms.MessageBox.Show("El DNI debe contener solo números y tener hasta 8 dígitos.");
            return false;
        }

        // Teléfono: máximo 25 caracteres
        if (string.IsNullOrEmpty(profesor.Telefono) || profesor.Telefono.Length > 25)
        {
            System.Windows.Forms.MessageBox.Show("El teléfono debe tener hasta 25 caracteres.");
            return false;
        }

        // Nombre
        if (string.IsNullOrEmpty(profesor.Nombre) || profesor.Nombre.Length > 25 ||
            !Regex.IsMatch(profesor.Nombre, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$"))
        {
            System.Windows.Forms.MessageBox.Show("El nombre solo puede contener letras y hasta 25 caracteres.");
            return false;
        }

        // Apellido
        if (string.IsNullOrEmpty(profesor.Apellido) || profesor.Apellido.Length > 25 ||
            !Regex.IsMatch(profesor.Apellido, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$"))
        {
            System.Windows.Forms.MessageBox.Show("El apellido solo puede contener letras y hasta 25 caracteres.");
            return false;
        }

        // Email
        if (string.IsNullOrEmpty(profesor.Email) || profesor.Email.Length > 50 ||
            !Regex.IsMatch(profesor.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
        {
            System.Windows.Forms.MessageBox.Show("El email no tiene un formato válido o excede los 50 caracteres.");
            return false;
        }

        // Guardar en BD
        return modeloProfesor.InsertarProfesor(profesor);
    }

    public System.Collections.Generic.List<Profesor> ObtenerProfesores()
    {
        return modeloProfesor.ListarProfesores();
    }

    public Profesor BuscarProfesor(int id)
    {
        return modeloProfesor.BuscarProfesor(id);
    }

    public bool ModificarProfesor(Profesor profesor)
    {
        return modeloProfesor.ModificarProfesor(profesor);
    }

    public bool EliminarProfesor(int id)
    {
        return modeloProfesor.EliminarProfesor(id);
    }

    // Cargar tabla en DataGridView
    public DataTable ObtenerProfesoresParaGrid()
    {
        try
        {
            return modeloProfesor.ObtenerTablaProfesores();
        }
        catch (Exception ex)
        {
            System.Windows.Forms.MessageBox.Show("Error al obtener datos de profesores: " + ex.Message);
            return new DataTable();
        }
    }
}
