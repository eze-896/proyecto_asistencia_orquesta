using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GUI_Login.vista
{
    public partial class frmAgregarAlumnos : Form
    {
        private ControlAlumno controlAlumno;
        private ControlInstrumento controlInstrumento;

        public frmAgregarAlumnos()
        {
            InitializeComponent();
            controlAlumno = new ControlAlumno();
            controlInstrumento = new ControlInstrumento();
        }

        private void frmAgregarAlumnos_Load(object sender, EventArgs e)
        {
            CargarComboInstrumentos();
        }

        private void CargarComboInstrumentos()
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
            if (!controlAlumno.ValidarCamposObligatorios(
                txtNombre.Text, txtApellido.Text, txtDni.Text, txtTelePadres.Text,
                cmbInstrumentos.SelectedValue as int?))
                return;

            // Crear objeto alumno
            Alumno alumno = new Alumno
            {
                Dni = int.Parse(txtDni.Text),
                Nombre = txtNombre.Text.Trim(),
                Apellido = txtApellido.Text.Trim(),
                Telefono_padres = txtTelePadres.Text.Trim()
            };

            int idInstrumento = (int)cmbInstrumentos.SelectedValue;

            // Registrar alumno con instrumento
            bool exito = controlAlumno.RegistrarAlumnoConInstrumento(alumno, idInstrumento);

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
            txtTelePadres.Clear();
            cmbInstrumentos.SelectedIndex = -1;
            txtNombre.Focus();
        }

        // Eventos de UI (sin lógica de negocio)
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

        private void txtTelePadres_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtTelePadres.Text) && !long.TryParse(txtTelePadres.Text, out _))
            {
                MessageBox.Show("El teléfono debe ser un número válido.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTelePadres.Clear();
                txtTelePadres.Focus();
            }
        }

        private void txtNombre_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                txtNombre.Text = char.ToUpper(txtNombre.Text[0]) + txtNombre.Text.Substring(1).ToLower();
            }
        }

        private void txtApellido_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                txtApellido.Text = char.ToUpper(txtApellido.Text[0]) + txtApellido.Text.Substring(1).ToLower();
            }
        }

        // Efectos visuales
        private void Control_Enter(object sender, EventArgs e)
        {
            if (sender is TextBox textBox)
                textBox.BackColor = Color.LightYellow;
        }

        private void Control_Leave(object sender, EventArgs e)
        {
            if (sender is TextBox textBox)
                textBox.BackColor = Color.White;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmPrincipal formPrincipal = new FrmPrincipal();
            formPrincipal.Show();
        }
        private void btnSalir_Click(object sender, EventArgs e) => Application.Exit();
        private void frmAgregarAlumnos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) btnVolver_Click(sender, e);
        }
    }
}