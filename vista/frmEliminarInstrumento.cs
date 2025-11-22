using GUI_Login.control;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GUI_Login.vista
{
    /// <summary>
    /// Formulario para eliminar instrumentos de la orquesta
    /// </summary>
    public partial class FrmEliminarInstrumento : Form
    {
        private readonly ControlInstrumento controlInstrumento;
        private List<Instrumento> listaInstrumentos;

        public FrmEliminarInstrumento()
        {
            InitializeComponent();
            controlInstrumento = new ControlInstrumento();
            listaInstrumentos = [];
        }

        private void FrmEliminarInstrumento_Load(object sender, EventArgs e)
        {
            CargarInstrumentos();
            this.KeyPreview = true;

            lstInstrumentos.TabStop = true;
            btnEliminar.TabStop = true;
            btnVolver.TabStop = true;
            btnSalir.TabStop = false; 
        }

        /// <summary>
        /// Carga los instrumentos que están actualmente en la orquesta
        /// </summary>
        private void CargarInstrumentos()
        {
            try
            {
                lstInstrumentos.Items.Clear();
                // Obtiene solo los instrumentos que están en la orquesta
                listaInstrumentos = controlInstrumento.ListarInstrumentosEnOrquesta();

                foreach (var instrumento in listaInstrumentos)
                {
                    lstInstrumentos.Items.Add($"{instrumento.Nombre} - {instrumento.Catedra}");
                }

                if (lstInstrumentos.Items.Count > 0)
                {
                    lstInstrumentos.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("No hay instrumentos en la orquesta para eliminar.",
                        "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los instrumentos: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Elimina el instrumento seleccionado con validaciones de uso
        /// Verifica que no esté asignado a profesores ni alumnos antes de eliminar
        /// </summary>
        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (lstInstrumentos.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un instrumento para eliminar de la orquesta.", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lstInstrumentos.Focus();
                return;
            }

            Instrumento seleccionado = listaInstrumentos[lstInstrumentos.SelectedIndex];

            // Verifica si el instrumento está siendo usado por algún profesor
            if (controlInstrumento.EstaInstrumentoEnUso(seleccionado.Id))
            {
                MessageBox.Show($"No se puede eliminar el instrumento '{seleccionado.Nombre}' porque está asignado a uno o más profesores.",
                    "No se puede eliminar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Verifica si el instrumento está siendo usado por algún alumno
            if (controlInstrumento.EstaInstrumentoEnUsoPorAlumnos(seleccionado.Id))
            {
                MessageBox.Show($"No se puede eliminar el instrumento '{seleccionado.Nombre}' porque está asignado a uno o más alumnos.",
                    "No se puede eliminar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Confirmacion de eliminar
            DialogResult resultado = MessageBox.Show(
                $"¿Está seguro de eliminar el instrumento '{seleccionado.Nombre}' de la orquesta?\n\n" +
                $"Cátedra: {seleccionado.Catedra}",
                "Confirmar Eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                try
                {
                    bool exito = controlInstrumento.EliminarInstrumentoDeOrquesta(seleccionado.Id);
                    if (exito)
                    {
                        MessageBox.Show("Instrumento eliminado de la orquesta correctamente.", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarInstrumentos(); // Recarga la lista después de eliminar
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar el instrumento de la orquesta.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar el instrumento: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Navegación y cierre
        private void BtnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmPrincipal formPrincipal = new();
            formPrincipal.Show();
        }

        /// <summary>
        /// Cierra la aplicación con confirmación
        /// </summary>
        private void BtnSalir_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "¿Está seguro que desea salir del sistema?",
                "Confirmar Salida",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        /// <summary>
        /// Maneja eventos de teclado para operaciones rápidas
        /// - Delete: Eliminar instrumento seleccionado
        /// - Escape: Volver al formulario principal
        /// - Enter: Eliminar instrumento seleccionado (cuando el ListBox tiene foco)
        /// </summary>
        private void LstInstrumentos_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Delete:
                    if (lstInstrumentos.SelectedIndex != -1)
                    {
                        BtnEliminar_Click(sender, e);
                        e.Handled = true;
                    }
                    break;
                case Keys.Escape:
                    BtnVolver_Click(sender, e);
                    e.Handled = true;
                    break;
                case Keys.Enter:
                    if (lstInstrumentos.Focused && lstInstrumentos.SelectedIndex != -1)
                    {
                        BtnEliminar_Click(sender, e);
                        e.Handled = true;
                    }
                    break;
                case Keys.Tab:
                    // Navegación natural con TAB ya está configurada en el diseñador
                    break;
            }
        }

        /// <summary>
        /// Maneja combinaciones de teclas especiales
        /// Previene el cierre accidental con Alt+F4
        /// </summary>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // Manejar Alt+F4 para prevenir el cierre accidental
            if (keyData == (Keys.Alt | Keys.F4))
            {
                BtnSalir_Click(this, EventArgs.Empty);
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}