using GUI_Login.vista;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using GUI_Login.control;

namespace GUI_Login
{
    public partial class FrmPrincipal : Form
    {
        private readonly ControlAsistencia controlAsistencia;
        private DataTable datosOriginales;

        public FrmPrincipal()
        {
            InitializeComponent();
            controlAsistencia = new ControlAsistencia();
            datosOriginales = new DataTable();
            dgwTablaAsistencia.CellFormatting += DgwTablaAsistencia_CellFormatting;
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            CargarTablaAsistencia();
        }

        private void CargarTablaAsistencia()
        {
            try
            {
                datosOriginales = controlAsistencia.ObtenerDatosParaGrid();
                dgwTablaAsistencia.DataSource = datosOriginales;
                ConfigurarGrid();
                ConfigurarGridParaMultiplesLineas(); // Nueva función
                AplicarColoresPorcentaje();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la tabla de asistencias: " + ex.Message,
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarGrid()
        {
            dgwTablaAsistencia.ClearSelection();

            // Ocultar columnas que no queremos mostrar
            if (dgwTablaAsistencia.Columns.Contains("id_alumno"))
                dgwTablaAsistencia.Columns["id_alumno"].Visible = false;

            if (dgwTablaAsistencia.Columns.Contains("cantidad_instrumentos"))
                dgwTablaAsistencia.Columns["cantidad_instrumentos"].Visible = false;

            // Configurar headers
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
                // ⚠️ IMPORTANTE: Formatear la celda para mostrar el símbolo %
                dgwTablaAsistencia.Columns["porcentaje_asistencia"].DefaultCellStyle.Format = "0.00'%'";
            }

            // Ajustar anchos de columnas
            if (dgwTablaAsistencia.Columns.Contains("nombre_alumno"))
                dgwTablaAsistencia.Columns["nombre_alumno"].FillWeight = 100;

            if (dgwTablaAsistencia.Columns.Contains("apellido_alumno"))
                dgwTablaAsistencia.Columns["apellido_alumno"].FillWeight = 100;

            if (dgwTablaAsistencia.Columns.Contains("instrumentos"))
                dgwTablaAsistencia.Columns["instrumentos"].FillWeight = 150;

            if (dgwTablaAsistencia.Columns.Contains("profesores"))
                dgwTablaAsistencia.Columns["profesores"].FillWeight = 150;

            if (dgwTablaAsistencia.Columns.Contains("porcentaje_asistencia"))
                dgwTablaAsistencia.Columns["porcentaje_asistencia"].FillWeight = 80;
        }

        private void ConfigurarGridParaMultiplesLineas()
        {
            // Permitir múltiples líneas en las celdas
            dgwTablaAsistencia.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            // Autoajustar altura de filas según el contenido
            dgwTablaAsistencia.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            // Configurar altura mínima de filas para que se vean bien los saltos de línea
            dgwTablaAsistencia.RowTemplate.MinimumHeight = 40;

            // Configurar específicamente las columnas que tendrán múltiples líneas
            if (dgwTablaAsistencia.Columns.Contains("instrumentos"))
            {
                dgwTablaAsistencia.Columns["instrumentos"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                // Opcional: Centrar verticalmente el contenido
                dgwTablaAsistencia.Columns["instrumentos"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }

            if (dgwTablaAsistencia.Columns.Contains("profesores"))
            {
                dgwTablaAsistencia.Columns["profesores"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dgwTablaAsistencia.Columns["profesores"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }

            // Configurar la columna de porcentaje para que esté centrada
            if (dgwTablaAsistencia.Columns.Contains("porcentaje_asistencia"))
            {
                dgwTablaAsistencia.Columns["porcentaje_asistencia"].DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void AplicarColoresPorcentaje()
        {
            foreach (DataGridViewRow fila in dgwTablaAsistencia.Rows)
            {
                // Aplicar color base alternado para mejor legibilidad
                if (fila.Index % 2 == 0)
                {
                    fila.DefaultCellStyle.BackColor = Color.White;
                }
                else
                {
                    fila.DefaultCellStyle.BackColor = Color.FromArgb(248, 248, 252);
                }

                fila.DefaultCellStyle.ForeColor = Color.FromArgb(64, 64, 64);

                // Aplicar color específico a la celda de porcentaje según el valor
                if (fila.Cells["porcentaje_asistencia"].Value != null &&
                    fila.Cells["porcentaje_asistencia"].Value != DBNull.Value)
                {
                    double porcentaje = Convert.ToDouble(fila.Cells["porcentaje_asistencia"].Value);

                    Color colorPorcentaje;
                    Color colorTexto;

                    if (porcentaje >= 80)
                    {
                        colorPorcentaje = Color.FromArgb(220, 255, 220); // Verde claro
                        colorTexto = Color.FromArgb(0, 100, 0); // Verde oscuro
                    }
                    else if (porcentaje >= 50)
                    {
                        colorPorcentaje = Color.FromArgb(255, 255, 200); // Amarillo claro
                        colorTexto = Color.FromArgb(102, 77, 0); // Marrón
                    }
                    else
                    {
                        colorPorcentaje = Color.FromArgb(255, 220, 220); // Rojo claro
                        colorTexto = Color.FromArgb(120, 0, 0); // Rojo oscuro
                    }

                    // Aplicar solo a la celda de porcentaje
                    fila.Cells["porcentaje_asistencia"].Style.BackColor = colorPorcentaje;
                    fila.Cells["porcentaje_asistencia"].Style.ForeColor = colorTexto;
                    fila.Cells["porcentaje_asistencia"].Style.Font =
                        new Font(dgwTablaAsistencia.Font, FontStyle.Bold);
                }
            }
        }

        private void DgwTablaAsistencia_Sorted(object sender, EventArgs e)
        {
            AplicarColoresPorcentaje();
        }

        private void DgwTablaAsistencia_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            // Mostrar tooltip con el contenido completo cuando hay muchas líneas
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var cell = dgwTablaAsistencia.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (cell.Value != null)
                {
                    cell.ToolTipText = cell.Value.ToString();
                }
            }
        }

        private void MenuAlumnos_Click(object sender, EventArgs e)
        {
            FrmAgregarAlumnos formAlumnos = new();
            formAlumnos.Show();
            this.Hide();
        }

        private void MenuProfesor_Click(object sender, EventArgs e)
        {
            FrmAgregarProfesores formProfesores = new ();
            formProfesores.Show();
            this.Hide();
        }

        private void MenuInstrumentos_Click(object sender, EventArgs e)
        {
            frmAgregarInstrumentos formInstrumentos = new ();
            formInstrumentos.Show();
            this.Hide();
        }

        private void MenuAsistencia_Click(object sender, EventArgs e)
        {
            FrmAgregarAsistencia formAsistencia = new ();
            formAsistencia.Show();
            this.Hide();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MenuListadoAlumnos_Click(object sender, EventArgs e)
        {
            FrmListadoAlumnos formListadoAlumnos = new ();
            formListadoAlumnos.Show();
            this.Hide();
        }

        private void MenuListadoProfesores_Click(object sender, EventArgs e)
        {
            FrmListadoProfesores formListadoProfesores = new ();
            formListadoProfesores.Show();
            this.Hide();
        }

        private void MenuModificarAlumnos_Click(object sender, EventArgs e)
        {
            FrmModificarAlumnos formModificarAlumnos = new ();
            formModificarAlumnos.Show();
            this.Hide();
        }

        private void MenuEliminarAlumnos_Click(object sender, EventArgs e)
        {
            frmEliminarAlumnos formEliminarAlumnos = new ();
            formEliminarAlumnos.Show();
            this.Hide();
        }

        private void MenuModificarProfesores_Click(object sender, EventArgs e)
        {
            FrmModificarProfesores formModificarProfesores = new ();
            formModificarProfesores.Show();
            this.Hide();
        }

        private void MenuEliminarProfesores_Click(object sender, EventArgs e)
        {
            FrmEliminarProfesores formEliminarProfesores = new ();
            formEliminarProfesores.Show();
            this.Hide();
        }

        private void MenuEliminarInstrumentos_Click(object sender, EventArgs e)
        {
            FrmEliminarInstrumento formEliminarInstrumentos = new ();
            formEliminarInstrumentos.Show();
            this.Hide();
        }
    }
}