using GUI_Login.control;
using System;
using System.Data;
using System.Windows.Forms;

namespace GUI_Login.vista
{
    public partial class FrmListadoAlumnos : Form
    {
        private readonly ControlAlumno controlAlumno;

        public FrmListadoAlumnos()
        {
            InitializeComponent();
            controlAlumno = new ControlAlumno();
        }

        private void FrmListadoAlumnos_Load(object sender, EventArgs e)
        {
            CargarDatosAlumnos();
        }

        private void CargarDatosAlumnos()
        {
            DataTable datos = controlAlumno.ObtenerAlumnosParaGrid();
            dgwAlumnos.DataSource = datos;
            ConfigurarGrid();
        }

        private void ConfigurarGrid()
        {
            dgwAlumnos.ClearSelection();

            // Configurar headers
            if (dgwAlumnos.Columns.Contains("id"))
                dgwAlumnos.Columns["id"].Visible = false;

            if (dgwAlumnos.Columns.Contains("nombre_alumno"))
                dgwAlumnos.Columns["nombre_alumno"].HeaderText = "Nombre";

            if (dgwAlumnos.Columns.Contains("apellido_alumno"))
                dgwAlumnos.Columns["apellido_alumno"].HeaderText = "Apellido";

            if (dgwAlumnos.Columns.Contains("dni_alumno"))
                dgwAlumnos.Columns["dni_alumno"].HeaderText = "DNI";

            if (dgwAlumnos.Columns.Contains("telefono_alumno"))
                dgwAlumnos.Columns["telefono_alumno"].HeaderText = "Teléfono";

            if (dgwAlumnos.Columns.Contains("nombre_instrumento"))
                dgwAlumnos.Columns["nombre_instrumento"].HeaderText = "Instrumento";

            if (dgwAlumnos.Columns.Contains("nombre_profesor"))
                dgwAlumnos.Columns["nombre_profesor"].HeaderText = "Profesor";

            if (dgwAlumnos.Columns.Contains("apellido_profesor"))
                dgwAlumnos.Columns["apellido_profesor"].HeaderText = "Apellido P.";
        }

        private void BtnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmPrincipal formPrincipal = new();
            formPrincipal.Show();
        }
        private void FrmListadoAlumnos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) BtnVolver_Click(sender, e);
        }
    }
}