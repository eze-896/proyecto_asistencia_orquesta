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
                // CORREGIDO: Ahora captura excepciones del Modelo
                MessageBox.Show($"Error al registrar profesor: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

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
                // CORREGIDO: Ahora captura excepciones del Modelo
                MessageBox.Show($"Error al modificar profesor: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

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
                // CORREGIDO: Ahora captura excepciones del Modelo
                MessageBox.Show($"Error al eliminar profesor: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // ==================== VALIDACIONES MEJORADAS ====================

        public static bool ValidarProfesor(Profesor? profesor = null, string? nombre = null, string? apellido = null,
                                          object? dni = null, string? telefono = null, string? email = null,
                                          int? idInstrumento = null)
        {
            if (profesor != null)
            {
                nombre = profesor.Nombre;
                apellido = profesor.Apellido;
                dni = profesor.Dni;
                telefono = profesor.Telefono;
                email = profesor.Email;
                idInstrumento = profesor.Id_instrumento;
            }

            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(apellido) ||
                dni == null || string.IsNullOrWhiteSpace(telefono) || string.IsNullOrWhiteSpace(email) ||
                idInstrumento == null || idInstrumento <= 0)
            {
                return MostrarValidacion("Todos los campos son obligatorios.");
            }

            int dniNum;
            if (dni is string dniString)
            {
                if (!int.TryParse(dniString, out dniNum) || dniNum <= 0)
                    return MostrarValidacion("El DNI debe ser un número válido.");
            }
            else if (dni is int dniInt)
            {
                dniNum = dniInt;
            }
            else
            {
                return MostrarValidacion("Formato de DNI no válido.");
            }

            // CORREGIDO: Mejor validación de DNI (ejemplo para Argentina)
            string dniStr = dniNum.ToString();
            if (dniStr.Length < 7 || dniStr.Length > 8)
                return MostrarValidacion("El DNI debe tener entre 7 y 8 dígitos.");

            // CORREGIDO: Mejor validación de teléfono
            if (!long.TryParse(telefono, out _) || telefono.Length > 15 || telefono.Length < 8)
                return MostrarValidacion("El teléfono debe contener solo números y entre 8 y 15 dígitos.");

            if (nombre.Length > 25 || !SoloLetrasRegex().IsMatch(nombre))
                return MostrarValidacion("El nombre solo puede contener letras y hasta 25 caracteres.");

            if (apellido.Length > 25 || !SoloLetrasRegex().IsMatch(apellido))
                return MostrarValidacion("El apellido solo puede contener letras y hasta 25 caracteres.");

            // CORREGIDO: Mejor validación de email
            if (email.Length > 50 || !EmailRegex().IsMatch(email))
                return MostrarValidacion("El email no tiene un formato válido o excede los 50 caracteres.");

            if (idInstrumento <= 0)
                return MostrarValidacion("Debe seleccionar un instrumento válido.");

            return true;
        }

        // ==================== CONSULTAS Y OBTENCIÓN DE DATOS ====================

        public List<Profesor> ObtenerProfesores()
        {
            try
            {
                return modeloProfesor.ListarProfesores();
            }
            catch (Exception ex)
            {
                // CORREGIDO: Ahora captura excepciones del Modelo
                MessageBox.Show($"Error al obtener la lista de profesores: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return [];
            }
        }

        public Profesor? BuscarProfesor(int id)
        {
            try
            {
                return modeloProfesor.BuscarProfesor(id);
            }
            catch (Exception ex)
            {
                // CORREGIDO: Ahora captura excepciones del Modelo
                MessageBox.Show($"Error al buscar el profesor: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable ObtenerProfesoresParaGrid()
        {
            try
            {
                return modeloProfesor.ObtenerTablaProfesores();
            }
            catch (Exception ex)
            {
                // CORREGIDO: Ahora captura excepciones del Modelo
                MessageBox.Show($"Error al cargar los profesores: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new DataTable();
            }
        }

        // ==================== MÉTODOS AUXILIARES ====================

        private static bool MostrarValidacion(string mensaje)
        {
            MessageBox.Show(mensaje, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        private bool ValidarUnicidadProfesor(Profesor profesor, int idExcluir = 0)
        {
            try
            {
                if (modeloProfesor.ExisteDni(profesor.Dni, idExcluir))
                {
                    MessageBox.Show($"Ya existe un profesor con el DNI {profesor.Dni}.",
                        "DNI Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (modeloProfesor.ExisteEmail(profesor.Email, idExcluir))
                {
                    MessageBox.Show($"Ya existe un profesor con el email {profesor.Email}.",
                        "Email Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

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

        // ==================== DIÁLOGOS DE CONFIRMACIÓN ====================

        public static bool ConfirmarEliminacion(string nombre, string apellido)
        {
            DialogResult resultado = MessageBox.Show(
                $"¿Está seguro de eliminar a {nombre} {apellido}?",
                "Confirmar Eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            return resultado == DialogResult.Yes;
        }

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