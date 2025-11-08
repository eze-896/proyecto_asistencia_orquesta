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
                MessageBox.Show($"Error al cargar los instrumentos: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            if (cmbInstrumento.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un instrumento", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (cmbInstrumento.SelectedValue is int idInstrumento)
                {
                    bool insertado = controlInstrumento.AgregarInstrumentoAOrquesta(idInstrumento);

                    if (insertado)
                    {
                        MessageBox.Show("Instrumento agregado a la orquesta correctamente.",
                            "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarComboInstrumentos(); // refresca lista
                    }
                    else
                    {
                        MessageBox.Show("No se pudo agregar el instrumento. Quizás ya está en la orquesta.",
                            "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("No se pudo agregar el instrumento. Quizás ya está en la orquesta.",
                        "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar el instrumento: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnVolver_Click(object sender, EventArgs e)
        {
            this.Close(); 
            FrmPrincipal formPrincipal = new();
            formPrincipal.Show();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            // Cierra el sistema
            Application.Exit();
        }
    }
}