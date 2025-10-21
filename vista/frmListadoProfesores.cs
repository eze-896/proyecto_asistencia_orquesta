using System;
using System.Data;
using System.Windows.Forms;

namespace GUI_Login.vista
{
    public partial class frmListadoProfesores : Form
    {
        private readonly ControlProfesor controlProfesor;

        public frmListadoProfesores()
        {
            InitializeComponent();
            controlProfesor = new ControlProfesor();
        }

        private void FrmListadoProfesores_Load(object sender, EventArgs e)
        {
            CargarDatosProfesores();
        }

        private void CargarDatosProfesores()
        {
            DataTable datos = controlProfesor.ObtenerProfesoresParaGrid();
            dgvProfesores.DataSource = datos;
            ConfigurarGrid();
        }

        private void ConfigurarGrid()
        {
            dgvProfesores.ClearSelection();

            // Configurar headers
            if (dgvProfesores.Columns.Contains("id"))
                dgvProfesores.Columns["id"].Visible = false;

            if (dgvProfesores.Columns.Contains("dni"))
                dgvProfesores.Columns["dni"].HeaderText = "DNI";

            if (dgvProfesores.Columns.Contains("nombre"))
                dgvProfesores.Columns["nombre"].HeaderText = "Nombre";

            if (dgvProfesores.Columns.Contains("apellido"))
                dgvProfesores.Columns["apellido"].HeaderText = "Apellido";

            if (dgvProfesores.Columns.Contains("telefono"))
                dgvProfesores.Columns["telefono"].HeaderText = "Teléfono";

            if (dgvProfesores.Columns.Contains("email"))
                dgvProfesores.Columns["email"].HeaderText = "Email";

            if (dgvProfesores.Columns.Contains("instrumento"))
                dgvProfesores.Columns["instrumento"].HeaderText = "Instrumento";

            if (dgvProfesores.Columns.Contains("catedra"))
                dgvProfesores.Columns["catedra"].HeaderText = "Cátedra";
        }

        private void BtnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmPrincipal formPrincipal = new();
            formPrincipal.Show();
        }
        private void FrmListadoProfesores_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) BtnVolver_Click(sender, e);
        }
    }
}