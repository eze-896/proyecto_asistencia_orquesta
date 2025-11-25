using GUI_Login.modelo;
using System.Data;
using System.Text.RegularExpressions;

namespace GUI_Login.control
{
    public partial class ControlAlumno
    {
        [GeneratedRegex(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$")]
        private static partial Regex SoloLetrasRegex();

        private readonly ModeloAlumno modeloAlumno;
        private readonly ControlAlumnoInstrumento controlAlumnoInstrumento;

        /// <summary>
        /// Constructor que inicializa los modelos necesarios
        /// </summary>
        public ControlAlumno()
        {
            modeloAlumno = new ModeloAlumno();
            controlAlumnoInstrumento = new ControlAlumnoInstrumento();
        }

        // ==================== OPERACIONES CRUD ====================

        /// <summary>
        /// Registra un nuevo alumno junto con sus instrumentos asociados
        /// </summary>
        public bool RegistrarAlumnoConInstrumentos(Alumno alumno, List<int> idsInstrumentos)
        {
            // Validar datos del alumno
            if (!ValidarAlumno(alumno))
                return false;

            // Verificar que no exista otro alumno con los mismos datos únicos
            if (modeloAlumno.ExisteDni(alumno.Dni, 0))
            {
                MessageBox.Show($"Ya existe un alumno con el DNI {alumno.Dni}.", "DNI Duplicado",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (modeloAlumno.ExisteTelefono(alumno.Telefono_padres, 0))
            {
                MessageBox.Show($"Ya existe un alumno con el teléfono {alumno.Telefono_padres}.", "Teléfono Duplicado",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            try
            {
                // Insertar alumno en la base de datos
                int idAlumno = modeloAlumno.InsertarAlumno(alumno);
                if (idAlumno > 0)
                {
                    // Asociar instrumentos al alumno
                    bool relacionesInsertadas = controlAlumnoInstrumento.RegistrarInstrumentosParaAlumno(idAlumno, idsInstrumentos);
                    if (relacionesInsertadas)
                    {
                        MessageBox.Show("Alumno registrado correctamente junto a sus instrumentos.",
                            "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;
                    }
                    else
                    {
                        // Revertir inserción si falla la asociación de instrumentos
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
                MessageBox.Show($"Error al registrar alumno: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Modifica los datos de un alumno existente y sus instrumentos asociados
        /// </summary>
        public bool ModificarAlumnoConInstrumentos(Alumno alumno, List<int> idsInstrumentos)
        {
            // Validar datos del alumno
            if (!ValidarAlumno(alumno))
                return false;

            // Verificar ID válido
            if (alumno.Id <= 0)
            {
                MessageBox.Show("ID de alumno no válido.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Solicitar confirmación antes de modificar
            DialogResult confirmacion = MessageBox.Show(
                "¿Está seguro que desea modificar los datos del alumno?",
                "Confirmar Modificación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmacion != DialogResult.Yes)
                return false;

            // Verificar que no exista otro alumno con los mismos datos únicos
            if (modeloAlumno.ExisteDni(alumno.Dni, alumno.Id))
            {
                MessageBox.Show($"Ya existe un alumno con el DNI {alumno.Dni}.", "DNI Duplicado",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (modeloAlumno.ExisteTelefono(alumno.Telefono_padres, alumno.Id))
            {
                MessageBox.Show($"Ya existe un alumno con el teléfono {alumno.Telefono_padres}.", "Teléfono Duplicado",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            try
            {
                // Actualizar alumno y sus instrumentos
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
                MessageBox.Show($"Error al modificar alumno: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Elimina un alumno del sistema con confirmación previa
        /// </summary>
        public bool EliminarAlumno(int id)
        {
            // Validar ID
            if (id <= 0)
            {
                MessageBox.Show("Seleccione un alumno válido para eliminar.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Buscar alumno para mostrar su nombre en la confirmación
            Alumno? alumno = modeloAlumno.BuscarAlumno(id);
            if (alumno == null)
            {
                MessageBox.Show("No se encontró el alumno a eliminar.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Solicitar confirmación antes de eliminar
            DialogResult resultado = MessageBox.Show(
                $"¿Está seguro de eliminar a {alumno.Nombre} {alumno.Apellido}?",
                "Confirmar Eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado != DialogResult.Yes)
                return false;

            try
            {
                // Eliminar alumno de la base de datos
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
                MessageBox.Show($"Error al eliminar alumno: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // ==================== VALIDACIONES ====================

        /// <summary>
        /// Valida todos los datos de un alumno
        /// </summary>
        public static bool ValidarAlumno(Alumno alumno)
        {
            // Validar campos obligatorios
            if (string.IsNullOrWhiteSpace(alumno.Nombre) || string.IsNullOrWhiteSpace(alumno.Apellido) ||
                alumno.Dni <= 0 || string.IsNullOrWhiteSpace(alumno.Telefono_padres))
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Validar formato del DNI (7-8 dígitos)
            string dniStr = alumno.Dni.ToString();
            if (dniStr.Length < 7 || dniStr.Length > 8)
            {
                MessageBox.Show("El DNI debe tener entre 7 y 8 dígitos.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Validar teléfono (solo números, 8-15 dígitos)
            if (!long.TryParse(alumno.Telefono_padres, out _) || alumno.Telefono_padres.Length > 15 || alumno.Telefono_padres.Length < 8)
            {
                MessageBox.Show("El teléfono debe contener solo números y entre 8 y 15 dígitos.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Validar nombre (solo letras, máximo 25 caracteres)
            if (alumno.Nombre.Length > 25 || !SoloLetrasRegex().IsMatch(alumno.Nombre))
            {
                MessageBox.Show("El nombre solo puede contener letras y hasta 25 caracteres.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Validar apellido (solo letras, máximo 25 caracteres)
            if (alumno.Apellido.Length > 25 || !SoloLetrasRegex().IsMatch(alumno.Apellido))
            {
                MessageBox.Show("El apellido solo puede contener letras y hasta 25 caracteres.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        // ==================== CONSULTAS ====================

        /// <summary>
        /// Obtiene los alumnos en formato DataTable para mostrar en grids
        /// </summary>
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
        /// Obtiene la lista completa de alumnos
        /// </summary>
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
        /// Busca un alumno por su ID
        /// </summary>
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
        /// Obtiene los IDs de los instrumentos asociados a un alumno
        /// </summary>
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
    }
}