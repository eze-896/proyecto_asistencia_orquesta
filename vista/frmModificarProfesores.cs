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
            this.KeyPreview = true;
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

            string? seleccionado = lstProfesoresModificar.SelectedItem.ToString();
            if (!string.IsNullOrEmpty(seleccionado))
            {
                // CORREGIDO: Parsing seguro usando TryParse
                string idPart = seleccionado.Split('-')[0].Trim();
                if (int.TryParse(idPart, out int id))
                {
                    idSeleccionado = id;
                    Profesor? prof = controlProfesor.BuscarProfesor(idSeleccionado);
                    if (prof != null)
                    {
                        CargarDatosProfesor(prof);
                    }
                }
                else
                {
                    MessageBox.Show("Error al obtener el ID del profesor seleccionado.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CargarDatosProfesor(Profesor profesor)
        {
            txtNombre.Text = profesor.Nombre;
            txtApellido.Text = profesor.Apellido;
            txtDni.Text = profesor.Dni.ToString();
            txtTelefono.Text = profesor.Telefono;
            txtEmail.Text = profesor.Email;
            cmbInstrumentos.SelectedValue = profesor.Id_instrumento;
        }

        // Los demás métodos permanecen igual...
        private void BtnGuardarCambios_Click(object sender, EventArgs e)
        {
            if (!ValidarSeleccionProfesor())
                return;

            if (!ValidarCamposFormulario())
                return;

            if (!ControlProfesor.ConfirmarModificacion())
                return;

            if (cmbInstrumentos.SelectedValue is int selectedValue)
            {
                Profesor profesor = CrearObjetoProfesor(selectedValue);
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

        private bool ValidarSeleccionProfesor()
        {
            if (idSeleccionado == -1)
            {
                MessageBox.Show("Seleccione un profesor para modificar.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private bool ValidarCamposFormulario()
        {
            return ControlProfesor.ValidarProfesor(
                nombre: txtNombre.Text,
                apellido: txtApellido.Text,
                dni: txtDni.Text,
                telefono: txtTelefono.Text,
                email: txtEmail.Text,
                idInstrumento: cmbInstrumentos.SelectedValue as int?);
        }

        private Profesor CrearObjetoProfesor(int idInstrumento)
        {
            return new Profesor
            {
                Id = idSeleccionado,
                Dni = int.Parse(txtDni.Text),
                Nombre = txtNombre.Text.Trim(),
                Apellido = txtApellido.Text.Trim(),
                Telefono = txtTelefono.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Id_instrumento = idInstrumento
            };
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

        private void FrmModificarProfesores_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                BtnVolver_Click(sender, e);
            else if (e.KeyCode == Keys.F4 && e.Alt)
                BtnSalir_Click(sender, e);
        }
    }
}