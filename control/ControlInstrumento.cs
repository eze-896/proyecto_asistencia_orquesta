using GUI_Login.modelo;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GUI_Login.control
{
    public class ControlInstrumento
    {
        private readonly ModeloInstrumento modeloInstrumento;

        public ControlInstrumento()
        {
            modeloInstrumento = new ModeloInstrumento();
        }

        // ==================== OPERACIONES CRUD ====================

        public bool EliminarInstrumentoDeOrquesta(int idInstrumento)
        {
            if (!ValidarIdInstrumento(idInstrumento))
                return false;

            try
            {
                bool resultado = modeloInstrumento.EliminarInstrumentoOrquesta(idInstrumento);
                if (!resultado)
                {
                    MessageBox.Show("No se pudo eliminar el instrumento de la orquesta.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar instrumento: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool AgregarInstrumentoAOrquesta(int idInstrumento)
        {
            if (!ValidarIdInstrumento(idInstrumento))
                return false;

            try
            {
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
                // CORREGIDO: Manejo específico para el error de duplicado
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

        // ==================== VALIDACIONES DE USO ====================

        public bool EstaInstrumentoEnUso(int idInstrumento)
        {
            if (!ValidarIdInstrumento(idInstrumento))
                return true;

            try
            {
                return modeloInstrumento.EstaInstrumentoEnUso(idInstrumento);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al verificar uso del instrumento: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
        }

        public bool EstaInstrumentoEnUsoPorAlumnos(int idInstrumento)
        {
            if (!ValidarIdInstrumento(idInstrumento))
                return true;

            try
            {
                return modeloInstrumento.EstaInstrumentoEnUsoPorAlumnos(idInstrumento);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al verificar uso del instrumento por alumnos: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
        }

        // ==================== CONSULTAS ====================

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

        // ==================== MÉTODOS AUXILIARES ====================

        private bool ValidarIdInstrumento(int idInstrumento)
        {
            if (idInstrumento <= 0)
            {
                MessageBox.Show("ID de instrumento no válido.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
    }
}