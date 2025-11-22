using GUI_Login.control;
using System;
using System.Data;
using System.Windows.Forms;

namespace GUI_Login.vista
{
    /// <summary>
    /// Formulario para visualizar el listado completo de alumnos
    /// Muestra información detallada incluyendo instrumentos y profesores asignados
    /// </summary>
    public partial class FrmListadoAlumnos : Form
    {
        private readonly ControlAlumno controlAlumno;

        /// <summary>
        /// Constructor que inicializa el controlador de alumnos
        /// </summary>
        public FrmListadoAlumnos()
        {
            InitializeComponent();
            controlAlumno = new ControlAlumno();
        }

        // ==================== MÉTODOS DE CARGA Y CONFIGURACIÓN ====================

        private void FrmListadoAlumnos_Load(object sender, EventArgs e)
        {
            CargarDatosAlumnos();
            this.KeyPreview = true;
        }

        /// <summary>
        /// Carga los datos de alumnos en el DataGridView
        /// </summary>
        private void CargarDatosAlumnos()
        {
            try
            {
                DataTable datos = controlAlumno.ObtenerAlumnosParaGrid();
                dgwAlumnos.DataSource = datos;
                ConfigurarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los alumnos: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Configura el DataGridView para una visualización óptima
        /// </summary>
        private void ConfigurarGrid()
        {
            dgwAlumnos.ClearSelection();

            // Configurar headers
            if (dgwAlumnos.Columns.Contains("id"))
                dgwAlumnos.Columns["id"].Visible = false;

            if (dgwAlumnos.Columns.Contains("nombre_alumno"))
                dgwAlumnos.Columns["nombre_alumno"].HeaderText = "Nombre";

            if (dgwAlumnos.Columns.Contains("apellido_alumno"))
                dgwAlumnos.Columns["apellido_alumno"].HeaderText = "Apellido";

            if (dgwAlumnos.Columns.Contains("dni_alumno"))
                dgwAlumnos.Columns["dni_alumno"].HeaderText = "DNI";

            if (dgwAlumnos.Columns.Contains("telefono_alumno"))
                dgwAlumnos.Columns["telefono_alumno"].HeaderText = "Teléfono";

            if (dgwAlumnos.Columns.Contains("nombre_instrumento"))
                dgwAlumnos.Columns["nombre_instrumento"].HeaderText = "Instrumento";

            if (dgwAlumnos.Columns.Contains("nombre_profesor"))
                dgwAlumnos.Columns["nombre_profesor"].HeaderText = "Profesor";

            if (dgwAlumnos.Columns.Contains("apellido_profesor"))
                dgwAlumnos.Columns["apellido_profesor"].HeaderText = "Apellido P.";

            // Configurar estilo visual
            dgwAlumnos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgwAlumnos.ReadOnly = true;
            dgwAlumnos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgwAlumnos.RowHeadersVisible = false;
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

        private void FrmListadoAlumnos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                BtnVolver_Click(sender, e);
            else if (e.KeyCode == Keys.F4 && e.Alt)
                BtnSalir_Click(sender, e);
        }
    }
}