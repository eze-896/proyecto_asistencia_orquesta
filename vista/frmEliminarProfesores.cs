using GUI_Login.control;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GUI_Login.vista
{
    public partial class FrmEliminarProfesores : Form
    {
        private readonly ControlProfesor controlProfesor;
        private List<Profesor> listaProfesores;

        public FrmEliminarProfesores()
        {
            InitializeComponent();
            controlProfesor = new ControlProfesor();
            listaProfesores = [];
        }

        private void FrmEliminarProfesores_Load(object sender, EventArgs e)
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

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (lstProfesores.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un profesor para eliminar.",
                    "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Profesor seleccionado = listaProfesores[lstProfesores.SelectedIndex];

            // Confirmar y eliminar
            if (ControlProfesor.ConfirmarEliminacion(seleccionado.Nombre, seleccionado.Apellido))
            {
                bool exito = controlProfesor.EliminarProfesor(seleccionado.Id);
                if (exito)
                {
                    CargarProfesores();
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

        private void LstProfesores_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && lstProfesores.SelectedIndex != -1)
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