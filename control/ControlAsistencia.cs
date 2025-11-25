using GUI_Login.modelo;
using System.Data;

namespace GUI_Login.control
{
    /// <summary>
    /// Controlador para gestionar las operaciones relacionadas con asistencias
    /// </summary>
    public class ControlAsistencia
    {
        private readonly ModeloAsistencia modeloAsistencia;

        /// <summary>
        /// Constructor que inicializa el modelo de asistencias
        /// </summary>
        public ControlAsistencia()
        {
            modeloAsistencia = new ModeloAsistencia();
        }

        // ==================== CONSULTAS ====================

        /// <summary>
        /// Obtiene la lista completa de alumnos del sistema
        /// </summary>
        public List<Alumno> ObtenerAlumnos()
        {
            try
            {
                return modeloAsistencia.ListarAlumnos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener lista de alumnos: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Alumno>();
            }
        }

        /// <summary>
        /// Obtiene los datos de asistencia en formato DataTable para mostrar en grids
        /// </summary>
        public DataTable ObtenerDatosParaGrid()
        {
            try
            {
                return modeloAsistencia.ObtenerTablaAsistencia();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener datos para grid: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new DataTable();
            }
        }

        // ==================== OPERACIONES PRINCIPALES ====================

        /// <summary>
        /// Guarda una lista de asistencias en la base de datos
        /// </summary>
        public bool GuardarAsistencias(List<Asistencia> asistencias)
        {
            // Validar lista de asistencias
            if (asistencias == null || asistencias.Count == 0)
            {
                MessageBox.Show("La lista de asistencias está vacía.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            bool todosGuardados = true;
            int errores = 0;

            // Procesar cada asistencia individualmente
            foreach (Asistencia a in asistencias)
            {
                try
                {
                    if (a == null || a.IdAlumno <= 0 || a.Fecha == DateTime.MinValue ||
                        a.Fecha > DateTime.Now.Date ||
                        !Enum.IsDefined(typeof(Asistencia.Tipo_Actividad), a.TipoActividad))
                    {
                        errores++;
                        todosGuardados = false;
                        continue;
                    }

                    // Guardar asistencia en la base de datos
                    bool ok = modeloAsistencia.MarcarAsistencia(a);
                    if (!ok)
                    {
                        errores++;
                        todosGuardados = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error guardando asistencia para alumno ID {a?.IdAlumno}: {ex.Message}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    errores++;
                    todosGuardados = false;
                }
            }

            // Mostrar resumen de errores si los hubo
            if (errores > 0)
            {
                MessageBox.Show($"Se produjeron {errores} errores al guardar las asistencias.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return todosGuardados;
        }
    }
}