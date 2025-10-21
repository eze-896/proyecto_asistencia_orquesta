using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GUI_Login.vista
{
    public partial class frmAgregarProfesores : Form
    {
        private ControlProfesor controlProfesor;
        private ControlInstrumento controlInstrumento;

        public frmAgregarProfesores()
        {
            InitializeComponent();
            controlProfesor = new ControlProfesor();
            controlInstrumento = new ControlInstrumento();
        }

        private void frmAgregarProfesores_Load(object sender, EventArgs e)
        {
            CargarInstrumentos();
        }

        private void CargarInstrumentos()
        {
            try
            {
                List<Instrumento> instrumentos = controlInstrumento.ListarInstrumentosEnOrquesta();
                cmbInstrumentos.DataSource = null;
                cmbInstrumentos.DataSource = instrumentos;
                cmbInstrumentos.DisplayMember = "Nombre";
                cmbInstrumentos.ValueMember = "Id";
                cmbInstrumentos.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar instrumentos: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            // Validar campos obligatorios
            if (!controlProfesor.ValidarCamposObligatorios(
                txtNombre.Text, txtApellido.Text, txtDni.Text, txtTelefono.Text,
                txtEmail.Text, cmbInstrumentos.SelectedValue as int?))
                return;

            // Crear objeto profesor
            Profesor profesor = new Profesor
            {
                Dni = int.Parse(txtDni.Text),
                Nombre = txtNombre.Text.Trim(),
                Apellido = txtApellido.Text.Trim(),
                Telefono = txtTelefono.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Id_instrumento = (int)cmbInstrumentos.SelectedValue
            };

            // Registrar profesor
            bool exito = controlProfesor.RegistrarProfesor(profesor);

            if (exito)
            {
                LimpiarFormulario();
            }
        }

        private void LimpiarFormulario()
        {
            txtDni.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
            cmbInstrumentos.SelectedIndex = -1;
            txtNombre.Focus();
        }

        // Eventos de validación en UI
        private void txtDni_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtDni.Text) && !int.TryParse(txtDni.Text, out _))
            {
                MessageBox.Show("El DNI debe ser un número válido.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDni.Clear();
                txtDni.Focus();
            }
        }

        private void txtTelefono_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtTelefono.Text) && !long.TryParse(txtTelefono.Text, out _))
            {
                MessageBox.Show("El teléfono debe ser un número válido.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTelefono.Clear();
                txtTelefono.Focus();
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmPrincipal formPrincipal = new FrmPrincipal();
            formPrincipal.Show();
        }
        private void btnSalir_Click(object sender, EventArgs e) => Application.Exit();
        private void frmAgregarProfesores_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) btnVolver_Click(sender, e);
        }
    }
}