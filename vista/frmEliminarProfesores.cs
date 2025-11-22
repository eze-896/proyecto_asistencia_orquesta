using GUI_Login.control;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GUI_Login.vista
{
    /// <summary>
    /// Formulario para eliminar profesores del sistema
    /// Permite seleccionar y eliminar profesores con confirmación previa
    /// </summary>
    public partial class FrmEliminarProfesores : Form
    {
        private readonly ControlProfesor controlProfesor;
        private List<Profesor> listaProfesores;

        /// <summary>
        /// Constructor que inicializa el controlador y la lista de profesores
        /// </summary>
        public FrmEliminarProfesores()
        {
            InitializeComponent();
            controlProfesor = new ControlProfesor();
            listaProfesores = [];
        }

        // ==================== MÉTODOS DE CARGA Y CONFIGURACIÓN ====================

        private void FrmEliminarProfesores_Load(object sender, EventArgs e)
        {
            CargarProfesores();
            this.KeyPreview = true;
        }

        /// <summary>
        /// Carga la lista de profesores en el ListBox
        /// </summary>
        private void CargarProfesores()
        {
            listaProfesores = controlProfesor.ObtenerProfesores();
            ActualizarListaVisual();
        }

        /// <summary>
        /// Actualiza el ListBox con los datos actualizados de profesores
        /// </summary>
        private void ActualizarListaVisual()
        {
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

        // ==================== OPERACIONES PRINCIPALES ====================

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (!ValidarSeleccionProfesor())
                return;

            Profesor seleccionado = ObtenerProfesorSeleccionado();

            if (ControlProfesor.ConfirmarEliminacion(seleccionado.Nombre, seleccionado.Apellido))
            {
                EjecutarEliminacion(seleccionado);
            }
        }

        /// <summary>
        /// Valida que se haya seleccionado un profesor para eliminar
        /// </summary>
        /// <returns>True si la selección es válida</returns>
        private bool ValidarSeleccionProfesor()
        {
            if (lstProfesores.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un profesor para eliminar.",
                    "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Obtiene el profesor seleccionado en el ListBox
        /// </summary>
        /// <returns>Objeto Profesor seleccionado</returns>
        private Profesor ObtenerProfesorSeleccionado()
        {
            return listaProfesores[lstProfesores.SelectedIndex];
        }

        /// <summary>
        /// Ejecuta el proceso de eliminación del profesor
        /// </summary>
        /// <param name="profesor">Profesor a eliminar</param>
        private void EjecutarEliminacion(Profesor profesor)
        {
            bool exito = controlProfesor.EliminarProfesor(profesor.Id);
            if (exito)
            {
                CargarProfesores();
            }
        }

        // ==================== NAVEGACIÓN Y CIERRE ====================

        private void BtnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmPrincipal formPrincipal = new();
            formPrincipal.Show();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "¿Está seguro que desea salir del sistema?",
                "Confirmar Salida",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        // ==================== MANEJO DE TECLADO ====================

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
            else if (e.KeyCode == Keys.F4 && e.Alt)
            {
                BtnSalir_Click(sender, e);
                e.Handled = true;
            }
        }

        private void FrmEliminarProfesores_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                BtnVolver_Click(sender, e);
            else if (e.KeyCode == Keys.F4 && e.Alt)
                BtnSalir_Click(sender, e);
        }
    }
}