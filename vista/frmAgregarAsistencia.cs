using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GUI_Login.vista
{
    public partial class frmAgregarAsistencia : Form
    {
        private ControlAsistencia controlAsistencia;
        private List<Alumno> listaAlumnos;

        public frmAgregarAsistencia()
        {
            InitializeComponent();
            controlAsistencia = new ControlAsistencia();
        }

        private void frmAgregarAsistencia_Load(object sender, EventArgs e)
        {
            datePicker.Value = DateTime.Today;
            cmbActividad.DataSource = Enum.GetValues(typeof(Asistencia.Tipo_Actividad));

            // Cargar alumnos
            listaAlumnos = controlAsistencia.ObtenerAlumnos();
            chkListaAlumnos.Items.Clear();

            foreach (Alumno alumno in listaAlumnos)
            {
                chkListaAlumnos.Items.Add($"{alumno.Nombre} {alumno.Apellido}", false);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validaciones...
                if (cmbActividad.SelectedIndex == -1)
                {
                    MessageBox.Show("Seleccione una actividad.", "Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbActividad.Focus();
                    return;
                }

                if (chkListaAlumnos.Items.Count == 0)
                {
                    MessageBox.Show("No hay alumnos cargados.", "Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DateTime fecha = datePicker.Value.Date;
                Asistencia.Tipo_Actividad actividad = (Asistencia.Tipo_Actividad)cmbActividad.SelectedItem;

                List<Asistencia> asistencias = new List<Asistencia>();

                // 🔹 Guardar todos los alumnos (presentes e inasistentes)
                for (int i = 0; i < chkListaAlumnos.Items.Count; i++)
                {
                    if (i < listaAlumnos.Count)
                    {
                        bool estaPresente = chkListaAlumnos.GetItemChecked(i);

                        Asistencia a = new Asistencia
                        {
                            IdAlumno = listaAlumnos[i].Id,
                            Fecha = fecha,
                            TipoActividad = actividad,
                            Presente = estaPresente
                        };

                        asistencias.Add(a);
                    }
                }

                DialogResult resultado = MessageBox.Show(
                    $"¿Guardar asistencias para {fecha:dd/MM/yyyy} - {actividad}?\n" +
                    $"Presentes: {asistencias.FindAll(a => a.Presente).Count} | " +
                    $"Ausentes: {asistencias.FindAll(a => !a.Presente).Count}",
                    "Confirmar",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    bool guardado = controlAsistencia.GuardarAsistencias(asistencias);

                    if (guardado)
                    {
                        MessageBox.Show("Asistencias guardadas correctamente.",
                                      "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Limpiar selección
                        for (int i = 0; i < chkListaAlumnos.Items.Count; i++)
                        {
                            chkListaAlumnos.SetItemChecked(i, false);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Hubo errores al guardar algunas asistencias.",
                                      "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmPrincipal formPrincipal = new FrmPrincipal();
            formPrincipal.Show();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmAgregarAsistencia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnVolver_Click(sender, e);
            }
        }
    }
}