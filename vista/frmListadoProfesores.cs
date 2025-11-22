using GUI_Login.control;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace GUI_Login.vista
{
    /// <summary>
    /// Formulario para visualizar el listado completo de profesores
    /// Muestra información detallada en un DataGridView con herramientas de visualización mejoradas
    /// </summary>
    public partial class FrmListadoProfesores : Form
    {
        private readonly ControlProfesor controlProfesor;

        /// <summary>
        /// Constructor que inicializa el controlador de profesores
        /// </summary>
        public FrmListadoProfesores()
        {
            InitializeComponent();
            controlProfesor = new ControlProfesor();
        }

        // ==================== MÉTODOS DE CARGA Y CONFIGURACIÓN ====================

        private void FrmListadoProfesores_Load(object sender, EventArgs e)
        {
            CargarDatosProfesores();
            ConfigurarGridCompleto();
            ConfigurarToolTipsMejorado();
            dgvProfesores.CellDoubleClick += DgvProfesores_CellDoubleClick;
        }

        /// <summary>
        /// Carga los datos de profesores en el DataGridView
        /// </summary>
        private void CargarDatosProfesores()
        {
            DataTable datos = controlProfesor.ObtenerProfesoresParaGrid();
            dgvProfesores.DataSource = datos;
        }

        // ==================== CONFIGURACIÓN DEL DATAGRIDVIEW ====================

        /// <summary>
        /// Configura completamente el DataGridView para una visualización óptima
        /// </summary>
        private void ConfigurarGridCompleto()
        {
            ConfigurarEstilosVisuales();
            ConfigurarComportamiento();
            ConfigurarColumnasIndividuales();
        }

        /// <summary>
        /// Configura los estilos visuales del DataGridView
        /// </summary>
        private void ConfigurarEstilosVisuales()
        {
            // Limpiar selección inicial
            dgvProfesores.ClearSelection();

            // Configuración visual uniforme para todas las celdas
            dgvProfesores.DefaultCellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Regular);
            dgvProfesores.DefaultCellStyle.ForeColor = Color.Black;
            dgvProfesores.DefaultCellStyle.BackColor = Color.White;
            dgvProfesores.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvProfesores.DefaultCellStyle.SelectionBackColor = Color.FromArgb(116, 86, 174);

            // Configurar estilo de encabezados
            dgvProfesores.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            dgvProfesores.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvProfesores.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(116, 86, 174);
            dgvProfesores.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Configurar filas alternas para mejor legibilidad
            dgvProfesores.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);

            // Configurar wrap de texto para todas las celdas
            dgvProfesores.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvProfesores.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        /// <summary>
        /// Configura el comportamiento del DataGridView
        /// </summary>
        private void ConfigurarComportamiento()
        {
            dgvProfesores.BorderStyle = BorderStyle.None;
            dgvProfesores.EnableHeadersVisualStyles = false;
            dgvProfesores.AllowUserToResizeColumns = true;
            dgvProfesores.AllowUserToResizeRows = false;
            dgvProfesores.RowHeadersVisible = false;
            dgvProfesores.ReadOnly = true;
            dgvProfesores.MultiSelect = false;
        }

        /// <summary>
        /// Configura las columnas individuales del DataGridView
        /// </summary>
        private void ConfigurarColumnasIndividuales()
        {
            if (dgvProfesores.Columns.Contains("id"))
                dgvProfesores.Columns["id"].Visible = false;

            ConfigurarColumna("dni", "DNI", 80);
            ConfigurarColumna("nombre", "Nombre", 100);
            ConfigurarColumna("apellido", "Apellido", 100);
            ConfigurarColumna("telefono", "Teléfono", 90);
            ConfigurarColumna("instrumento", "Instrumento", 120);
            ConfigurarColumna("catedra", "Cátedra", 150);
            ConfigurarColumna("email", "Email", 200, 150);
        }

        /// <summary>
        /// Configura una columna específica del DataGridView
        /// </summary>
        /// <param name="nombreColumna">Nombre de la columna en el DataSource</param>
        /// <param name="headerText">Texto a mostrar en el encabezado</param>
        /// <param name="ancho">Ancho de la columna</param>
        /// <param name="anchoMinimo">Ancho mínimo de la columna (opcional)</param>
        private void ConfigurarColumna(string nombreColumna, string headerText, int ancho, int? anchoMinimo = null)
        {
            if (dgvProfesores.Columns.Contains(nombreColumna))
            {
                dgvProfesores.Columns[nombreColumna].HeaderText = headerText;
                dgvProfesores.Columns[nombreColumna].Width = ancho;

                if (anchoMinimo.HasValue)
                {
                    dgvProfesores.Columns[nombreColumna].MinimumWidth = anchoMinimo.Value;
                }
            }
        }

        // ==================== HERRAMIENTAS DE VISUALIZACIÓN ====================

        /// <summary>
        /// Configura los ToolTips para mostrar contenido completo en celdas truncadas
        /// </summary>
        private void ConfigurarToolTipsMejorado()
        {
            using ToolTip toolTip = new()
            {
                AutoPopDelay = 15000,
                InitialDelay = 200,
                ReshowDelay = 100,
                ShowAlways = true
            };

            dgvProfesores.CellMouseMove += (sender, e) =>
            {
                MostrarToolTipEnCelda(e, toolTip);
            };

            dgvProfesores.CellMouseLeave += (sender, e) =>
            {
                toolTip.RemoveAll();
            };
        }

        /// <summary>
        /// Muestra el ToolTip cuando el mouse está sobre una celda
        /// </summary>
        /// <param name="e">Argumentos del evento del mouse</param>
        /// <param name="toolTip">Instancia del ToolTip</param>
        private void MostrarToolTipEnCelda(DataGridViewCellMouseEventArgs e, ToolTip toolTip)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var cell = dgvProfesores.Rows[e.RowIndex].Cells[e.ColumnIndex];
                string columnName = dgvProfesores.Columns[e.ColumnIndex].Name;

                if (cell.Value != null)
                {
                    string cellValue = cell.Value.ToString() ?? string.Empty;
                    DeterminarContenidoToolTip(columnName, cellValue, toolTip, cell);
                }
            }
        }

        /// <summary>
        /// Determina qué contenido mostrar en el ToolTip según la columna
        /// </summary>
        /// <param name="nombreColumna">Nombre de la columna</param>
        /// <param name="valorCelda">Valor de la celda</param>
        /// <param name="toolTip">Instancia del ToolTip</param>
        /// <param name="celda">Celda actual</param>
        private void DeterminarContenidoToolTip(string nombreColumna, string valorCelda, ToolTip toolTip, DataGridViewCell celda)
        {
            if (nombreColumna == "email" && !string.IsNullOrEmpty(valorCelda))
            {
                toolTip.SetToolTip(dgvProfesores, $"📧 Email completo:\n{valorCelda}");
            }
            else if (nombreColumna == "catedra" && valorCelda.Length > 50)
            {
                toolTip.SetToolTip(dgvProfesores, $"📚 Cátedra completa:\n{valorCelda}");
            }
            else
            {
                VerificarTextoTruncado(valorCelda, toolTip, celda);
            }
        }

        /// <summary>
        /// Verifica si el texto está truncado y muestra ToolTip si es necesario
        /// </summary>
        /// <param name="texto">Texto a verificar</param>
        /// <param name="toolTip">Instancia del ToolTip</param>
        /// <param name="celda">Celda actual</param>
        private void VerificarTextoTruncado(string texto, ToolTip toolTip, DataGridViewCell celda)
        {
            using Graphics g = dgvProfesores.CreateGraphics();
            SizeF textSize = g.MeasureString(texto, dgvProfesores.DefaultCellStyle.Font);
            if (textSize.Width > celda.Size.Width - 10)
            {
                toolTip.SetToolTip(dgvProfesores, texto);
            }
            else
            {
                toolTip.RemoveAll();
            }
        }

        // ==================== EVENTOS DE INTERACCIÓN ====================

        /// <summary>
        /// Maneja el doble click en celdas para mostrar contenido completo
        /// </summary>
        private void DgvProfesores_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var cell = dgvProfesores.Rows[e.RowIndex].Cells[e.ColumnIndex];
                string columnName = dgvProfesores.Columns[e.ColumnIndex].Name;

                if ((columnName == "email" || columnName == "catedra") && cell.Value != null)
                {
                    string contenido = cell.Value.ToString() ?? string.Empty;
                    MostrarContenidoCompleto(columnName, contenido);
                }
            }
        }

        /// <summary>
        /// Muestra el contenido completo de una celda en un MessageBox
        /// </summary>
        /// <param name="nombreColumna">Nombre de la columna</param>
        /// <param name="contenido">Contenido a mostrar</param>
        private static void MostrarContenidoCompleto(string nombreColumna, string contenido)
        {
            string titulo = nombreColumna == "email" ? "Email completo" : "Cátedra completa";
            MessageBox.Show(contenido, titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ==================== NAVEGACIÓN Y CIERRE ====================

        private void BtnVolver_Click(object? sender, EventArgs e)
        {
            this.Close();
            FrmPrincipal formPrincipal = new();
            formPrincipal.Show();
        }

        private void BtnSalir_Click(object? sender, EventArgs e)
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

        private void FrmListadoProfesores_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                BtnVolver_Click(sender, e);
            else if (e.KeyCode == Keys.F4 && e.Alt)
                BtnSalir_Click(sender, e);
        }
    }
}