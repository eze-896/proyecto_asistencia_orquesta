using GUI_Login.modelo;
using System;
using System.Windows.Forms;

namespace GUI_Login.control
{
    /// <summary>
    /// Controlador para gestionar las relaciones entre alumnos e instrumentos
    /// Coordina las operaciones CRUD de la relación muchos a muchos entre alumnos e instrumentos
    /// </summary>
    public class ControlAlumnoInstrumento
    {
        private readonly ModeloAlumnoInstrumento modeloAlumnoInstrumento;

        /// <summary>
        /// Constructor que inicializa el modelo de datos para alumno-instrumento
        /// </summary>
        public ControlAlumnoInstrumento()
        {
            modeloAlumnoInstrumento = new ModeloAlumnoInstrumento();
        }

        /// <summary>
        /// Registra múltiples instrumentos para un alumno específico
        /// Permite que un alumno tenga varios instrumentos asignados
        /// </summary>
        /// idAlumno:ID del alumno a relacionar
        /// idsInstrumentos: Lista de IDs de instrumentos a asignar
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

        /// <summary>
        /// Actualiza una relación específica entre alumno e instrumento
        /// Si no existe la relación, la crea
        /// </summary>
        /// idAlumno: ID del alumno
        /// idInstrumento: ID del instrumento
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

        /// <summary>
        /// Actualiza todos los instrumentos de un alumno (reemplaza los existentes)
        /// </summary>
        /// idAlumno: ID del alumno
        /// idsInstrumentos: Nueva lista de IDs de instrumentos

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

        /// <summary>
        /// Elimina todas las relaciones de instrumentos para un alumno específico
        /// </summary>
        /// idAlumno: ID del alumno cuyas relaciones se eliminarán
        
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

        /// <summary>
        /// Obtiene todos los instrumentos asignados a un alumno específico
        /// </summary>
        /// idAlumno: ID del alumno a consultar
        /// Retorna Lista de IDs de instrumentos asignados al alumno
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