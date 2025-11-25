using GUI_Login.control;
using System.Data;

namespace GUI_Login.vista
{
    /// <summary>
    /// Formulario para visualizar el listado completo de profesores
    /// Muestra información detallada incluyendo instrumentos, cátedra y contacto
    /// </summary>
    public partial class FrmListadoProfesores : Form
    {
        private readonly ControlProfesor controlProfesor;
        private bool _formCargado = false;

        /// <summary>
        /// Constructor que inicializa el controlador y configura eventos
        /// </summary>
        public FrmListadoProfesores()
        {
            InitializeComponent();
            controlProfesor = new ControlProfesor();
            this.KeyPreview = true;
        }

        /// <summary>
        /// Carga inicial del formulario
        /// </summary>
        private void FrmListadoProfesores_Load(object sender, EventArgs e)
        {
            try
            {
                _formCargado = false;

                // Cargar datos de profesores
                DataTable datos = controlProfesor.ObtenerProfesoresParaGrid();
                dgvProfesores.DataSource = datos;

                if (datos.Rows.Count == 0)
                {
                    MessageBox.Show("No se encontraron profesores en la base de datos.",
                                  "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Configurar columnas del grid
                if (dgvProfesores.Columns.Contains("id"))
                    dgvProfesores.Columns["id"].Visible = false;

                // Configurar cada columna individualmente
                if (dgvProfesores.Columns.Contains("dni"))
                {
                    dgvProfesores.Columns["dni"].HeaderText = "DNI";
                    dgvProfesores.Columns["dni"].MinimumWidth = 100;
                }

                if (dgvProfesores.Columns.Contains("nombre"))
                {
                    dgvProfesores.Columns["nombre"].HeaderText = "Nombre";
                    dgvProfesores.Columns["nombre"].MinimumWidth = 120;
                }

                if (dgvProfesores.Columns.Contains("apellido"))
                {
                    dgvProfesores.Columns["apellido"].HeaderText = "Apellido";
                    dgvProfesores.Columns["apellido"].MinimumWidth = 120;
                }

                if (dgvProfesores.Columns.Contains("telefono"))
                {
                    dgvProfesores.Columns["telefono"].HeaderText = "Teléfono";
                    dgvProfesores.Columns["telefono"].MinimumWidth = 110;
                }

                if (dgvProfesores.Columns.Contains("instrumento"))
                {
                    dgvProfesores.Columns["instrumento"].HeaderText = "Instrumento";
                    dgvProfesores.Columns["instrumento"].MinimumWidth = 130;
                }

                if (dgvProfesores.Columns.Contains("catedra"))
                {
                    dgvProfesores.Columns["catedra"].HeaderText = "Cátedra";
                    dgvProfesores.Columns["catedra"].MinimumWidth = 150;
                    dgvProfesores.Columns["catedra"].DefaultCellStyle = new DataGridViewCellStyle
                    {
                        ForeColor = Color.FromArgb(64, 64, 64),
                        SelectionForeColor = Color.Black,
                        Font = new Font("Segoe UI", 9.5f, FontStyle.Regular),
                        WrapMode = DataGridViewTriState.True
                    };
                }

                if (dgvProfesores.Columns.Contains("email"))
                {
                    dgvProfesores.Columns["email"].HeaderText = "Email";
                    dgvProfesores.Columns["email"].MinimumWidth = 200;
                    dgvProfesores.Columns["email"].DefaultCellStyle = new DataGridViewCellStyle
                    {
                        ForeColor = Color.FromArgb(64, 64, 64),
                        SelectionForeColor = Color.Black,
                        Font = new Font("Segoe UI", 9.5f, FontStyle.Regular),
                        WrapMode = DataGridViewTriState.True
                    };
                }

                _formCargado = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el formulario: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Maneja doble clic en celdas para mostrar contenido completo
        /// </summary>
        private void DgvProfesores_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!_formCargado || e.RowIndex < 0 || e.ColumnIndex < 0) return;

            try
            {
                var cell = dgvProfesores.Rows[e.RowIndex].Cells[e.ColumnIndex];
                string columnName = dgvProfesores.Columns[e.ColumnIndex].Name;

                if ((columnName == "email" || columnName == "catedra") && cell.Value != null)
                {
                    string contenido = cell.Value.ToString() ?? string.Empty;
                    string titulo = columnName == "email" ? "📧 Email completo" : "📚 Cátedra completa";
                    string icono = columnName == "email" ? "📧" : "📚";

                    MessageBox.Show($"{icono} {contenido}", titulo,
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al procesar doble click: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void FrmListadoProfesores_KeyDown(object sender, KeyEventArgs e)
        {
            if (!_formCargado) return;

            if (e.KeyCode == Keys.Escape)
                BtnVolver_Click(sender, e);
            else if (e.KeyCode == Keys.F4 && e.Alt)
                BtnSalir_Click(sender, e);
        }
    }
}