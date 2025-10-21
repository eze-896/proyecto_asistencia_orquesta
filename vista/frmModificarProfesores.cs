using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GUI_Login.vista
{
    public partial class frmModificarProfesores : Form
    {
        private ControlProfesor controlProfesor;
        private ControlInstrumento controlInstrumento;
        private int idSeleccionado = -1;

        public frmModificarProfesores()
        {
            InitializeComponent();
            controlProfesor = new ControlProfesor();
            controlInstrumento = new ControlInstrumento();
        }

        private void frmModificarProfesores_Load(object sender, EventArgs e)
        {
            CargarProfesores();
            CargarInstrumentos();
        }

        private void CargarProfesores()
        {
            lstProfesoresModificar.Items.Clear();
            var profesores = controlProfesor.ObtenerProfesores();

            foreach (var prof in profesores)
            {
                lstProfesoresModificar.Items.Add($"{prof.Id} - {prof.Nombre} {prof.Apellido}");
            }
        }

        private void CargarInstrumentos()
        {
            cmbInstrumentos.DisplayMember = "Nombre";
            cmbInstrumentos.ValueMember = "Id";
            cmbInstrumentos.DataSource = controlInstrumento.ListarInstrumentosEnOrquesta();
            cmbInstrumentos.SelectedIndex = -1;
        }

        private void lstProfesoresModificar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstProfesoresModificar.SelectedItem == null) return;

            string seleccionado = lstProfesoresModificar.SelectedItem.ToString();
            idSeleccionado = Convert.ToInt32(seleccionado.Split('-')[0].Trim());

            Profesor prof = controlProfesor.BuscarProfesor(idSeleccionado);
            if (prof != null)
            {
                txtNombre.Text = prof.Nombre;
                txtApellido.Text = prof.Apellido;
                txtDni.Text = prof.Dni.ToString();
                txtTelefono.Text = prof.Telefono;
                txtEmail.Text = prof.Email;
                cmbInstrumentos.SelectedValue = prof.Id_instrumento;
            }
        }

        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == -1)
            {
                MessageBox.Show("Seleccione un profesor para modificar.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar campos obligatorios
            if (!controlProfesor.ValidarCamposObligatorios(
                txtNombre.Text, txtApellido.Text, txtDni.Text, txtTelefono.Text,
                txtEmail.Text, cmbInstrumentos.SelectedValue as int?))
                return;

            // Confirmar modificación
            if (!controlProfesor.ConfirmarModificacion())
                return;

            // Crear objeto profesor
            Profesor profesor = new Profesor
            {
                Id = idSeleccionado,
                Dni = int.Parse(txtDni.Text),
                Nombre = txtNombre.Text.Trim(),
                Apellido = txtApellido.Text.Trim(),
                Telefono = txtTelefono.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Id_instrumento = (int)cmbInstrumentos.SelectedValue
            };

            // Modificar profesor
            bool exito = controlProfesor.ModificarProfesor(profesor);

            if (exito)
            {
                CargarProfesores();
                LimpiarFormulario();
            }
        }

        private void LimpiarFormulario()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtDni.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
            cmbInstrumentos.SelectedIndex = -1;
            idSeleccionado = -1;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmPrincipal formPrincipal = new FrmPrincipal();
            formPrincipal.Show();
        }
        private void btnSalir_Click(object sender, EventArgs e) => Application.Exit();
        private void frmModificarProfesores_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) btnVolver_Click(sender, e);
        }
    }
}