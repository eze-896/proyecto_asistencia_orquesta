using GUI_Login.control;
using GUI_Login.vista;
using System.Data;

namespace GUI_Login
{
    public partial class FrmPrincipal : Form
    {
        private readonly ControlAsistencia controlAsistencia;
        private DataTable datosOriginales;

        /// <summary>
        /// Constructor que inicializa el controlador y configura eventos
        /// </summary>
        public FrmPrincipal()
        {
            InitializeComponent();
            controlAsistencia = new ControlAsistencia();
            datosOriginales = new DataTable();
            dgwTablaAsistencia.CellFormatting += DgwTablaAsistencia_CellFormatting;
        }

        /// <summary>
        /// Carga inicial del formulario
        /// </summary>
        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            CargarTablaAsistencia();
        }

        /// <summary>
        /// Carga y configura la tabla de asistencias
        /// </summary>
        private void CargarTablaAsistencia()
        {
            try
            {
                datosOriginales = controlAsistencia.ObtenerDatosParaGrid();

                if (datosOriginales == null || datosOriginales.Rows.Count == 0)
                {
                    datosOriginales = new DataTable();
                    MessageBox.Show("No hay datos de asistencia para mostrar.",
                        "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                dgwTablaAsistencia.DataSource = datosOriginales;
                ConfigurarGrid();
                AplicarColoresPorcentaje();
            }
            catch (Exception ex)
            {
                datosOriginales = new DataTable();
                MessageBox.Show($"Error al cargar la tabla de asistencias: {ex.Message}",
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Configura la apariencia y comportamiento del DataGridView
        /// </summary>
        private void ConfigurarGrid()
        {
            dgwTablaAsistencia.ClearSelection();
            dgwTablaAsistencia.ScrollBars = ScrollBars.Both;
            dgwTablaAsistencia.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;

            // Configurar DoubleBuffered para mejor rendimiento
            Type dgvType = dgwTablaAsistencia.GetType();
            System.Reflection.PropertyInfo? pi = dgvType.GetProperty("DoubleBuffered",
                System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            if (pi != null)
            {
                pi.SetValue(dgwTablaAsistencia, true, null);
            }

            // Ocultar columnas que no se deben mostrar
            if (dgwTablaAsistencia.Columns.Contains("id_alumno"))
                dgwTablaAsistencia.Columns["id_alumno"].Visible = false;

            // Configurar headers de columnas
            if (dgwTablaAsistencia.Columns.Contains("nombre_alumno"))
                dgwTablaAsistencia.Columns["nombre_alumno"].HeaderText = "Nombre";
            if (dgwTablaAsistencia.Columns.Contains("apellido_alumno"))
                dgwTablaAsistencia.Columns["apellido_alumno"].HeaderText = "Apellido";
            if (dgwTablaAsistencia.Columns.Contains("instrumentos"))
                dgwTablaAsistencia.Columns["instrumentos"].HeaderText = "Instrumentos";
            if (dgwTablaAsistencia.Columns.Contains("profesores"))
                dgwTablaAsistencia.Columns["profesores"].HeaderText = "Profesores";
            if (dgwTablaAsistencia.Columns.Contains("porcentaje_asistencia"))
            {
                dgwTablaAsistencia.Columns["porcentaje_asistencia"].HeaderText = "%Asistencia";
                dgwTablaAsistencia.Columns["porcentaje_asistencia"].DefaultCellStyle.Format = "0.00'%'";
            }

            // Configurar múltiples líneas y autoajuste
            dgwTablaAsistencia.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgwTablaAsistencia.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgwTablaAsistencia.RowTemplate.MinimumHeight = 40;

            // Configurar alineación específica
            if (dgwTablaAsistencia.Columns.Contains("porcentaje_asistencia"))
            {
                dgwTablaAsistencia.Columns["porcentaje_asistencia"].DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;
            }
        }

        /// <summary>
        /// Aplica colores a las celdas de porcentaje según el valor
        /// </summary>
        private void AplicarColoresPorcentaje()
        {
            if (dgwTablaAsistencia.Rows.Count == 0 ||
                !dgwTablaAsistencia.Columns.Contains("porcentaje_asistencia"))
            {
                return;
            }

            foreach (DataGridViewRow fila in dgwTablaAsistencia.Rows)
            {
                // Color de fondo alternado para mejor legibilidad
                if (fila.Index % 2 == 0)
                {
                    fila.DefaultCellStyle.BackColor = Color.White;
                }
                else
                {
                    fila.DefaultCellStyle.BackColor = Color.FromArgb(248, 248, 252);
                }
                fila.DefaultCellStyle.ForeColor = Color.FromArgb(64, 64, 64);

                // Color específico para celda de porcentaje
                if (fila.Cells["porcentaje_asistencia"].Value != null &&
                    fila.Cells["porcentaje_asistencia"].Value != DBNull.Value)
                {
                    double porcentaje = Convert.ToDouble(fila.Cells["porcentaje_asistencia"].Value);

                    Color colorPorcentaje;
                    Color colorTexto;

                    if (porcentaje >= 80)
                    {
                        colorPorcentaje = Color.FromArgb(220, 255, 220);
                        colorTexto = Color.FromArgb(0, 100, 0);
                    }
                    else if (porcentaje >= 50)
                    {
                        colorPorcentaje = Color.FromArgb(255, 255, 200);
                        colorTexto = Color.FromArgb(102, 77, 0);
                    }
                    else
                    {
                        colorPorcentaje = Color.FromArgb(255, 220, 220);
                        colorTexto = Color.FromArgb(120, 0, 0);
                    }

                    fila.Cells["porcentaje_asistencia"].Style.BackColor = colorPorcentaje;
                    fila.Cells["porcentaje_asistencia"].Style.ForeColor = colorTexto;
                    fila.Cells["porcentaje_asistencia"].Style.Font =
                        new Font(dgwTablaAsistencia.Font, FontStyle.Bold);
                }
            }
        }

        /// <summary>
        /// Filtra los datos de la tabla según el texto de búsqueda
        /// </summary>
        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (sender is not TextBox txtBuscar)
                return;

            if (datosOriginales == null || datosOriginales.Columns.Count == 0)
            {
                return;
            }

            string filtro = txtBuscar.Text.Trim();

            if (string.IsNullOrEmpty(filtro))
            {
                dgwTablaAsistencia.DataSource = datosOriginales;
            }
            else
            {
                try
                {
                    string filtroEscapado = filtro.Replace("[", "[[]")
                                                  .Replace("]", "[]]")
                                                  .Replace("*", "[*]")
                                                  .Replace("%", "[%]")
                                                  .Replace("'", "''");

                    DataView vista = new DataView(datosOriginales);
                    vista.RowFilter = $@"nombre_alumno LIKE '%{filtroEscapado}%' OR 
                       apellido_alumno LIKE '%{filtroEscapado}%' OR 
                       instrumentos LIKE '%{filtroEscapado}%' OR
                       profesores LIKE '%{filtroEscapado}%'";
                    dgwTablaAsistencia.DataSource = vista;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al aplicar filtro: {ex.Message}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            AplicarColoresPorcentaje();
        }

        /// <summary>
        /// Muestra tooltips con el contenido completo de las celdas
        /// </summary>
        private void DgwTablaAsistencia_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var cell = dgwTablaAsistencia.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (cell.Value != null)
                {
                    cell.ToolTipText = cell.Value.ToString();
                }
            }
        }

        /// <summary>
        /// Reaplica colores después de ordenar la tabla
        /// </summary>
        private void DgwTablaAsistencia_Sorted(object sender, EventArgs e)
        {
            AplicarColoresPorcentaje();
        }

        #region Métodos de Navegación

        private void MenuAlumnos_Click(object sender, EventArgs e)
        {
            FrmAgregarAlumnos formAlumnos = new();
            formAlumnos.Show();
            this.Hide();
        }

        private void MenuProfesor_Click(object sender, EventArgs e)
        {
            FrmAgregarProfesores formProfesores = new();
            formProfesores.Show();
            this.Hide();
        }

        private void MenuInstrumentos_Click(object sender, EventArgs e)
        {
            frmAgregarInstrumentos formInstrumentos = new();
            formInstrumentos.Show();
            this.Hide();
        }

        private void MenuAsistencia_Click(object sender, EventArgs e)
        {
            FrmAgregarAsistencia formAsistencia = new();
            formAsistencia.Show();
            this.Hide();
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

        private void MenuListadoAlumnos_Click(object sender, EventArgs e)
        {
            FrmListadoAlumnos formListadoAlumnos = new();
            formListadoAlumnos.Show();
            this.Hide();
        }

        private void MenuListadoProfesores_Click(object sender, EventArgs e)
        {
            FrmListadoProfesores formListadoProfesores = new();
            formListadoProfesores.Show();
            this.Hide();
        }

        private void MenuModificarAlumnos_Click(object sender, EventArgs e)
        {
            FrmModificarAlumnos formModificarAlumnos = new();
            formModificarAlumnos.Show();
            this.Hide();
        }

        private void MenuEliminarAlumnos_Click(object sender, EventArgs e)
        {
            frmEliminarAlumnos formEliminarAlumnos = new();
            formEliminarAlumnos.Show();
            this.Hide();
        }

        private void MenuModificarProfesores_Click(object sender, EventArgs e)
        {
            FrmModificarProfesores formModificarProfesores = new();
            formModificarProfesores.Show();
            this.Hide();
        }

        private void MenuEliminarProfesores_Click(object sender, EventArgs e)
        {
            FrmEliminarProfesores formEliminarProfesores = new();
            formEliminarProfesores.Show();
            this.Hide();
        }

        private void MenuEliminarInstrumentos_Click(object sender, EventArgs e)
        {
            FrmEliminarInstrumento formEliminarInstrumentos = new();
            formEliminarInstrumentos.Show();
            this.Hide();
        }
        #endregion
    }
}