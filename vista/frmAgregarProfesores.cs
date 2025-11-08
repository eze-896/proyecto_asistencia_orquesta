using GUI_Login.control;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GUI_Login.vista
{
    public partial class FrmAgregarProfesores : Form
    {
        private readonly ControlProfesor controlProfesor;
        private readonly ControlInstrumento controlInstrumento;

        public FrmAgregarProfesores()
        {
            InitializeComponent();
            controlProfesor = new ControlProfesor();
            controlInstrumento = new ControlInstrumento();
        }

        private void FrmAgregarProfesores_Load(object sender, EventArgs e)
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

        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            // Validar campos obligatorios
            if (!ControlProfesor.ValidarCamposObligatorios(
                txtNombre.Text, txtApellido.Text, txtDni.Text, txtTelefono.Text,
                txtEmail.Text, cmbInstrumentos.SelectedValue as int?))
                return;
            if (cmbInstrumentos.SelectedValue is int selectedValue)
            {
                // Crear objeto profesor
                Profesor profesor = new()
                {
                    Dni = int.Parse(txtDni.Text),
                    Nombre = txtNombre.Text.Trim(),
                    Apellido = txtApellido.Text.Trim(),
                    Telefono = txtTelefono.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Id_instrumento = selectedValue // ✅ Usar la variable ya verificada
                };

                // Registrar profesor
                bool exito = controlProfesor.RegistrarProfesor(profesor);

                if (exito)
                {
                    LimpiarFormulario();
                }
            }
            else
            {
                MessageBox.Show("Seleccione un instrumento válido.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void TxtDni_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtDni.Text) && !int.TryParse(txtDni.Text, out _))
            {
                MessageBox.Show("El DNI debe ser un número válido.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDni.Clear();
                txtDni.Focus();
            }
        }

        private void TxtTelefono_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtTelefono.Text) && !long.TryParse(txtTelefono.Text, out _))
            {
                MessageBox.Show("El teléfono debe ser un número válido.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTelefono.Clear();
                txtTelefono.Focus();
            }
        }

        private void BtnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmPrincipal formPrincipal = new();
            formPrincipal.Show();
        }
        private void BtnSalir_Click(object sender, EventArgs e) => Application.Exit();
        private void FrmAgregarProfesores_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) BtnVolver_Click(sender, e);
        }
    }
}