using GUI_Login.modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace GUI_Login.control
{
    public class ControlAsistencia
    {
        private readonly ModeloAsistencia modeloAsistencia;

        public ControlAsistencia()
        {
            modeloAsistencia = new ModeloAsistencia();
        }

        // ==================== CONSULTAS ====================

        public List<Alumno> ObtenerAlumnos()
        {
            try
            {
                return modeloAsistencia.ListarAlumnos();
            }
            catch (Exception ex)
            {
                // CORREGIDO: Ahora captura excepciones del Modelo
                MessageBox.Show($"Error al obtener lista de alumnos: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Alumno>();
            }
        }

        public DataTable ObtenerDatosParaGrid()
        {
            try
            {
                return modeloAsistencia.ObtenerTablaAsistencia();
            }
            catch (Exception ex)
            {
                // CORREGIDO: Ahora captura excepciones del Modelo
                MessageBox.Show($"Error al obtener datos para grid: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new DataTable();
            }
        }

        // ==================== OPERACIONES PRINCIPALES ====================

        public bool GuardarAsistencias(List<Asistencia> asistencias)
        {
            if (asistencias == null || asistencias.Count == 0)
            {
                MessageBox.Show("La lista de asistencias está vacía.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            bool todosGuardados = true;
            int errores = 0;

            foreach (Asistencia a in asistencias)
            {
                try
                {
                    // CORREGIDO: Validación directa sin método separado
                    if (a == null || !ValidarAsistenciaDirectamente(a))
                    {
                        errores++;
                        todosGuardados = false;
                        continue;
                    }

                    bool ok = modeloAsistencia.MarcarAsistencia(a);
                    if (!ok)
                    {
                        errores++;
                        todosGuardados = false;
                    }
                }
                catch (Exception ex)
                {
                    // CORREGIDO: Ahora captura excepciones del Modelo
                    MessageBox.Show($"Error guardando asistencia para alumno ID {a?.IdAlumno}: {ex.Message}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    errores++;
                    todosGuardados = false;
                }
            }

            if (errores > 0)
            {
                MessageBox.Show($"Se produjeron {errores} errores al guardar las asistencias.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return todosGuardados;
        }

        // ==================== VALIDACIONES ====================

        /// <summary>
        /// Validación directa sin método separado redundante
        /// </summary>
        private static bool ValidarAsistenciaDirectamente(Asistencia asistencia)
        {
            if (asistencia.IdAlumno <= 0)
            {
                MessageBox.Show("ID de alumno no válido.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (asistencia.Fecha == DateTime.MinValue)
            {
                MessageBox.Show("Fecha de asistencia no válida.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!Enum.IsDefined(typeof(Asistencia.Tipo_Actividad), asistencia.TipoActividad))
            {
                MessageBox.Show("Tipo de actividad no válido.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
    }
}