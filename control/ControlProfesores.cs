using GUI_Login.modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace GUI_Login.control
{
    /// <summary>
    /// Controlador para la gestión de profesores
    /// Coordina todas las operaciones CRUD de profesores con validaciones completas
    /// </summary>
    public partial class ControlProfesor
    {
        // Usar GeneratedRegexAttribute para mejor rendimiento
        [GeneratedRegex(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$")]
        private static partial Regex SoloLetrasRegex();

        [GeneratedRegex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$")]
        private static partial Regex EmailRegex();

        private readonly ModeloProfesor modeloProfesor;

        /// <summary>
        /// Constructor que inicializa el modelo de profesores
        /// </summary>
        public ControlProfesor()
        {
            modeloProfesor = new ModeloProfesor();
        }

        // ==================== OPERACIONES CRUD ====================

        /// <summary>
        /// Registra un nuevo profesor con validaciones completas de datos
        /// </summary>
        /// <param name="profesor">Objeto Profesor con los datos a registrar</param>
        /// <returns>True si el registro fue exitoso</returns>
        public bool RegistrarProfesor(Profesor profesor)
        {
            if (!ValidarProfesor(profesor))
                return false;

            if (!ValidarUnicidadProfesor(profesor))
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

        /// <summary>
        /// Modifica los datos de un profesor existente
        /// </summary>
        /// <param name="profesor">Objeto Profesor con los datos actualizados</param>
        /// <returns>True si la modificación fue exitosa</returns>
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

            if (!ValidarUnicidadProfesor(profesor, profesor.Id))
                return false;

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

        /// <summary>
        /// Elimina un profesor de la base de datos
        /// </summary>
        /// <param name="id">ID del profesor a eliminar</param>
        /// <returns>True si la eliminación fue exitosa</returns>
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

        // ==================== CONSULTAS Y OBTENCIÓN DE DATOS ====================

        /// <summary>
        /// Obtiene la lista completa de profesores
        /// </summary>
        /// <returns>Lista de objetos Profesor</returns>
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
                return [];
            }
        }

        /// <summary>
        /// Busca un profesor específico por su ID
        /// </summary>
        /// <param name="id">ID del profesor a buscar</param>
        /// <returns>Objeto Profesor si se encuentra, null si no existe</returns>
        public Profesor? BuscarProfesor(int id)
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

        /// <summary>
        /// Obtiene los profesores en formato DataTable para mostrar en GridView
        /// </summary>
        /// <returns>DataTable con los datos de todos los profesores</returns>
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

        // ==================== VALIDACIONES ====================

        /// <summary>
        /// Valida los datos de un profesor, ya sea desde objeto o desde campos individuales
        /// </summary>
        /// <param name="profesor">Objeto Profesor a validar (opcional)</param>
        /// <param name="nombre">Nombre del profesor (opcional si se pasa objeto)</param>
        /// <param name="apellido">Apellido del profesor (opcional si se pasa objeto)</param>
        /// <param name="dni">DNI como string o int (opcional si se pasa objeto)</param>
        /// <param name="telefono">Teléfono como string (opcional si se pasa objeto)</param>
        /// <param name="email">Email del profesor (opcional si se pasa objeto)</param>
        /// <param name="idInstrumento">ID del instrumento (opcional si se pasa objeto)</param>
        /// <returns>True si todos los datos son válidos</returns>
        public static bool ValidarProfesor(Profesor? profesor = null, string? nombre = null, string? apellido = null,
                                          object? dni = null, string? telefono = null, string? email = null,
                                          int? idInstrumento = null)
        {
            // Si se pasa un objeto Profesor, extraer los valores
            if (profesor != null)
            {
                nombre = profesor.Nombre;
                apellido = profesor.Apellido;
                dni = profesor.Dni;
                telefono = profesor.Telefono;
                email = profesor.Email;
                idInstrumento = profesor.Id_instrumento;
            }

            // Manejo de valores nulos
            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(apellido) ||
                dni == null || string.IsNullOrWhiteSpace(telefono) || string.IsNullOrWhiteSpace(email) ||
                idInstrumento == null || idInstrumento <= 0)
            {
                return MostrarValidacion("Todos los campos son obligatorios.");
            }

            // Convertir y validar DNI
            int dniNum;
            if (dni is string dniString)
            {
                if (!int.TryParse(dniString, out dniNum) || dniNum <= 0)
                    return MostrarValidacion("El DNI debe ser un número válido.");
            }
            else if (dni is int dniInt)
            {
                dniNum = dniInt;
                if (dniNum <= 0 || dniNum.ToString().Length > 8)
                    return MostrarValidacion("El DNI debe contener solo números y tener hasta 8 dígitos.");
            }
            else
            {
                return MostrarValidacion("Formato de DNI no válido.");
            }

            // Usar los métodos generados
            if (telefono.Length > 25)
                return MostrarValidacion("El teléfono debe tener hasta 25 caracteres.");

            // Validar nombre y apellido (solo letras)
            if (nombre.Length > 25 || !SoloLetrasRegex().IsMatch(nombre))
                return MostrarValidacion("El nombre solo puede contener letras y hasta 25 caracteres.");

            if (apellido.Length > 25 || !SoloLetrasRegex().IsMatch(apellido))
                return MostrarValidacion("El apellido solo puede contener letras y hasta 25 caracteres.");

            // Validar email
            if (email.Length > 50 || !EmailRegex().IsMatch(email))
                return MostrarValidacion("El email no tiene un formato válido o excede los 50 caracteres.");

            // Validar instrumento
            if (idInstrumento <= 0)
                return MostrarValidacion("Debe seleccionar un instrumento válido.");

            return true;
        }

        /// <summary>
        /// Valida la unicidad de DNI, email y teléfono para un profesor
        /// </summary>
        /// <param name="profesor">Profesor a validar</param>
        /// <param name="idExcluir">ID a excluir (para modificaciones)</param>
        /// <returns>True si todos los datos son únicos</returns>
        private bool ValidarUnicidadProfesor(Profesor profesor, int idExcluir = 0)
        {
            try
            {
                // Verificar DNI único
                if (modeloProfesor.ExisteDni(profesor.Dni, idExcluir))
                {
                    MessageBox.Show($"Ya existe un profesor con el DNI {profesor.Dni}.",
                        "DNI Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                // Verificar Email único
                if (modeloProfesor.ExisteEmail(profesor.Email, idExcluir))
                {
                    MessageBox.Show($"Ya existe un profesor con el email {profesor.Email}.",
                        "Email Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                // Verificar Teléfono único
                if (modeloProfesor.ExisteTelefono(profesor.Telefono, idExcluir))
                {
                    MessageBox.Show($"Ya existe un profesor con el teléfono {profesor.Telefono}.",
                        "Teléfono Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al validar unicidad: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // ==================== MÉTODOS AUXILIARES ====================

        /// <summary>
        /// Muestra mensaje de validación estandarizado
        /// </summary>
        /// <param name="mensaje">Mensaje a mostrar</param>
        /// <returns>Siempre retorna false para facilitar el return en validaciones</returns>
        private static bool MostrarValidacion(string mensaje)
        {
            MessageBox.Show(mensaje, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        // ==================== DIÁLOGOS DE CONFIRMACIÓN ====================

        /// <summary>
        /// Muestra un diálogo de confirmación antes de eliminar un profesor
        /// </summary>
        /// <param name="nombre">Nombre del profesor</param>
        /// <param name="apellido">Apellido del profesor</param>
        /// <returns>True si el usuario confirma la eliminación</returns>
        public static bool ConfirmarEliminacion(string nombre, string apellido)
        {
            DialogResult resultado = MessageBox.Show(
                $"¿Está seguro de eliminar a {nombre} {apellido}?",
                "Confirmar Eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            return resultado == DialogResult.Yes;
        }

        /// <summary>
        /// Muestra un diálogo de confirmación antes de modificar un profesor
        /// </summary>
        /// <returns>True si el usuario confirma la modificación</returns>
        public static bool ConfirmarModificacion()
        {
            DialogResult resultado = MessageBox.Show(
                "¿Está seguro que desea modificar los datos del profesor?",
                "Confirmar Modificación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            return resultado == DialogResult.Yes;
        }
    }
}