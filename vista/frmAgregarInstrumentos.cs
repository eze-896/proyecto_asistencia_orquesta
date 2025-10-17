using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GUI_Login.vista
{
    public partial class frmAgregarInstrumentos : Form
    {
        private ControlInstrumento controlInstrumento;

        public frmAgregarInstrumentos()
        {
            InitializeComponent();
            controlInstrumento = new ControlInstrumento();
        }

        private void frmInstrumentos_Load(object sender, EventArgs e)
        {
            CargarComboInstrumentos();
        }

        private void CargarComboInstrumentos()
        {
            List<Instrumento> instrumentos = controlInstrumento.ListarInstrumentosDisponibles();
            cmbInstrumento.DataSource = null;
            cmbInstrumento.DataSource = instrumentos;
            cmbInstrumento.DisplayMember = "Nombre";
            cmbInstrumento.ValueMember = "Id";
            cmbInstrumento.SelectedIndex = -1;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (cmbInstrumento.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un instrumento");
                return;
            }

            int idInstrumento = (int)cmbInstrumento.SelectedValue;
            bool insertado = controlInstrumento.AgregarInstrumentoAOrquesta(idInstrumento);

            if (insertado)
            {
                MessageBox.Show("Instrumento agregado a la orquesta correctamente.");
                CargarComboInstrumentos(); // refresca lista
            }
            else
            {
                MessageBox.Show("No se pudo agregar el instrumento. Quizás ya está en la orquesta.");
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            frmPrincipal formPrincipal = new frmPrincipal();
            formPrincipal.Show();
            this.Hide();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            // Cierra la pestaña y el sistema
            Application.Exit();
        }
    }
}
