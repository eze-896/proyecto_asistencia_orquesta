using GUI_Login.modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace GUI_Login.control
{
    /// <summary>
    /// Controlador principal para la gestión de alumnos
    /// Coordina todas las operaciones CRUD de alumnos y sus relaciones con instrumentos
    /// </summary>
    public partial class ControlAlumno
    {
        // Usar GeneratedRegexAttribute para mejor rendimiento
        [GeneratedRegex(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$")]
        private static partial Regex SoloLetrasRegex();

        [GeneratedRegex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$")]
        private static partial Regex EmailRegex();

        private readonly ModeloAlumno modeloAlumno;
        private readonly ControlAlumnoInstrumento controlAlumnoInstrumento;

        /// <summary>
        /// Constructor que inicializa los modelos de alumno y alumno-instrumento
        /// </summary>
        public ControlAlumno()
        {
            modeloAlumno = new ModeloAlumno();
            controlAlumnoInstrumento = new ControlAlumnoInstrumento();
        }

        // ==================== OPERACIONES CRUD ====================

        /// <summary>
        /// Registra un nuevo alumno junto con sus instrumentos asignados
        /// Realiza una transacción: si falla la inserción de instrumentos, hace rollback
        /// </summary>
        /// <param name="alumno">Objeto Alumno con los datos personales</param>
        /// <param name="idsInstrumentos">Lista de instrumentos que toca el alumno</param>
        /// <returns>True si el registro fue exitoso</returns>
        public bool RegistrarAlumnoConInstrumentos(Alumno alumno, List<int> idsInstrumentos)
        {
            if (!ValidarAlumno(alumno))
                return false;

            // Validar unicidad antes de registrar
            if (!ValidarUnicidadAlumno(alumno))
                return false;

            try
            {
                int idAlumno = modeloAlumno.InsertarAlumno(alumno);
                if (idAlumno > 0)
                {
                    bool relacionesInsertadas = controlAlumnoInstrumento.RegistrarInstrumentosParaAlumno(idAlumno, idsInstrumentos);
                    if (relacionesInsertadas)
                    {
                        MessageBox.Show("Alumno registrado correctamente junto a sus instrumentos.",
                            "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;
                    }
                    else
                    {
                        // Rollback: eliminar alumno si fallan las relaciones
                        modeloAlumno.EliminarAlumno(idAlumno);
                        MessageBox.Show("Error al asociar los instrumentos al alumno.",
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

        /// <summary>
        /// Modifica los datos de un alumno existente y actualiza sus instrumentos
        /// </summary>
        /// <param name="alumno">Objeto Alumno con los datos actualizados</param>
        /// <param name="idsInstrumentos">Nueva lista de instrumentos del alumno</param>
        /// <returns>True si la modificación fue exitosa</returns>
        public bool ModificarAlumnoConInstrumentos(Alumno alumno, List<int> idsInstrumentos)
        {
            if (!ValidarAlumno(alumno))
                return false;

            if (alumno.Id <= 0)
            {
                MessageBox.Show("ID de alumno no válido.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Validar unicidad excluyendo el alumno actual
            if (!ValidarUnicidadAlumno(alumno, alumno.Id))
                return false;

            try
            {
                bool alumnoModificado = modeloAlumno.ActualizarAlumno(alumno);
                bool instrumentosActualizados = controlAlumnoInstrumento.ActualizarInstrumentosDeAlumno(alumno.Id, idsInstrumentos);

                if (alumnoModificado && instrumentosActualizados)
                {
                    MessageBox.Show("Alumno y sus instrumentos modificados correctamente.",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    MessageBox.Show("Error al modificar el alumno o sus instrumentos.",
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

        /// <summary>
        /// Elimina un alumno y todas sus relaciones con instrumentos
        /// Primero elimina las relaciones para evitar errores de clave foránea
        /// </summary>
        /// <param name="id">ID del alumno a eliminar</param>
        /// <returns>True si la eliminación fue exitosa</returns>
        public bool EliminarAlumno(int id)
        {
            if (id <= 0)
            {
                MessageBox.Show("Seleccione un alumno válido para eliminar.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Diálogo de confirmación
            if (!ConfirmarEliminacionAlumno(id))
                return false;

            try
            {
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

        // ==================== CONSULTAS Y OBTENCIÓN DE DATOS ====================

        /// <summary>
        /// Obtiene todos los alumnos en formato DataTable para mostrar en GridView
        /// </summary>
        /// <returns>DataTable con los datos de todos los alumnos</returns>
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

        /// <summary>
        /// Obtiene todos los alumnos como lista de objetos
        /// </summary>
        /// <returns>Lista de objetos Alumno</returns>
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

        /// <summary>
        /// Busca un alumno específico por su ID
        /// </summary>
        /// <param name="id">ID del alumno a buscar</param>
        /// <returns>Objeto Alumno si se encuentra, null si no existe</returns>
        public Alumno? BuscarAlumno(int id)
        {
            try
            {
                return modeloAlumno.BuscarAlumno(id);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar el alumno: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Obtiene los instrumentos asignados a un alumno específico
        /// </summary>
        /// <param name="idAlumno">ID del alumno a consultar</param>
        /// <returns>Lista de IDs de instrumentos del alumno</returns>
        public List<int> ObtenerInstrumentosPorAlumno(int idAlumno)
        {
            try
            {
                return controlAlumnoInstrumento.ObtenerInstrumentosPorAlumno(idAlumno);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener los instrumentos del alumno: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<int>();
            }
        }

        // ==================== VALIDACIONES ====================

        /// <summary>
        /// Valida los datos de un alumno
        /// </summary>
        /// <param name="alumno">Objeto Alumno a validar (opcional)</param>
        /// <param name="nombre">Nombre del alumno (opcional si se pasa objeto)</param>
        /// <param name="apellido">Apellido del alumno (opcional si se pasa objeto)</param>
        /// <param name="dni">DNI como string o int (opcional si se pasa objeto)</param>
        /// <param name="telefono">Teléfono como string (opcional si se pasa objeto)</param>
        /// <returns>True si todos los datos son válidos</returns>
        public static bool ValidarAlumno(Alumno? alumno = null, string? nombre = null, string? apellido = null,
                                       object? dni = null, string? telefono = null)
        {
            // Si se pasa un objeto Alumno, extraer los valores
            if (alumno != null)
            {
                nombre = alumno.Nombre;
                apellido = alumno.Apellido;
                dni = alumno.Dni;
                telefono = alumno.Telefono_padres;
            }

            // Validar campos obligatorios
            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(apellido) ||
                dni == null || string.IsNullOrWhiteSpace(telefono))
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
                    return MostrarValidacion("El DNI debe contener solo números y hasta 8 dígitos.");
            }
            else
            {
                return MostrarValidacion("Formato de DNI no válido.");
            }

            // Validar teléfono
            if (!long.TryParse(telefono, out _) || telefono.Length > 15)
                return MostrarValidacion("El teléfono debe contener solo números y hasta 15 dígitos.");

            // Usar métodos generados de regex
            if (nombre.Length > 25 || !SoloLetrasRegex().IsMatch(nombre))
                return MostrarValidacion("El nombre solo puede contener letras y hasta 25 caracteres.");

            if (apellido.Length > 25 || !SoloLetrasRegex().IsMatch(apellido))
                return MostrarValidacion("El apellido solo puede contener letras y hasta 25 caracteres.");

            return true;
        }

        /// <summary>
        /// Valida la unicidad de DNI y teléfono para un alumno
        /// </summary>
        /// <param name="alumno">Alumno a validar</param>
        /// <param name="idExcluir">ID a excluir (para modificaciones)</param>
        /// <returns>True si todos los datos son únicos</returns>
        private bool ValidarUnicidadAlumno(Alumno alumno, int idExcluir = 0)
        {
            try
            {
                // Verificar DNI único
                if (modeloAlumno.ExisteDni(alumno.Dni, idExcluir))
                {
                    MessageBox.Show($"Ya existe un alumno con el DNI {alumno.Dni}.",
                        "DNI Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                // Verificar Teléfono único
                if (modeloAlumno.ExisteTelefono(alumno.Telefono_padres, idExcluir))
                {
                    MessageBox.Show($"Ya existe un alumno con el teléfono {alumno.Telefono_padres}.",
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
        /// Muestra un diálogo de confirmación antes de eliminar un alumno
        /// </summary>
        /// <param name="idAlumno">ID del alumno a eliminar</param>
        /// <returns>True si el usuario confirma la eliminación</returns>
        private bool ConfirmarEliminacionAlumno(int idAlumno)
        {
            Alumno? alumno = BuscarAlumno(idAlumno);
            if (alumno == null)
                return false;

            DialogResult resultado = MessageBox.Show(
                $"¿Está seguro de eliminar a {alumno.Nombre} {alumno.Apellido}?",
                "Confirmar Eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            return resultado == DialogResult.Yes;
        }

        /// <summary>
        /// Muestra un diálogo de confirmación antes de modificar un alumno
        /// </summary>
        /// <returns>True si el usuario confirma la modificación</returns>
        public static bool ConfirmarModificacion()
        {
            DialogResult resultado = MessageBox.Show(
                "¿Está seguro que desea modificar los datos del alumno?",
                "Confirmar Modificación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            return resultado == DialogResult.Yes;
        }
    }
}