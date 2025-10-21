using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GUI_Login.vista
{
    public partial class frmEliminarProfesores : Form
    {
        private ControlProfesor controlProfesor;
        private List<Profesor> listaProfesores;

        public frmEliminarProfesores()
        {
            InitializeComponent();
            controlProfesor = new ControlProfesor();
            listaProfesores = new List<Profesor>();
        }

        private void frmEliminarProfesores_Load(object sender, EventArgs e)
        {
            CargarProfesores();
            this.KeyPreview = true;
        }

        private void CargarProfesores()
        {
            listaProfesores = controlProfesor.ObtenerProfesores();
            lstProfesores.Items.Clear();

            foreach (var profesor in listaProfesores)
            {
                lstProfesores.Items.Add($"{profesor.Nombre} {profesor.Apellido} - DNI: {profesor.Dni}");
            }

            if (lstProfesores.Items.Count > 0)
            {
                lstProfesores.SelectedIndex = 0;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (lstProfesores.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un profesor para eliminar.",
                    "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Profesor seleccionado = listaProfesores[lstProfesores.SelectedIndex];

            // Confirmar y eliminar
            if (controlProfesor.ConfirmarEliminacion(seleccionado.Nombre, seleccionado.Apellido))
            {
                bool exito = controlProfesor.EliminarProfesor(seleccionado.Id);
                if (exito)
                {
                    CargarProfesores();
                }
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmPrincipal formPrincipal = new FrmPrincipal();
            formPrincipal.Show();
        }
        private void btnSalir_Click(object sender, EventArgs e) => Application.Exit();

        private void lstProfesores_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && lstProfesores.SelectedIndex != -1)
            {
                btnEliminar_Click(sender, e);
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Escape)
            {
                btnVolver_Click(sender, e);
                e.Handled = true;
            }
        }
    }
}