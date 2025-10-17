using System;
using System.Windows.Forms;

namespace GUI_Login.vista
{
    public partial class frmListadoAlumnos : Form
    {
        private ControlAlumno controlAlumno;

        public frmListadoAlumnos()
        {
            InitializeComponent();
            controlAlumno = new ControlAlumno();
        }

        private void frmListadoAlumnos_Load(object sender, EventArgs e)
        {
            try
            {
                dgwAlumnos.DataSource = controlAlumno.ObtenerAlumnosparaGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar alumnos: " + ex.Message);
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmPrincipal frm = new frmPrincipal();
            frm.Show();
        }
    }
}
