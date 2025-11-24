using GUI_Login.control;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GUI_Login.vista
{
    /// <summary>
    /// Formulario para registrar asistencias de alumnos
    /// Permite marcar alumnos presentes/ausentes por actividad y fecha
    /// </summary>
    public partial class FrmAgregarAsistencia : Form
    {
        private readonly ControlAsistencia controlAsistencia;
        private List<Alumno> listaAlumnos;
        private Dictionary<string, int> mapaAlumnos;

        /// <summary>
        /// Constructor que inicializa controladores y estructuras de datos
        /// </summary>
        public FrmAgregarAsistencia()
        {
            InitializeComponent();
            controlAsistencia = new ControlAsistencia();
            listaAlumnos = new List<Alumno>();
            mapaAlumnos = new Dictionary<string, int>();
        }

        /// <summary>
        /// Carga inicial del formulario
        /// </summary>
        private void FrmAgregarAsistencia_Load(object sender, EventArgs e)
        {
            datePicker.Value = DateTime.Today;
            cmbActividad.DataSource = Enum.GetValues(typeof(Asistencia.Tipo_Actividad));
            CargarAlumnos();
            this.KeyPreview = true;
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
                mapaAlumnos.Clear();

                foreach (Alumno alumno in listaAlumnos)
                {
                    string itemText = $"{alumno.Nombre} {alumno.Apellido}";
                    chkListaAlumnos.Items.Add(itemText, false);
                    mapaAlumnos[itemText] = alumno.Id;
                }

                if (listaAlumnos.Count == 0)
                {
                    MessageBox.Show("No hay alumnos registrados en el sistema.",
                        "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar alumnos: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Maneja el clic en el botón Guardar para registrar asistencias
        /// </summary>
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            // Validar formulario
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

            if (chkListaAlumnos.CheckedItems.Count == 0)
            {
                MessageBox.Show("Seleccione al menos un alumno como presente.", "Validación",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Crear lista de asistencias
            DateTime fecha = datePicker.Value.Date;
            Asistencia.Tipo_Actividad actividad = (Asistencia.Tipo_Actividad)cmbActividad.SelectedItem;
            List<Asistencia> asistencias = new List<Asistencia>();

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

            // Confirmar guardado
            int presentes = asistencias.FindAll(a => a.Presente).Count;
            int ausentes = asistencias.Count - presentes;

            DialogResult resultado = MessageBox.Show(
                $"¿Guardar asistencias para {fecha:dd/MM/yyyy} - {actividad}?\n\n" +
                $"📊 Resumen:\n" +
                $"✅ Presentes: {presentes}\n" +
                $"❌ Ausentes: {ausentes}\n" +
                $"📝 Total: {asistencias.Count}",
                "Confirmar Guardado",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado != DialogResult.Yes)
                return;

            // Ejecutar guardado
            try
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
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado al guardar asistencias: {ex.Message}",
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
        private void FrmAgregarAsistencia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                BtnVolver_Click(sender, e);
            else if (e.KeyCode == Keys.F4 && e.Alt)
                BtnSalir_Click(sender, e);
        }
    }
}