using GUI_Login.control;

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

        /// <summary>
        /// Carga inicial del formulario
        /// </summary>
        private void FrmEliminarAlumnos_Load(object sender, EventArgs e)
        {
            CargarAlumnos();
            this.KeyPreview = true;
        }

        /// <summary>
        /// Carga y actualiza la lista de alumnos en el ListBox
        /// </summary>
        private void CargarAlumnos()
        {
            try
            {
                listaAlumnos = controlAlumno.ObtenerAlumnos();
                lstAlumnos.Items.Clear();

                foreach (var alumno in listaAlumnos)
                {
                    lstAlumnos.Items.Add($"{alumno.Nombre} {alumno.Apellido} - DNI: {alumno.Dni}");
                }

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
        /// Maneja el clic en el botón Eliminar
        /// </summary>
        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            // Validar que se haya seleccionado un alumno
            if (lstAlumnos.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un alumno para eliminar.",
                    "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Obtener alumno seleccionado y ejecutar eliminación
            Alumno seleccionado = listaAlumnos[lstAlumnos.SelectedIndex];
            bool exito = controlAlumno.EliminarAlumno(seleccionado.Id);

            if (exito)
            {
                CargarAlumnos(); // Recarga la lista actualizada
            }
        }

        /// <summary>
        /// Regresa al formulario principal
        /// </summary>
        private void BtnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmPrincipal formPrincipal = new FrmPrincipal();
            formPrincipal.Show();
        }

        /// <summary>
        /// Sale del sistema con confirmación
        /// </summary>
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

        /// <summary>
        /// Maneja atajos de teclado en el ListBox
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

        /// <summary>
        /// Maneja atajos de teclado en el formulario
        /// </summary>
        private void FrmEliminarAlumnos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                BtnVolver_Click(sender, e);
            else if (e.KeyCode == Keys.F4 && e.Alt)
                BtnSalir_Click(sender, e);
        }
    }
}