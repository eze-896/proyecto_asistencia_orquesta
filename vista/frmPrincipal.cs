using GUI_Login.vista;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.Control;

namespace GUI_Login
{
    public partial class frmPrincipal : Form
    {
        private ControlAsistencia controlAsistencia;
        public frmPrincipal()
        {
            InitializeComponent();
            controlAsistencia = new ControlAsistencia();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            CargarTablaAsistencia();
        }

        private void CargarTablaAsistencia()
        {
            DataTable datos = controlAsistencia.ObtenerDatosParaGrid();
            dgwTablaAsistencia.DataSource = datos;
            dgwTablaAsistencia.ClearSelection();


            dgwTablaAsistencia.Columns["id_alumno"].Visible = false;

            dgwTablaAsistencia.Columns["nombre_alumno"].HeaderText = "Nombre";
            dgwTablaAsistencia.Columns["apellido_alumno"].HeaderText = "Apellido";
            dgwTablaAsistencia.Columns["nombre_instrumento"].HeaderText = "Instrumento";
            dgwTablaAsistencia.Columns["nombre_profesor"].HeaderText = "Profesor";
            dgwTablaAsistencia.Columns["apellido_profesor"].HeaderText = "Apellido Profesor";
            dgwTablaAsistencia.Columns["porcentaje_asistencia"].HeaderText = "% Asistencia";

            // Colorear las filas según el porcentaje
            foreach (DataGridViewRow fila in dgwTablaAsistencia.Rows)
            {
                if (fila.Cells["porcentaje_asistencia"].Value != DBNull.Value)
                {
                    double porcentaje = Convert.ToDouble(fila.Cells["porcentaje_asistencia"].Value);

                    if (porcentaje >= 80)
                        fila.DefaultCellStyle.BackColor = Color.LightGreen; // alta asistencia
                    else if (porcentaje >= 50)
                        fila.DefaultCellStyle.BackColor = Color.Khaki; // media
                    else
                        fila.DefaultCellStyle.BackColor = Color.LightCoral; // baja
                }
            }
        }

        private void menuAlumnos_Click(object sender, EventArgs e)
        {
            // Dirigir al formulario de Alumnos
            frmAgregarAlumnos formAlumnos = new frmAgregarAlumnos();
            formAlumnos.Show();
            this.Hide();
        }

        private void menuProfesor_Click(object sender, EventArgs e)
        {
            // Dirigir al formulario de Profesores
            frmAgregarProfesores formProfesores = new frmAgregarProfesores();
            formProfesores.Show();
            this.Hide();
        }

        private void menuInstrumentos_Click(object sender, EventArgs e)
        {
            // Dirigir al formulario de Instrumentos
            frmAgregarInstrumentos formInstrumentos = new frmAgregarInstrumentos();
            formInstrumentos.Show();
            this.Hide();
        }

        private void menuAsistencia_Click(object sender, EventArgs e)
        {
            // Dirigir al formulario de Asistencias
            frmAgregarAsistencia formAsistencia = new frmAgregarAsistencia();
            formAsistencia.Show();
            this.Hide();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            // Cierra la pestaña y el sistema
            Application.Exit();
        }

        private void menuListadoAlumnos_Click(object sender, EventArgs e)
        {
            // Cierra la pestaña y abre el listado de alumnos
            frmListadoAlumnos formListadoAlumnos = new frmListadoAlumnos();
            formListadoAlumnos.Show();
            this.Hide();
        }

        private void menuListadoProfesores_Click(object sender, EventArgs e)
        {
            // Cierra la pestaña y abre el listado de profesores
            frmListadoProfesores formListadoProfesores = new frmListadoProfesores();
            formListadoProfesores.Show();
            this.Hide();
        }

        private void menuModificarAlumnos_Click(object sender, EventArgs e)
        {
            frmModificarAlumnos formModificarAlumnos = new frmModificarAlumnos();
            formModificarAlumnos.Show();
            this.Hide();
        }

        private void menuEliminarAlumnos_Click(object sender, EventArgs e)
        {
            frmEliminarAlumnos formEliminarAlumnos = new frmEliminarAlumnos();
            formEliminarAlumnos.Show();
            this.Hide();
        }

    }
}
