using GUI_Login.modelo;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GUI_Login.control
{
    /// <summary>
    /// Controlador para gestionar las operaciones relacionadas con instrumentos
    /// </summary>
    public class ControlInstrumento
    {
        private readonly ModeloInstrumento modeloInstrumento;

        /// <summary>
        /// Constructor que inicializa el modelo de instrumentos
        /// </summary>
        public ControlInstrumento()
        {
            modeloInstrumento = new ModeloInstrumento();
        }

        // ==================== OPERACIONES CRUD ====================

        /// <summary>
        /// Elimina un instrumento de la orquesta con validaciones completas
        /// </summary>
        public bool EliminarInstrumentoDeOrquesta(int idInstrumento, string nombreInstrumento = "")
        {
            // Validar ID del instrumento
            if (idInstrumento <= 0)
            {
                MessageBox.Show("ID de instrumento no válido.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            try
            {
                // Verificar si el instrumento está siendo usado por profesores
                if (modeloInstrumento.EstaInstrumentoEnUso(idInstrumento))
                {
                    MessageBox.Show($"No se puede eliminar el instrumento '{nombreInstrumento}' porque está asignado a uno o más profesores.",
                        "No se puede eliminar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                // Verificar si el instrumento está siendo usado por alumnos
                if (modeloInstrumento.EstaInstrumentoEnUsoPorAlumnos(idInstrumento))
                {
                    MessageBox.Show($"No se puede eliminar el instrumento '{nombreInstrumento}' porque está asignado a uno o más alumnos.",
                        "No se puede eliminar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                // Solicitar confirmación antes de eliminar
                DialogResult resultado = MessageBox.Show(
                    $"¿Está seguro de eliminar el instrumento '{nombreInstrumento}' de la orquesta?",
                    "Confirmar Eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (resultado != DialogResult.Yes)
                    return false;

                // Ejecutar eliminación en la base de datos
                bool exito = modeloInstrumento.EliminarInstrumentoOrquesta(idInstrumento);
                if (exito)
                {
                    MessageBox.Show("Instrumento eliminado de la orquesta correctamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el instrumento de la orquesta.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return exito;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar instrumento: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Agrega un instrumento a la orquesta después de validar el ID
        /// </summary>
        public bool AgregarInstrumentoAOrquesta(int idInstrumento)
        {
            // Validar ID del instrumento
            if (idInstrumento <= 0)
            {
                MessageBox.Show("ID de instrumento no válido.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            try
            {
                // Ejecutar inserción en la base de datos
                bool resultado = modeloInstrumento.AgregarInstrumentoOrquesta(idInstrumento);
                if (!resultado)
                {
                    MessageBox.Show("No se pudo agregar el instrumento a la orquesta.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                // Manejo específico para el error de duplicado
                if (ex.Message.Contains("ya está en la orquesta"))
                {
                    MessageBox.Show(ex.Message, "Advertencia",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show($"Error al agregar instrumento: {ex.Message}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return false;
            }
        }

        // ==================== CONSULTAS DE LISTADOS ====================

        /// <summary>
        /// Obtiene la lista de instrumentos que actualmente están en la orquesta
        /// </summary>
        public List<Instrumento> ListarInstrumentosEnOrquesta()
        {
            try
            {
                return modeloInstrumento.ListarInstrumentosOrquesta();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener instrumentos de la orquesta: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Instrumento>();
            }
        }

        /// <summary>
        /// Obtiene la lista de instrumentos disponibles para agregar a la orquesta
        /// </summary>
        public List<Instrumento> ListarInstrumentosDisponibles()
        {
            try
            {
                return modeloInstrumento.ListarInstrumentosDisponibles();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener instrumentos disponibles: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Instrumento>();
            }
        }
    }
}