using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GUI_Login.vista
{
    public partial class frmModificarAlumnos : Form
    {
        private ControlAlumno controlAlumno;
        private ControlInstrumento controlInstrumento;
        private int idSeleccionado = -1;
        private List<Alumno> listaAlumnos;

        public frmModificarAlumnos()
        {
            InitializeComponent();
            controlAlumno = new ControlAlumno();
            controlInstrumento = new ControlInstrumento();
        }

        private void frmModificarAlumnos_Load(object sender, EventArgs e)
        {
            CargarListaAlumnos();
            CargarComboInstrumentos();
        }

        private void CargarListaAlumnos()
        {
            listaAlumnos = controlAlumno.ObtenerAlumnos();
            lstAlumnosModificar.DataSource = null;
            lstAlumnosModificar.DataSource = listaAlumnos;
            lstAlumnosModificar.DisplayMember = "Nombre";
            lstAlumnosModificar.ValueMember = "Id";
        }

        private void CargarComboInstrumentos()
        {
            List<Instrumento> instrumentos = controlInstrumento.ListarInstrumentosEnOrquesta();
            cmbInstrumentos.DataSource = null;
            cmbInstrumentos.DataSource = instrumentos;
            cmbInstrumentos.DisplayMember = "Nombre";
            cmbInstrumentos.ValueMember = "Id";
            cmbInstrumentos.SelectedIndex = -1;
        }

        private void lstAlumnosModificar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstAlumnosModificar.SelectedItem == null) return;

            Alumno alumno = (Alumno)lstAlumnosModificar.SelectedItem;
            idSeleccionado = alumno.Id;

            txtNombre.Text = alumno.Nombre;
            txtApellido.Text = alumno.Apellido;
            txtDni.Text = alumno.Dni.ToString();
            txtTelePadres.Text = alumno.Telefono_padres;

            int idInstrumentoActual = controlAlumno.ObtenerInstrumentoPorAlumno(idSeleccionado);
            if (idInstrumentoActual > 0)
                cmbInstrumentos.SelectedValue = idInstrumentoActual;
        }

        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            if (idSeleccionado <= 0)
            {
                MessageBox.Show("Por favor, seleccione un alumno para modificar.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar campos obligatorios
            if (!controlAlumno.ValidarCamposObligatorios(
                txtNombre.Text, txtApellido.Text, txtDni.Text, txtTelePadres.Text,
                cmbInstrumentos.SelectedValue as int?))
                return;

            // Confirmar modificación
            if (MessageBox.Show("¿Está seguro que desea modificar los datos del alumno?",
                "Confirmar Modificación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            // Crear objeto alumno
            Alumno alumno = new Alumno
            {
                Id = idSeleccionado,
                Nombre = txtNombre.Text.Trim(),
                Apellido = txtApellido.Text.Trim(),
                Dni = int.Parse(txtDni.Text.Trim()),
                Telefono_padres = txtTelePadres.Text.Trim()
            };

            int idInstrumento = (int)cmbInstrumentos.SelectedValue;

            // Modificar alumno con instrumento
            bool exito = controlAlumno.ModificarAlumnoConInstrumento(alumno, idInstrumento);

            if (exito)
            {
                CargarListaAlumnos();
                LimpiarFormulario();
            }
        }

        private void LimpiarFormulario()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtDni.Clear();
            txtTelePadres.Clear();
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
        private void frmModificarAlumnos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) btnVolver_Click(sender, e);
        }
    }
}