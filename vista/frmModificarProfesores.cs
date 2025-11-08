using GUI_Login.control;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GUI_Login.vista
{
    public partial class FrmModificarProfesores : Form
    {
        private readonly ControlProfesor controlProfesor;
        private readonly ControlInstrumento controlInstrumento;
        private int idSeleccionado = -1;

        public FrmModificarProfesores()
        {
            InitializeComponent();
            controlProfesor = new ControlProfesor();
            controlInstrumento = new ControlInstrumento();
        }

        private void FrmModificarProfesores_Load(object sender, EventArgs e)
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

        private void LstProfesoresModificar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstProfesoresModificar.SelectedItem == null) return;

            string? seleccionado = lstProfesoresModificar.SelectedItem.ToString(); // ✅ Usar nullable
            if (!string.IsNullOrEmpty(seleccionado))
            {
                idSeleccionado = Convert.ToInt32(seleccionado.Split('-')[0].Trim());

                Profesor? prof = controlProfesor.BuscarProfesor(idSeleccionado); // ✅ Usar nullable
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
        }

        private void BtnGuardarCambios_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == -1)
            {
                MessageBox.Show("Seleccione un profesor para modificar.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar campos obligatorios
            if (!ControlProfesor.ValidarCamposObligatorios(
                txtNombre.Text, txtApellido.Text, txtDni.Text, txtTelefono.Text,
                txtEmail.Text, cmbInstrumentos.SelectedValue as int?))
                return;

            // Confirmar modificación
            if (!ControlProfesor.ConfirmarModificacion())
                return;

            // ✅ CORREGIDO: Verificar que SelectedValue no sea null
            if (cmbInstrumentos.SelectedValue is int selectedValue)
            {
                // Crear objeto profesor
                Profesor profesor = new()
                {
                    Id = idSeleccionado,
                    Dni = int.Parse(txtDni.Text),
                    Nombre = txtNombre.Text.Trim(),
                    Apellido = txtApellido.Text.Trim(),
                    Telefono = txtTelefono.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Id_instrumento = selectedValue // ✅ Usar la variable ya verificada
                };

                // Modificar profesor
                bool exito = controlProfesor.ModificarProfesor(profesor);

                if (exito)
                {
                    CargarProfesores();
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
            txtNombre.Clear();
            txtApellido.Clear();
            txtDni.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
            cmbInstrumentos.SelectedIndex = -1;
            idSeleccionado = -1;
        }

        private void BtnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmPrincipal formPrincipal = new();
            formPrincipal.Show();
        }
        private void BtnSalir_Click(object sender, EventArgs e) => Application.Exit();
        private void FrmModificarProfesores_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) BtnVolver_Click(sender, e);
        }
    }
}