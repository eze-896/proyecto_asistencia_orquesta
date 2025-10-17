using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GUI_Login.vista
{
    public partial class frmEliminarAlumnos : Form
    {
        private ControlAlumno controlAlumno;
        private List<Alumno> listaAlumnos;

        public frmEliminarAlumnos()
        {
            InitializeComponent();
            controlAlumno = new ControlAlumno();
            listaAlumnos = new List<Alumno>();
        }

        private void frmEliminarAlumnos_Load(object sender, EventArgs e)
        {
            CargarAlumnos();
            this.KeyPreview = true;
            this.lstAlumnos.TabStop = true;
        }

        private void CargarAlumnos()
        {
            lstAlumnos.Items.Clear();
            listaAlumnos = controlAlumno.ObtenerAlumnos();

            foreach (var alumno in listaAlumnos)
            {
                lstAlumnos.Items.Add($"{alumno.Nombre} {alumno.Apellido} - DNI: {alumno.Dni}");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (lstAlumnos.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un alumno para eliminar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Alumno seleccionado = listaAlumnos[lstAlumnos.SelectedIndex];

            DialogResult resultado = MessageBox.Show($"¿Está seguro de eliminar a {seleccionado.Nombre} {seleccionado.Apellido}?",
                "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                bool exito = controlAlumno.EliminarAlumno(seleccionado.Id);
                if (exito)
                {
                    MessageBox.Show("Alumno eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarAlumnos();
                }
                else
                {
                    MessageBox.Show("Error al eliminar el alumno.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmPrincipal frm = new frmPrincipal();
            frm.Show();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lstAlumnos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                btnEliminar_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                btnVolver_Click(sender, e);
            }
        }
    }
}
