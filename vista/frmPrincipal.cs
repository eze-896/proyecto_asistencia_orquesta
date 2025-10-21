using GUI_Login.vista;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;

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

            // Ocultar columna ID
            if (dgwTablaAsistencia.Columns.Contains("id_alumno"))
                dgwTablaAsistencia.Columns["id_alumno"].Visible = false;

            // Configurar headers con nombres más cortos y claros
            if (dgwTablaAsistencia.Columns.Contains("nombre_alumno"))
                dgwTablaAsistencia.Columns["nombre_alumno"].HeaderText = "Alumno";

            if (dgwTablaAsistencia.Columns.Contains("apellido_alumno"))
                dgwTablaAsistencia.Columns["apellido_alumno"].HeaderText = "Apellido";

            if (dgwTablaAsistencia.Columns.Contains("nombre_instrumento"))
                dgwTablaAsistencia.Columns["nombre_instrumento"].HeaderText = "Instrumento";

            if (dgwTablaAsistencia.Columns.Contains("nombre_profesor"))
                dgwTablaAsistencia.Columns["nombre_profesor"].HeaderText = "Profesor";

            if (dgwTablaAsistencia.Columns.Contains("apellido_profesor"))
                dgwTablaAsistencia.Columns["apellido_profesor"].HeaderText = "Apellido P.";

            if (dgwTablaAsistencia.Columns.Contains("porcentaje_asistencia"))
                dgwTablaAsistencia.Columns["porcentaje_asistencia"].HeaderText = "% Asistencia";

            if (dgwTablaAsistencia.Columns.Contains("apellido_profesor"))
                dgwTablaAsistencia.Columns["apellido_profesor"].FillWeight = 80;

            if (dgwTablaAsistencia.Columns.Contains("nombre_profesor"))
                dgwTablaAsistencia.Columns["nombre_profesor"].FillWeight = 100;

            if (dgwTablaAsistencia.Columns.Contains("porcentaje_asistencia"))
                dgwTablaAsistencia.Columns["porcentaje_asistencia"].FillWeight = 90;
        }

        private void AplicarColoresPorcentaje()
        {
            foreach (DataGridViewRow fila in dgwTablaAsistencia.Rows)
            {
                if (fila.Cells["porcentaje_asistencia"].Value != null &&
                    fila.Cells["porcentaje_asistencia"].Value != DBNull.Value)
                {
                    double porcentaje = Convert.ToDouble(fila.Cells["porcentaje_asistencia"].Value);

                    // Colores más suaves y texto oscuro para mejor legibilidad
                    if (porcentaje >= 80)
                    {
                        fila.DefaultCellStyle.BackColor = Color.FromArgb(220, 255, 220); // Verde muy claro
                        fila.DefaultCellStyle.ForeColor = Color.FromArgb(0, 80, 0); // Verde oscuro para texto
                    }
                    else if (porcentaje >= 50)
                    {
                        fila.DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 200); // Amarillo claro
                        fila.DefaultCellStyle.ForeColor = Color.FromArgb(102, 77, 0); // Marrón oscuro para texto
                    }
                    else
                    {
                        fila.DefaultCellStyle.BackColor = Color.FromArgb(255, 220, 220); // Rojo muy claro
                        fila.DefaultCellStyle.ForeColor = Color.FromArgb(120, 0, 0); // Rojo oscuro para texto
                    }

                    // Formatear el porcentaje para mostrar 2 decimales
                    if (fila.Cells["porcentaje_asistencia"].Value != null)
                    {
                        fila.Cells["porcentaje_asistencia"].Value =
                            Math.Round(Convert.ToDouble(fila.Cells["porcentaje_asistencia"].Value), 2);
                    }
                }
                else
                {
                    // Para filas sin porcentaje, usar colores neutros
                    fila.DefaultCellStyle.BackColor = Color.White;
                    fila.DefaultCellStyle.ForeColor = Color.FromArgb(64, 64, 64);
                }
            }
        }

        private void DgwTablaAsistencia_Sorted(object sender, EventArgs e)
        {
            AplicarColoresPorcentaje();
        }

        private void MenuAlumnos_Click(object sender, EventArgs e)
        {
            frmAgregarAlumnos formAlumnos = new();
            formAlumnos.Show();
            this.Hide();
        }

        private void MenuProfesor_Click(object sender, EventArgs e)
        {
            frmAgregarProfesores formProfesores = new ();
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
            frmAgregarAsistencia formAsistencia = new ();
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
            frmListadoProfesores formListadoProfesores = new ();
            formListadoProfesores.Show();
            this.Hide();
        }

        private void MenuModificarAlumnos_Click(object sender, EventArgs e)
        {
            frmModificarAlumnos formModificarAlumnos = new ();
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
            frmModificarProfesores formModificarProfesores = new ();
            formModificarProfesores.Show();
            this.Hide();
        }

        private void MenuEliminarProfesores_Click(object sender, EventArgs e)
        {
            frmEliminarProfesores formEliminarProfesores = new ();
            formEliminarProfesores.Show();
            this.Hide();
        }

        private void MenuEliminarInstrumentos_Click(object sender, EventArgs e)
        {
            frmEliminarInstrumento formEliminarInstrumentos = new ();
            formEliminarInstrumentos.Show();
            this.Hide();
        }
    }
}