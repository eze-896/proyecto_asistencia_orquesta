using GUI_Login.modelo;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GUI_Login.control
{
    /// <summary>
    /// Controlador para gestionar las relaciones entre alumnos e instrumentos
    /// </summary>
    public partial class ControlAlumnoInstrumento
    {
        private readonly ModeloAlumnoInstrumento modeloAlumnoInstrumento;

        /// <summary>
        /// Constructor que inicializa el modelo de relaciones alumno-instrumento
        /// </summary>
        public ControlAlumnoInstrumento()
        {
            modeloAlumnoInstrumento = new ModeloAlumnoInstrumento();
        }

        // ==================== OPERACIONES CRUD ====================

        /// <summary>
        /// Registra múltiples instrumentos para un alumno
        /// </summary>
        public bool RegistrarInstrumentosParaAlumno(int idAlumno, List<int> idsInstrumentos)
        {
            // Validar parámetros
            if (idAlumno <= 0)
            {
                MessageBox.Show("ID de alumno no válido.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (idsInstrumentos == null || idsInstrumentos.Count == 0)
            {
                MessageBox.Show("La lista de instrumentos no puede estar vacía.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            try
            {
                // Registrar instrumentos en la base de datos
                bool resultado = modeloAlumnoInstrumento.RegistrarInstrumentosParaAlumno(idAlumno, idsInstrumentos);
                if (!resultado)
                {
                    MessageBox.Show("Error al registrar los instrumentos para el alumno.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar instrumentos: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Actualiza la relación entre un alumno y un instrumento específico
        /// </summary>
        public bool ActualizarRelacion(int idAlumno, int idInstrumento)
        {
            // Validar parámetros
            if (idAlumno <= 0 || idInstrumento <= 0)
            {
                MessageBox.Show("ID de alumno o instrumento no válido.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            try
            {
                // Crear y actualizar relación en la base de datos
                AlumnoInstrumento relacion = new()
                {
                    IdAlumno = idAlumno,
                    IdInstrumento = idInstrumento
                };

                bool resultado = modeloAlumnoInstrumento.ActualizarAlumnoInstrumento(relacion);
                if (!resultado)
                {
                    MessageBox.Show("Error al actualizar la relación alumno-instrumento.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar relación: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Actualiza todos los instrumentos asociados a un alumno
        /// </summary>
        public bool ActualizarInstrumentosDeAlumno(int idAlumno, List<int> idsInstrumentos)
        {
            // Validar parámetros
            if (idAlumno <= 0)
            {
                MessageBox.Show("ID de alumno no válido.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (idsInstrumentos == null || idsInstrumentos.Count == 0)
            {
                MessageBox.Show("La lista de instrumentos no puede estar vacía.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            try
            {
                // Actualizar instrumentos en la base de datos
                bool resultado = modeloAlumnoInstrumento.ActualizarInstrumentosDeAlumno(idAlumno, idsInstrumentos);
                if (!resultado)
                {
                    MessageBox.Show("Error al actualizar los instrumentos del alumno.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar instrumentos: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Elimina todas las relaciones de instrumentos para un alumno
        /// </summary>
        public bool EliminarRelacionPorAlumno(int idAlumno)
        {
            // Validar ID de alumno
            if (idAlumno <= 0)
            {
                MessageBox.Show("ID de alumno no válido.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            try
            {
                // Eliminar relaciones en la base de datos
                bool resultado = modeloAlumnoInstrumento.EliminarRelacionPorAlumno(idAlumno);
                if (!resultado)
                {
                    MessageBox.Show("Error al eliminar las relaciones del alumno.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar relación alumno-instrumento: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // ==================== CONSULTAS ====================

        /// <summary>
        /// Obtiene los IDs de los instrumentos asociados a un alumno
        /// </summary>
        public List<int> ObtenerInstrumentosPorAlumno(int idAlumno)
        {
            // Validar ID de alumno
            if (idAlumno <= 0)
            {
                MessageBox.Show("ID de alumno no válido.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return new List<int>();
            }

            try
            {
                return modeloAlumnoInstrumento.ObtenerInstrumentosPorAlumno(idAlumno);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener instrumentos del alumno: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<int>();
            }
        }
    }
}