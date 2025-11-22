using GUI_Login.modelo;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GUI_Login.control
{
    public partial class ControlAlumnoInstrumento
    {
        private readonly ModeloAlumnoInstrumento modeloAlumnoInstrumento;

        public ControlAlumnoInstrumento()
        {
            modeloAlumnoInstrumento = new ModeloAlumnoInstrumento();
        }

        // ==================== OPERACIONES CRUD ====================

        public bool RegistrarInstrumentosParaAlumno(int idAlumno, List<int> idsInstrumentos)
        {
            if (!ValidarParametros(idAlumno, idsInstrumentos))
                return false;

            try
            {
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
                // CORREGIDO: Ahora captura excepciones del Modelo
                MessageBox.Show($"Error al registrar instrumentos: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool ActualizarRelacion(int idAlumno, int idInstrumento)
        {
            if (!ValidarParametros(idAlumno, idInstrumento))
                return false;

            try
            {
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
                // CORREGIDO: Ahora captura excepciones del Modelo
                MessageBox.Show($"Error al actualizar relación: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool ActualizarInstrumentosDeAlumno(int idAlumno, List<int> idsInstrumentos)
        {
            if (!ValidarParametros(idAlumno, idsInstrumentos))
                return false;

            try
            {
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
                // CORREGIDO: Ahora captura excepciones del Modelo
                MessageBox.Show($"Error al actualizar instrumentos: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool EliminarRelacionPorAlumno(int idAlumno)
        {
            if (idAlumno <= 0)
            {
                MessageBox.Show("ID de alumno no válido.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            try
            {
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
                // CORREGIDO: Ahora captura excepciones del Modelo
                MessageBox.Show($"Error al eliminar relación alumno-instrumento: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // ==================== CONSULTAS ====================

        public List<int> ObtenerInstrumentosPorAlumno(int idAlumno)
        {
            if (idAlumno <= 0)
            {
                MessageBox.Show("ID de alumno no válido.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return new List<int>();
            }

            try
            {
                return modeloAlumnoInstrumento.ObtenerInstrumentosPorAlumno(idAlumno);
            }
            catch (Exception ex)
            {
                // CORREGIDO: Ahora captura excepciones del Modelo
                MessageBox.Show($"Error al obtener instrumentos del alumno: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<int>();
            }
        }

        // ==================== VALIDACIONES MEJORADAS ====================

        /// <summary>
        /// Valida los parámetros para operaciones con un solo instrumento
        /// </summary>
        private bool ValidarParametros(int idAlumno, int idInstrumento)
        {
            if (idAlumno <= 0)
            {
                MessageBox.Show("ID de alumno no válido.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (idInstrumento <= 0)
            {
                MessageBox.Show("ID de instrumento no válido.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Valida los parámetros para operaciones con múltiples instrumentos
        /// </summary>
        private bool ValidarParametros(int idAlumno, List<int> idsInstrumentos)
        {
            if (idAlumno <= 0)
            {
                MessageBox.Show("ID de alumno no válido.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (idsInstrumentos == null || idsInstrumentos.Count == 0)
            {
                MessageBox.Show("La lista de instrumentos no puede estar vacía.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // CORREGIDO: Validación más robusta usando LINQ
            if (idsInstrumentos.Exists(id => id <= 0))
            {
                MessageBox.Show("La lista contiene IDs de instrumento no válidos.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
    }
}