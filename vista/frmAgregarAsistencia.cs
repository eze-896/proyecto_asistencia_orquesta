using GUI_Login.control;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GUI_Login.vista
{
    /// <summary>
    /// Formulario para registrar asistencias de alumnos a actividades
    /// Permite marcar presentes/ausentes para diferentes tipos de actividades
    /// </summary>
    public partial class FrmAgregarAsistencia : Form
    {
        private readonly ControlAsistencia controlAsistencia;
        private List<Alumno> listaAlumnos;

        public FrmAgregarAsistencia()
        {
            InitializeComponent();
            controlAsistencia = new ControlAsistencia();
            listaAlumnos = [];
        }

        private void FrmAgregarAsistencia_Load(object sender, EventArgs e)
        {
            // Configura valores iniciales
            datePicker.Value = DateTime.Today;
            cmbActividad.DataSource = Enum.GetValues(typeof(Asistencia.Tipo_Actividad));

            CargarAlumnos();
        }

        /// <summary>
        /// Carga la lista de alumnos en el CheckedListBox
        /// </summary>
        private void CargarAlumnos()
        {
            try
            {
                listaAlumnos = controlAsistencia.ObtenerAlumnos();
                chkListaAlumnos.Items.Clear();

                foreach (Alumno alumno in listaAlumnos)
                {
                    chkListaAlumnos.Items.Add($"{alumno.Nombre} {alumno.Apellido}", false);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar alumnos: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validación: actividad
                if (cmbActividad.SelectedIndex == -1)
                {
                    MessageBox.Show("Seleccione una actividad.", "Validación",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbActividad.Focus();
                    return;
                }

                // Validación: alumnos cargados
                if (chkListaAlumnos.Items.Count == 0)
                {
                    MessageBox.Show("No hay alumnos cargados.", "Validación",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DateTime fecha = datePicker.Value.Date;
                Asistencia.Tipo_Actividad actividad =
                    (Asistencia.Tipo_Actividad)cmbActividad.SelectedItem!;

                List<Asistencia> asistencias = [];

                // Crea lista de asistencias
                for (int i = 0; i < chkListaAlumnos.Items.Count; i++)
                {
                    if (i >= listaAlumnos.Count)
                        continue;

                    bool estaPresente = chkListaAlumnos.GetItemChecked(i);

                    asistencias.Add(new Asistencia
                    {
                        IdAlumno = listaAlumnos[i].Id,
                        Fecha = fecha,
                        TipoActividad = actividad,
                        Presente = estaPresente
                    });
                }

                // Previsualización de resumen
                int presentes = asistencias.FindAll(a => a.Presente).Count;
                int ausentes = asistencias.Count - presentes;

                DialogResult resultado = MessageBox.Show(
                    $"¿Guardar asistencias para {fecha:dd/MM/yyyy} - {actividad}?\n" +
                    $"Presentes: {presentes} | Ausentes: {ausentes}",
                    "Confirmar",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                // Si NO confirma → cortar
                if (resultado != DialogResult.Yes)
                    return;

                // Intenta guardar
                bool guardado = controlAsistencia.GuardarAsistencias(asistencias);

                if (!guardado)
                {
                    MessageBox.Show("Hubo errores al guardar algunas asistencias.",
                                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                MessageBox.Show("Asistencias guardadas correctamente.",
                                "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpia selección
                for (int i = 0; i < chkListaAlumnos.Items.Count; i++)
                {
                    chkListaAlumnos.SetItemChecked(i, false);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}", "Error",
                                 MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Navegación y cierre
        private void BtnVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmPrincipal formPrincipal = new();
            formPrincipal.Show();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmAgregarAsistencia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                BtnVolver_Click(sender, e);
            }
        }
    }
}