using GUI_Login.control;

namespace GUI_Login.vista
{
    /// <summary>
    /// Formulario para agregar instrumentos a la orquesta
    /// Permite seleccionar instrumentos disponibles y agregarlos al sistema
    /// </summary>
    public partial class frmAgregarInstrumentos : Form
    {
        private readonly ControlInstrumento controlInstrumento;

        /// <summary>
        /// Constructor que inicializa el controlador de instrumentos
        /// </summary>
        public frmAgregarInstrumentos()
        {
            InitializeComponent();
            controlInstrumento = new ControlInstrumento();
        }

        /// <summary>
        /// Carga inicial del formulario
        /// </summary>
        private void FrmAgregarInstrumentos_Load(object sender, EventArgs e)
        {
            CargarComboInstrumentos();
            this.KeyPreview = true;
        }

        /// <summary>
        /// Carga los instrumentos disponibles en el ComboBox
        /// </summary>
        private void CargarComboInstrumentos()
        {
            try
            {
                List<Instrumento> instrumentos = controlInstrumento.ListarInstrumentosDisponibles();
                cmbInstrumento.DataSource = null;
                cmbInstrumento.DataSource = instrumentos;
                cmbInstrumento.DisplayMember = "Nombre";
                cmbInstrumento.ValueMember = "Id";
                cmbInstrumento.SelectedIndex = -1;

                if (instrumentos.Count == 0)
                {
                    MessageBox.Show("No hay instrumentos disponibles para agregar a la orquesta.\n\nTodos los instrumentos ya están en la orquesta.",
                        "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnIngresar.Enabled = false;
                }
                else
                {
                    btnIngresar.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los instrumentos: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnIngresar.Enabled = false;
            }
        }

        /// <summary>
        /// Maneja el clic en el botón Ingresar para agregar instrumento
        /// </summary>
        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            // Validar selección de instrumento
            if (cmbInstrumento.Items.Count == 0)
            {
                MessageBox.Show("No hay instrumentos disponibles...");
                return;
            }

            if (cmbInstrumento.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un instrumento", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbInstrumento.Focus();
                return;
            }

            // Verificar que se pueda obtener el ID del instrumento
            if (cmbInstrumento.SelectedValue is not int idInstrumento)
            {
                MessageBox.Show("No se pudo obtener el ID del instrumento seleccionado.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Agregar instrumento a la orquesta
                bool insertado = controlInstrumento.AgregarInstrumentoAOrquesta(idInstrumento);

                if (insertado)
                {
                    MessageBox.Show("Instrumento agregado a la orquesta correctamente.",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarComboInstrumentos(); // Recargar lista actualizada
                }
                else
                {
                    MessageBox.Show("No se pudo agregar el instrumento. Puede que ya esté en la orquesta.",
                        "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar el instrumento: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        /// Maneja atajos de teclado en el formulario
        /// </summary>
        private void FrmAgregarInstrumentos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                BtnVolver_Click(sender, e);
            else if (e.KeyCode == Keys.F4 && e.Alt)
                BtnSalir_Click(sender, e);
        }
    }
}