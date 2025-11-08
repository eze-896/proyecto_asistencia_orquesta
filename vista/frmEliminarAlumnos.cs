using GUI_Login.control;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GUI_Login.vista
{
    public partial class frmEliminarAlumnos : Form
    {
        private readonly ControlAlumno controlAlumno;
        private List<Alumno> listaAlumnos;

        public frmEliminarAlumnos()
        {
            InitializeComponent();
            controlAlumno = new ControlAlumno();
            listaAlumnos = [];
        }

        private void FrmEliminarAlumnos_Load(object sender, EventArgs e)
        {
            CargarAlumnos();
            this.KeyPreview = true;
        }

        private void CargarAlumnos()
        {
            listaAlumnos = controlAlumno.ObtenerAlumnos();
            lstAlumnos.Items.Clear();

            foreach (var alumno in listaAlumnos)
            {
                lstAlumnos.Items.Add($"{alumno.Nombre} {alumno.Apellido} - DNI: {alumno.Dni}");
            }

            if (lstAlumnos.Items.Count > 0)
            {
                lstAlumnos.SelectedIndex = 0;
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (lstAlumnos.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un alumno para eliminar.",
                    "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Alumno seleccionado = listaAlumnos[lstAlumnos.SelectedIndex];

            DialogResult resultado = MessageBox.Show(
                $"¿Está seguro de eliminar a {seleccionado.Nombre} {seleccionado.Apellido}?",
                "Confirmar Eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                bool exito = controlAlumno.EliminarAlumno(seleccionado.Id);
                if (exito)
                {
                    CargarAlumnos();
                }
            }
        }

        private void BtnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmPrincipal formPrincipal = new();
            formPrincipal.Show();
        }
        private void BtnSalir_Click(object sender, EventArgs e) => Application.Exit();

        private void LstAlumnos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && lstAlumnos.SelectedIndex != -1)
            {
                BtnEliminar_Click(sender, e);
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Escape)
            {
                BtnVolver_Click(sender, e);
                e.Handled = true;
            }
        }
    }
}