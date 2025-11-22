using GUI_Login.control;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GUI_Login.vista
{
    /// <summary>
    /// Formulario para agregar instrumentos a la orquesta
    /// Permite seleccionar instrumentos disponibles y agregarlos al inventario
    /// </summary>
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

        /// <summary>
        /// Carga los instrumentos disponibles en el ComboBox
        /// </summary>
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
                // Valida si SelectedValue es un int
                if (!(cmbInstrumento.SelectedValue is int idInstrumento))
                {
                    MessageBox.Show("No se pudo agregar el instrumento. Quizás ya está en la orquesta.",
                        "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Intenta insertar
                bool insertado = controlInstrumento.AgregarInstrumentoAOrquesta(idInstrumento);

                if (!insertado)
                {
                    MessageBox.Show("No se pudo agregar el instrumento. Quizás ya está en la orquesta.",
                        "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                MessageBox.Show("Instrumento agregado a la orquesta correctamente.",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarComboInstrumentos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar el instrumento: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Navegación y cierre
        private void BtnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmPrincipal formPrincipal = new();
            formPrincipal.Show();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}