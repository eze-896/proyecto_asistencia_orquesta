using GUI_Login.modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace GUI_Login.control
{
    public partial class ControlProfesor
    {
        [GeneratedRegex(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$")]
        private static partial Regex SoloLetrasRegex();

        [GeneratedRegex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$")]
        private static partial Regex EmailRegex();

        private readonly ModeloProfesor modeloProfesor;

        public ControlProfesor()
        {
            modeloProfesor = new ModeloProfesor();
        }

        // ==================== OPERACIONES CRUD ====================

        /// <summary>
        /// Registra un nuevo profesor en el sistema después de validar los datos
        /// </summary>
        public bool RegistrarProfesor(Profesor profesor)
        {
            // Validar datos del profesor
            if (!ValidarProfesor(profesor))
                return false;

            // Verificar que no exista otro profesor con los mismos datos únicos
            if (modeloProfesor.ExisteDni(profesor.Dni, 0))
            {
                MessageBox.Show($"Ya existe un profesor con el DNI {profesor.Dni}.", "DNI Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (modeloProfesor.ExisteEmail(profesor.Email, 0))
            {
                MessageBox.Show($"Ya existe un profesor con el email {profesor.Email}.", "Email Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (modeloProfesor.ExisteTelefono(profesor.Telefono, 0))
            {
                MessageBox.Show($"Ya existe un profesor con el teléfono {profesor.Telefono}.", "Teléfono Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            try
            {
                // Insertar profesor en la base de datos
                bool resultado = modeloProfesor.InsertarProfesor(profesor);
                if (resultado)
                {
                    MessageBox.Show("Profesor registrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error al registrar el profesor en la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar profesor: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Modifica los datos de un profesor existente
        /// </summary>
        public bool ModificarProfesor(Profesor profesor)
        {
            // Validar datos del profesor
            if (!ValidarProfesor(profesor))
                return false;

            // Verificar ID válido
            if (profesor.Id <= 0)
            {
                MessageBox.Show("ID de profesor no válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Solicitar confirmación antes de modificar
            DialogResult confirmacion = MessageBox.Show(
                "¿Está seguro que desea modificar los datos del profesor?",
                "Confirmar Modificación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmacion != DialogResult.Yes)
                return false;

            // Verificar que no exista otro profesor con los mismos datos únicos (excluyendo el actual)
            if (modeloProfesor.ExisteDni(profesor.Dni, profesor.Id))
            {
                MessageBox.Show($"Ya existe un profesor con el DNI {profesor.Dni}.", "DNI Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (modeloProfesor.ExisteEmail(profesor.Email, profesor.Id))
            {
                MessageBox.Show($"Ya existe un profesor con el email {profesor.Email}.", "Email Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (modeloProfesor.ExisteTelefono(profesor.Telefono, profesor.Id))
            {
                MessageBox.Show($"Ya existe un profesor con el teléfono {profesor.Telefono}.", "Teléfono Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            try
            {
                // Actualizar profesor en la base de datos
                bool resultado = modeloProfesor.ModificarProfesor(profesor);
                if (resultado)
                {
                    MessageBox.Show("Profesor modificado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error al modificar el profesor en la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al modificar profesor: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Elimina un profesor del sistema
        /// </summary>
        public bool EliminarProfesor(int id)
        {
            // Validar ID
            if (id <= 0)
            {
                MessageBox.Show("Seleccione un profesor válido para eliminar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Buscar profesor para mostrar su nombre en la confirmación
            Profesor? profesor = modeloProfesor.BuscarProfesor(id);
            if (profesor == null)
            {
                MessageBox.Show("No se encontró el profesor a eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Solicitar confirmación antes de eliminar
            DialogResult resultado = MessageBox.Show(
                $"¿Está seguro de eliminar a {profesor.Nombre} {profesor.Apellido}?",
                "Confirmar Eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado != DialogResult.Yes)
                return false;

            try
            {
                // Eliminar profesor de la base de datos
                bool eliminado = modeloProfesor.EliminarProfesor(id);
                if (eliminado)
                {
                    MessageBox.Show("Profesor eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error al eliminar el profesor de la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return eliminado;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar profesor: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // ==================== VALIDACIONES ====================

        /// <summary>
        /// Valida todos los datos de un profesor
        /// </summary>
        public static bool ValidarProfesor(Profesor profesor)
        {
            // Validar campos obligatorios
            if (string.IsNullOrWhiteSpace(profesor.Nombre) || string.IsNullOrWhiteSpace(profesor.Apellido) ||
                profesor.Dni <= 0 || string.IsNullOrWhiteSpace(profesor.Telefono) ||
                string.IsNullOrWhiteSpace(profesor.Email) || profesor.Id_instrumento <= 0)
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Validar formato del DNI (7-8 dígitos)
            string dniStr = profesor.Dni.ToString();
            if (dniStr.Length < 7 || dniStr.Length > 8)
            {
                MessageBox.Show("El DNI debe tener entre 7 y 8 dígitos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Validar teléfono (solo números, 8-15 dígitos)
            if (!long.TryParse(profesor.Telefono, out _) || profesor.Telefono.Length > 15 || profesor.Telefono.Length < 8)
            {
                MessageBox.Show("El teléfono debe contener solo números y entre 8 y 15 dígitos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Validar nombre (solo letras, máximo 25 caracteres)
            if (profesor.Nombre.Length > 25 || !SoloLetrasRegex().IsMatch(profesor.Nombre))
            {
                MessageBox.Show("El nombre solo puede contener letras y hasta 25 caracteres.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Validar apellido (solo letras, máximo 25 caracteres)
            if (profesor.Apellido.Length > 25 || !SoloLetrasRegex().IsMatch(profesor.Apellido))
            {
                MessageBox.Show("El apellido solo puede contener letras y hasta 25 caracteres.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Validar formato de email
            if (profesor.Email.Length > 50 || !EmailRegex().IsMatch(profesor.Email))
            {
                MessageBox.Show("El email no tiene un formato válido o excede los 50 caracteres.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Validar instrumento seleccionado
            if (profesor.Id_instrumento <= 0)
            {
                MessageBox.Show("Debe seleccionar un instrumento válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        // ==================== CONSULTAS ====================

        /// <summary>
        /// Obtiene la lista completa de profesores
        /// </summary>
        public List<Profesor> ObtenerProfesores()
        {
            try
            {
                return modeloProfesor.ListarProfesores();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener la lista de profesores: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return [];
            }
        }

        /// <summary>
        /// Busca un profesor por su ID
        /// </summary>
        public Profesor? BuscarProfesor(int id)
        {
            try
            {
                return modeloProfesor.BuscarProfesor(id);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar el profesor: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Obtiene los profesores en formato DataTable para mostrar en grids
        /// </summary>
        public DataTable ObtenerProfesoresParaGrid()
        {
            try
            {
                return modeloProfesor.ObtenerTablaProfesores();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los profesores: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new DataTable();
            }
        }
    }
}