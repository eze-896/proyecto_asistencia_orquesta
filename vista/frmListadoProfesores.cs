using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Windows.Forms;

namespace GUI_Login.vista
{
    public partial class frmListadoProfesores : Form
    {
        private ControlProfesor controlProfesor;

        public frmListadoProfesores()
        {
            InitializeComponent();
            controlProfesor = new ControlProfesor();
        }

        private void frmListadoProfesores_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable datos = controlProfesor.ObtenerProfesoresParaGrid();
                dgvProfesores.DataSource = datos;
                dgvProfesores.ClearSelection();

                dgvProfesores.Columns["id"].Visible = false;
                dgvProfesores.Columns["dni"].HeaderText = "DNI";
                dgvProfesores.Columns["nombre"].HeaderText = "Nombre";
                dgvProfesores.Columns["apellido"].HeaderText = "Apellido";
                dgvProfesores.Columns["telefono"].HeaderText = "Teléfono";
                dgvProfesores.Columns["email"].HeaderText = "Email";
                dgvProfesores.Columns["instrumento"].HeaderText = "Instrumento";
                dgvProfesores.Columns["catedra"].HeaderText = "Cátedra";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar Profesores: " + ex.Message);
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

    }
}

