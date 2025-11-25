using GUI_Login.control;

namespace GUI_Login.vista
{
    /// <summary>
    /// Formulario para eliminar profesores del sistema
    /// Permite seleccionar y eliminar profesores
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

        /// <summary>
        /// Carga inicial del formulario
        /// </summary>
        private void FrmEliminarProfesores_Load(object sender, EventArgs e)
        {
            CargarProfesores();
            this.KeyPreview = true;
        }

        /// <summary>
        /// Carga y actualiza la lista de profesores en el ListBox
        /// </summary>
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

        /// <summary>
        /// Maneja el evento de clic en el botón Eliminar
        /// </summary>
        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            // Validar que se haya seleccionado un profesor
            if (lstProfesores.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un profesor para eliminar.", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Obtener profesor seleccionado y ejecutar eliminación
            Profesor seleccionado = listaProfesores[lstProfesores.SelectedIndex];
            bool exito = controlProfesor.EliminarProfesor(seleccionado.Id);

            if (exito)
            {
                CargarProfesores(); // Recargar lista actualizada
            }
        }

        /// <summary>
        /// Regresa al formulario principal
        /// </summary>
        private void BtnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmPrincipal formPrincipal = new();
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

        /// <summary>
        /// Maneja atajos de teclado en el formulario
        /// </summary>
        private void FrmEliminarProfesores_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                BtnVolver_Click(sender, e);
            else if (e.KeyCode == Keys.F4 && e.Alt)
                BtnSalir_Click(sender, e);
        }
    }
}