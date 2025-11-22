using GUI_Login.control;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GUI_Login.vista
{
    public partial class frmAgregarInstrumentos : Form
    {
        private readonly ControlInstrumento controlInstrumento;

        public frmAgregarInstrumentos()
        {
            InitializeComponent();
            controlInstrumento = new ControlInstrumento();
        }

        private void FrmAgregarInstrumentos_Load(object sender, EventArgs e)
        {
            CargarComboInstrumentos();
            this.KeyPreview = true;
        }

        private void CargarComboInstrumentos()
        {
            try
            {
                List<Instrumento> instrumentos = controlInstrumento.ListarInstrumentosDisponibles();
                cmbInstrumento.DataSource = null;
                cmbInstrumento.DataSource = instrumentos;
                cmbInstrumento.DisplayMember = "Nombre";
                cmbInstrumento.ValueMember = "Id";
                cmbInstrumento.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                // CORREGIDO: Ahora captura excepciones del Controlador
                MessageBox.Show($"Error al cargar los instrumentos: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            if (!ValidarSeleccionInstrumento())
                return;

            if (cmbInstrumento.SelectedValue is int idInstrumento)
            {
                EjecutarInsercion(idInstrumento);
            }
            else
            {
                MessageBox.Show("No se pudo obtener el ID del instrumento seleccionado.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarSeleccionInstrumento()
        {
            if (cmbInstrumento.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un instrumento", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbInstrumento.Focus();
                return false;
            }
            return true;
        }

        private void EjecutarInsercion(int idInstrumento)
        {
            try
            {
                bool insertado = controlInstrumento.AgregarInstrumentoAOrquesta(idInstrumento);

                if (insertado)
                {
                    MessageBox.Show("Instrumento agregado a la orquesta correctamente.",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarComboInstrumentos();
                }
                else
                {
                    MessageBox.Show("No se pudo agregar el instrumento. Puede que ya esté en la orquesta.",
                        "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                // CORREGIDO: Ahora captura excepciones del Controlador
                MessageBox.Show($"Error al agregar el instrumento: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Los métodos de navegación permanecen igual...
        private void BtnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmPrincipal formPrincipal = new FrmPrincipal();
            formPrincipal.Show();
        }

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

        private void FrmAgregarInstrumentos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                BtnVolver_Click(sender, e);
            else if (e.KeyCode == Keys.F4 && e.Alt)
                BtnSalir_Click(sender, e);
        }
    }
}