using GUI_Login.control;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace GUI_Login.vista
{
    public partial class FrmListadoProfesores : Form
    {
        private readonly ControlProfesor controlProfesor;
        private bool _formCargado = false;

        public FrmListadoProfesores()
        {
            InitializeComponent();
            controlProfesor = new ControlProfesor();
            SuscribirEventos();
        }

        private void SuscribirEventos()
        {
            this.Load += (s, e) => FrmListadoProfesores_Load(s, e);
            this.KeyDown += (s, e) => FrmListadoProfesores_KeyDown(s, e);
            this.KeyPreview = true;
        }

        private void FrmListadoProfesores_Load(object sender, EventArgs e)
        {
            try
            {
                _formCargado = false;
                CargarDatosProfesores();
                ConfigurarGridCompleto();
                _formCargado = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el formulario: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDatosProfesores()
        {
            try
            {
                DataTable datos = controlProfesor.ObtenerProfesoresParaGrid();

                if (dgvProfesores != null && datos != null)
                {
                    dgvProfesores.DataSource = datos;

                    if (datos.Rows.Count == 0)
                    {
                        MessageBox.Show("No se encontraron profesores en la base de datos.",
                                      "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarGridCompleto()
        {
            if (dgvProfesores == null) return;

            try
            {
                ConfigurarColumnasIndividuales();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al configurar el grid: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarColumnasIndividuales()
        {
            if (dgvProfesores == null || dgvProfesores.Columns.Count == 0) return;

            try
            {
                if (dgvProfesores.Columns.Contains("id"))
                    dgvProfesores.Columns["id"].Visible = false;

                ConfigurarColumna("dni", "DNI", 100);
                ConfigurarColumna("nombre", "Nombre", 120);
                ConfigurarColumna("apellido", "Apellido", 120);
                ConfigurarColumna("telefono", "Teléfono", 110);
                ConfigurarColumna("instrumento", "Instrumento", 130);
                ConfigurarColumna("catedra", "Cátedra", 150);
                ConfigurarColumna("email", "Email", 200);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al configurar columnas: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarColumna(string nombreColumna, string headerText, int anchoMinimo)
        {
            if (dgvProfesores != null && dgvProfesores.Columns.Contains(nombreColumna))
            {
                var columna = dgvProfesores.Columns[nombreColumna];
                columna.HeaderText = headerText;
                columna.MinimumWidth = anchoMinimo;

                // Configurar estilo para columnas de email y cátedra
                if (nombreColumna == "email" || nombreColumna == "catedra")
                {
                    columna.DefaultCellStyle = new DataGridViewCellStyle
                    {
                        ForeColor = Color.FromArgb(64, 64, 64),
                        SelectionForeColor = Color.Black,
                        Font = new Font("Segoe UI", 9.5f, FontStyle.Regular),
                        WrapMode = DataGridViewTriState.True
                    };
                }
            }
        }

        // ==================== EVENTO DOBLE CLICK PARA VER CONTENIDO COMPLETO ====================

        private void DgvProfesores_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!_formCargado) return;

            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && dgvProfesores != null)
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
            catch (Exception ex)
            {
                MessageBox.Show($"Error al procesar doble click: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void MostrarContenidoCompleto(string nombreColumna, string contenido)
        {
            string titulo = nombreColumna == "email" ? "📧 Email completo" : "📚 Cátedra completa";
            string icono = nombreColumna == "email" ? "📧" : "📚";

            MessageBox.Show($"{icono} {contenido}", titulo,
                          MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ==================== NAVEGACIÓN Y CIERRE ====================

        private void BtnVolver_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
                FrmPrincipal formPrincipal = new FrmPrincipal();
                formPrincipal.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al volver al menú principal: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void FrmListadoProfesores_KeyDown(object sender, KeyEventArgs e)
        {
            if (!_formCargado) return;

            try
            {
                if (e.KeyCode == Keys.Escape)
                    BtnVolver_Click(sender, e);
                else if (e.KeyCode == Keys.F4 && e.Alt)
                    BtnSalir_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al procesar tecla: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            if (dgvProfesores != null)
            {
                dgvProfesores.DataSource = null;
            }
            base.OnFormClosed(e);
        }
    }
}