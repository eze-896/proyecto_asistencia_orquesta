using GUI_Login.control;

namespace GUI_Login.vista
{
    /// <summary>
    /// Formulario para eliminar instrumentos de la orquesta
    /// Permite seleccionar y eliminar instrumentos con validación de uso previo
    /// </summary>
    public partial class FrmEliminarInstrumento : Form
    {
        private readonly ControlInstrumento controlInstrumento;
        private List<Instrumento> listaInstrumentos;

        /// <summary>
        /// Constructor que inicializa el controlador y la lista de instrumentos
        /// </summary>
        public FrmEliminarInstrumento()
        {
            InitializeComponent();
            controlInstrumento = new ControlInstrumento();
            listaInstrumentos = new List<Instrumento>();
        }

        /// <summary>
        /// Carga inicial del formulario
        /// </summary>
        private void FrmEliminarInstrumento_Load(object sender, EventArgs e)
        {
            CargarInstrumentos();
            this.KeyPreview = true;
        }

        /// <summary>
        /// Carga y actualiza la lista de instrumentos en el ListBox
        /// </summary>
        private void CargarInstrumentos()
        {
            try
            {
                lstInstrumentos.Items.Clear();
                listaInstrumentos = controlInstrumento.ListarInstrumentosEnOrquesta();

                foreach (var instrumento in listaInstrumentos)
                {
                    lstInstrumentos.Items.Add($"{instrumento.Nombre} - {instrumento.Catedra}");
                }

                if (lstInstrumentos.Items.Count > 0)
                {
                    lstInstrumentos.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("No hay instrumentos en la orquesta para eliminar.",
                        "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los instrumentos: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Maneja el clic en el botón Eliminar
        /// </summary>
        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            // Validar que se haya seleccionado un instrumento
            if (lstInstrumentos.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un instrumento para eliminar de la orquesta.", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lstInstrumentos.Focus();
                return;
            }

            // Obtener instrumento seleccionado
            Instrumento seleccionado = listaInstrumentos[lstInstrumentos.SelectedIndex];

            // Ejecutar eliminación (todas las validaciones están en el controlador)
            bool exito = controlInstrumento.EliminarInstrumentoDeOrquesta(seleccionado.Id, seleccionado.Nombre);

            if (exito)
            {
                CargarInstrumentos(); // Recargar lista actualizada
            }
        }

        /// <summary>
        /// Maneja atajos de teclado en el ListBox
        /// </summary>
        private void LstInstrumentos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && lstInstrumentos.SelectedIndex != -1)
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

        /// <summary>
        /// Maneja atajos de teclado en el formulario
        /// </summary>
        private void FrmEliminarInstrumento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                BtnVolver_Click(sender, e);
            else if (e.KeyCode == Keys.F4 && e.Alt)
                BtnSalir_Click(sender, e);
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
    }
}