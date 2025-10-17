using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GUI_Login.vista
{
    public partial class frmAgregarProfesores : Form
    {
        private ControlInstrumento controlInstrumento;

        public frmAgregarProfesores()
        {
            InitializeComponent();
            controlInstrumento = new ControlInstrumento();
        }

        private void frmProfesores_Load(object sender, EventArgs e)
        {
            List<Instrumento> instrumentos = controlInstrumento.ListarInstrumentosEnOrquesta();
            cmbInstrumentos.DataSource = null;
            cmbInstrumentos.DataSource = instrumentos;
            cmbInstrumentos.DisplayMember = "Nombre";
            cmbInstrumentos.ValueMember = "Id";
            cmbInstrumentos.SelectedIndex = -1;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            // Validación de campos
            if (string.IsNullOrWhiteSpace(txtDni.Text) ||
                string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellido.Text) ||
                string.IsNullOrWhiteSpace(txtTelefono.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                cmbInstrumentos.SelectedIndex == -1)
            {
                MessageBox.Show("Todos los campos son obligatorios.");
                return;
            }

            Profesor profesor = new Profesor
            {
                Dni = int.Parse(txtDni.Text),
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Telefono = txtTelefono.Text,
                Email = txtEmail.Text,
                Id_instrumento = (int)cmbInstrumentos.SelectedValue
            };

            ControlProfesor controlProfesor = new ControlProfesor();
            bool insertado = controlProfesor.RegistrarProfesor(profesor);

            if (insertado)
            {
                MessageBox.Show("Profesor registrado correctamente.");
                txtDni.Clear();
                txtNombre.Clear();
                txtApellido.Clear();
                txtTelefono.Clear();
                txtEmail.Clear();
                cmbInstrumentos.SelectedIndex = -1;
            }
            else
            {
                MessageBox.Show("Error: no se pudo registrar el profesor. Verifique los datos.");
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
