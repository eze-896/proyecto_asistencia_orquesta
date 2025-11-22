using GUI_Login.control;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GUI_Login.vista
{
    /// <summary>
    /// Formulario para eliminar alumnos del sistema
    /// Permite seleccionar y eliminar alumnos con confirmación previa
    /// </summary>
    public partial class frmEliminarAlumnos : Form
    {
        private readonly ControlAlumno controlAlumno;
        private List<Alumno> listaAlumnos;

        /// <summary>
        /// Constructor que inicializa el controlador y la lista de alumnos
        /// </summary>
        public frmEliminarAlumnos()
        {
            InitializeComponent();
            controlAlumno = new ControlAlumno();
            listaAlumnos = new List<Alumno>();
        }

        // ==================== MÉTODOS DE CARGA Y CONFIGURACIÓN ====================

        private void FrmEliminarAlumnos_Load(object sender, EventArgs e)
        {
            CargarAlumnos();
            this.KeyPreview = true;
        }

        /// <summary>
        /// Carga la lista de alumnos desde la base de datos al ListBox
        /// </summary>
        private void CargarAlumnos()
        {
            try
            {
                listaAlumnos = controlAlumno.ObtenerAlumnos();
                ActualizarListaVisual();

                // Selecciona el primer elemento si hay datos
                if (lstAlumnos.Items.Count > 0)
                {
                    lstAlumnos.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los alumnos: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Actualiza el ListBox con los datos actualizados de alumnos
        /// </summary>
        private void ActualizarListaVisual()
        {
            lstAlumnos.Items.Clear();

            foreach (var alumno in listaAlumnos)
            {
                lstAlumnos.Items.Add($"{alumno.Nombre} {alumno.Apellido} - DNI: {alumno.Dni}");
            }
        }

        // ==================== OPERACIONES PRINCIPALES ====================

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (!ValidarSeleccionAlumno())
                return;

            Alumno seleccionado = ObtenerAlumnoSeleccionado();
            EjecutarEliminacion(seleccionado);
        }

        /// <summary>
        /// Valida que se haya seleccionado un alumno para eliminar
        /// </summary>
        /// <returns>True si hay un alumno seleccionado</returns>
        private bool ValidarSeleccionAlumno()
        {
            if (lstAlumnos.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un alumno para eliminar.",
                    "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Obtiene el alumno seleccionado en el ListBox
        /// </summary>
        /// <returns>Alumno seleccionado</returns>
        private Alumno ObtenerAlumnoSeleccionado()
        {
            return listaAlumnos[lstAlumnos.SelectedIndex];
        }

        /// <summary>
        /// Ejecuta el proceso de eliminación del alumno
        /// </summary>
        /// <param name="alumno">Alumno a eliminar</param>
        private void EjecutarEliminacion(Alumno alumno)
        {
            bool exito = controlAlumno.EliminarAlumno(alumno.Id);
            if (exito)
            {
                CargarAlumnos(); // Recarga la lista actualizada
            }
        }

        // ==================== NAVEGACIÓN Y CIERRE ====================

        private void BtnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmPrincipal formPrincipal = new FrmPrincipal();
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

        /// <summary>
        /// Maneja eventos de teclado para mejor usabilidad
        /// - Delete: Eliminar alumno seleccionado
        /// - Escape: Volver al formulario principal
        /// - Alt+F4: Salir del sistema
        /// </summary>
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
            else if (e.KeyCode == Keys.F4 && e.Alt)
            {
                BtnSalir_Click(sender, e);
                e.Handled = true;
            }
        }

        private void FrmEliminarAlumnos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                BtnVolver_Click(sender, e);
            else if (e.KeyCode == Keys.F4 && e.Alt)
                BtnSalir_Click(sender, e);
        }
    }
}