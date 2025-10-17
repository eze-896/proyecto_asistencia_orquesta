using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GUI_Login.vista
{
    public partial class frmModificarAlumnos : Form
    {
        private ControlAlumno controlAlumno;
        private ControlInstrumento controlInstrumento;
        private ControlAlumnoInstrumento controlAlumnoInstrumento;
        private int idSeleccionado = -1;
        private List<Alumno> listaAlumnos;

        public frmModificarAlumnos()
        {
            InitializeComponent();
            controlAlumno = new ControlAlumno();
            controlInstrumento = new ControlInstrumento();
            controlAlumnoInstrumento = new ControlAlumnoInstrumento();
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
            lstAlumnosModificar.DisplayMember = "Apellido";
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

            int idInstrumentoActual = controlAlumnoInstrumento.ObtenerInstrumentoPorAlumno(idSeleccionado);
            cmbInstrumentos.SelectedValue = idInstrumentoActual;
        }

        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            if (idSeleccionado <= 0) return;

            if (MessageBox.Show("¿Está seguro que desea modificar los datos del alumno?",
                "Confirmar Modificación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            Alumno alumno = new Alumno
            {
                Id = idSeleccionado,
                Nombre = txtNombre.Text.Trim(),
                Apellido = txtApellido.Text.Trim(),
                Dni = int.Parse(txtDni.Text.Trim()),
                Telefono_padres = txtTelePadres.Text.Trim()
            };

            int idInstrumento = (int)cmbInstrumentos.SelectedValue;

            bool modificado = controlAlumno.ModificarAlumno(alumno);
            bool relActualizada = controlAlumnoInstrumento.ActualizarRelacion(idSeleccionado, idInstrumento);

            if (modificado && relActualizada)
            {
                MessageBox.Show("Alumno y su instrumento modificados correctamente.");
                CargarListaAlumnos();
            }
            else
            {
                MessageBox.Show("Error al modificar el alumno o su instrumento.");
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmPrincipal principal = new frmPrincipal();
            principal.Show();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
