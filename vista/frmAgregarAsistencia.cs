using GUI_Login.control;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GUI_Login.vista
{
    public partial class FrmAgregarAsistencia : Form
    {
        private readonly ControlAsistencia controlAsistencia;
        private List<Alumno> listaAlumnos;
        private Dictionary<string, int> mapaAlumnos; // CORREGIDO: Mapa para relacionar items con IDs

        public FrmAgregarAsistencia()
        {
            InitializeComponent();
            controlAsistencia = new ControlAsistencia();
            listaAlumnos = new List<Alumno>();
            mapaAlumnos = new Dictionary<string, int>();
        }

        private void FrmAgregarAsistencia_Load(object sender, EventArgs e)
        {
            datePicker.Value = DateTime.Today;
            cmbActividad.DataSource = Enum.GetValues(typeof(Asistencia.Tipo_Actividad));

            CargarAlumnos();
            this.KeyPreview = true;
        }

        private void CargarAlumnos()
        {
            try
            {
                listaAlumnos = controlAsistencia.ObtenerAlumnos();
                chkListaAlumnos.Items.Clear();
                mapaAlumnos.Clear(); // CORREGIDO: Limpiar mapa

                foreach (Alumno alumno in listaAlumnos)
                {
                    string itemText = $"{alumno.Nombre} {alumno.Apellido}";
                    chkListaAlumnos.Items.Add(itemText, false);
                    mapaAlumnos[itemText] = alumno.Id; // CORREGIDO: Guardar relación
                }

                if (listaAlumnos.Count == 0)
                {
                    MessageBox.Show("No hay alumnos registrados en el sistema.",
                        "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                // CORREGIDO: Ahora captura excepciones del Controlador
                MessageBox.Show($"Error al cargar alumnos: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarFormulario())
                return;

            List<Asistencia> asistencias = CrearListaAsistencias();

            if (!ConfirmarGuardado(asistencias))
                return;

            EjecutarGuardado(asistencias);
        }

        private bool ValidarFormulario()
        {
            if (cmbActividad.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione una actividad.", "Validación",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbActividad.Focus();
                return false;
            }

            if (chkListaAlumnos.Items.Count == 0)
            {
                MessageBox.Show("No hay alumnos cargados.", "Validación",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (chkListaAlumnos.CheckedItems.Count == 0)
            {
                MessageBox.Show("Seleccione al menos un alumno como presente.", "Validación",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private List<Asistencia> CrearListaAsistencias()
        {
            DateTime fecha = datePicker.Value.Date;
            Asistencia.Tipo_Actividad actividad = (Asistencia.Tipo_Actividad)cmbActividad.SelectedItem;
            List<Asistencia> asistencias = new List<Asistencia>();

            // CORREGIDO: Mapeo seguro usando el diccionario
            for (int i = 0; i < chkListaAlumnos.Items.Count; i++)
            {
                string itemText = chkListaAlumnos.Items[i].ToString();

                if (mapaAlumnos.TryGetValue(itemText, out int idAlumno))
                {
                    bool estaPresente = chkListaAlumnos.GetItemChecked(i);

                    asistencias.Add(new Asistencia
                    {
                        IdAlumno = idAlumno,
                        Fecha = fecha,
                        TipoActividad = actividad,
                        Presente = estaPresente
                    });
                }
            }

            return asistencias;
        }

        private bool ConfirmarGuardado(List<Asistencia> asistencias)
        {
            int presentes = asistencias.FindAll(a => a.Presente).Count;
            int ausentes = asistencias.Count - presentes;
            DateTime fecha = datePicker.Value.Date;
            Asistencia.Tipo_Actividad actividad = (Asistencia.Tipo_Actividad)cmbActividad.SelectedItem;

            DialogResult resultado = MessageBox.Show(
                $"¿Guardar asistencias para {fecha:dd/MM/yyyy} - {actividad}?\n\n" +
                $"📊 Resumen:\n" +
                $"✅ Presentes: {presentes}\n" +
                $"❌ Ausentes: {ausentes}\n" +
                $"📝 Total: {asistencias.Count}",
                "Confirmar Guardado",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            return resultado == DialogResult.Yes;
        }

        private void EjecutarGuardado(List<Asistencia> asistencias)
        {
            try
            {
                bool guardado = controlAsistencia.GuardarAsistencias(asistencias);

                if (guardado)
                {
                    MessageBox.Show("Asistencias guardadas correctamente.",
                                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarSeleccion();
                }
                else
                {
                    MessageBox.Show("Hubo errores al guardar algunas asistencias.",
                                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                // CORREGIDO: Ahora captura excepciones del Controlador
                MessageBox.Show($"Error inesperado al guardar asistencias: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarSeleccion()
        {
            for (int i = 0; i < chkListaAlumnos.Items.Count; i++)
            {
                chkListaAlumnos.SetItemChecked(i, false);
            }
        }

        private void BtnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmPrincipal formPrincipal = new FrmPrincipal();
            formPrincipal.Show();
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

        private void FrmAgregarAsistencia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                BtnVolver_Click(sender, e);
            else if (e.KeyCode == Keys.F4 && e.Alt)
                BtnSalir_Click(sender, e);
        }
    }
}