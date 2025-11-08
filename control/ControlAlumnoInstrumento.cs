using GUI_Login.modelo;
using System;
using System.Windows.Forms;

namespace GUI_Login.control
{
    public class ControlAlumnoInstrumento
    {
        private readonly ModeloAlumnoInstrumento modeloAlumnoInstrumento;

        public ControlAlumnoInstrumento()
        {
            modeloAlumnoInstrumento = new ModeloAlumnoInstrumento();
        }

        // Registrar relación nueva
        public bool RegistrarInstrumentosParaAlumno(int idAlumno, List<int> idsInstrumentos)
        {
            try
            {
                return modeloAlumnoInstrumento.RegistrarInstrumentosParaAlumno(idAlumno, idsInstrumentos);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado al registrar instrumentos: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Actualizar relación existente o insertar si no existe
        public bool ActualizarRelacion(int idAlumno, int idInstrumento)
        {
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
                MessageBox.Show($"Error inesperado al actualizar relación: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool ActualizarInstrumentosDeAlumno(int idAlumno, List<int> idsInstrumentos)
        {
            try
            {
                return modeloAlumnoInstrumento.ActualizarInstrumentosDeAlumno(idAlumno, idsInstrumentos);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado al actualizar instrumentos: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Eliminar relación por alumno
        public bool EliminarRelacionPorAlumno(int idAlumno)
        {
            try
            {
                return modeloAlumnoInstrumento.EliminarRelacionPorAlumno(idAlumno);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar relación alumno-instrumento: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Obtener el instrumento actual de un alumno
        public List<int> ObtenerInstrumentosPorAlumno(int idAlumno)
        {
            try
            {
                return modeloAlumnoInstrumento.ObtenerInstrumentosPorAlumno(idAlumno);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener instrumentos del alumno: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return [];
            }
        }
    }
}