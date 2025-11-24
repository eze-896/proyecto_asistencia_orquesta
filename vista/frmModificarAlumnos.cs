using GUI_Login.control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GUI_Login.vista
{
    /// <summary>
    /// Formulario para modificar datos de alumnos existentes
    /// Permite actualizar información personal e instrumentos de los alumnos
    /// </summary>
    public partial class FrmModificarAlumnos : Form
    {
        private readonly ControlAlumno controlAlumno;
        private readonly ControlInstrumento controlInstrumento;
        private int idSeleccionado = -1;
        private List<Alumno> listaAlumnos = new List<Alumno>();

        /// <summary>
        /// Constructor que inicializa los controladores necesarios
        /// </summary>
        public FrmModificarAlumnos()
        {
            InitializeComponent();
            controlAlumno = new ControlAlumno();
            controlInstrumento = new ControlInstrumento();
        }

        /// <summary>
        /// Carga inicial del formulario
        /// </summary>
        private void FrmModificarAlumnos_Load(object sender, EventArgs e)
        {
            CargarListaAlumnos();
            CargarCheckListInstrumentos();
            this.KeyPreview = true;
        }

        /// <summary>
        /// Carga la lista de alumnos en el ListBox
        /// </summary>
        private void CargarListaAlumnos()
        {
            listaAlumnos = controlAlumno.ObtenerAlumnos();
            lstAlumnosModificar.DataSource = null;
            lstAlumnosModificar.DataSource = listaAlumnos;
            lstAlumnosModificar.DisplayMember = "NombreCompleto";
            lstAlumnosModificar.ValueMember = "Id";

            // Seleccionar automáticamente el primer alumno si existe
            if (lstAlumnosModificar.Items.Count > 0)
            {
                lstAlumnosModificar.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// Carga los instrumentos disponibles en el CheckedListBox
        /// </summary>
        private void CargarCheckListInstrumentos()
        {
            List<Instrumento> instrumentos = controlInstrumento.ListarInstrumentosEnOrquesta();
            chkListInstrumentos.DataSource = null;
            chkListInstrumentos.DataSource = instrumentos;
            chkListInstrumentos.DisplayMember = "Nombre";
            chkListInstrumentos.ValueMember = "Id";
        }

        /// <summary>
        /// Maneja la selección de un alumno en la lista
        /// </summary>
        private void LstAlumnosModificar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstAlumnosModificar.SelectedItem == null) return;

            Alumno alumno = (Alumno)lstAlumnosModificar.SelectedItem;
            idSeleccionado = alumno.Id;

            // Cargar datos del alumno en los controles
            txtNombre.Text = alumno.Nombre;
            txtApellido.Text = alumno.Apellido;
            txtDni.Text = alumno.Dni.ToString();
            txtTelePadres.Text = alumno.Telefono_padres;

            // Cargar y marcar los instrumentos del alumno
            CargarInstrumentosDelAlumno(idSeleccionado);
        }

        /// <summary>
        /// Carga y marca los instrumentos actuales del alumno seleccionado
        /// </summary>
        private void CargarInstrumentosDelAlumno(int idAlumno)
        {
            // Desmarcar todos los instrumentos primero
            for (int i = 0; i < chkListInstrumentos.Items.Count; i++)
            {
                chkListInstrumentos.SetItemChecked(i, false);
            }

            // Obtener y marcar los instrumentos actuales del alumno
            List<int> instrumentosAlumno = controlAlumno.ObtenerInstrumentosPorAlumno(idAlumno);
            for (int i = 0; i < chkListInstrumentos.Items.Count; i++)
            {
                Instrumento instrumento = (Instrumento)chkListInstrumentos.Items[i];
                if (instrumentosAlumno.Contains(instrumento.Id))
                {
                    chkListInstrumentos.SetItemChecked(i, true);
                }
            }
        }

        /// <summary>
        /// Guarda los cambios realizados en los datos del alumno
        /// </summary>
        private void BtnGuardarCambios_Click(object sender, EventArgs e)
        {
            // Validar que se haya seleccionado un alumno
            if (idSeleccionado <= 0)
            {
                MessageBox.Show("Por favor, seleccione un alumno para modificar.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar campos del formulario
            Alumno alumnoValidar = new Alumno
            {
                Nombre = txtNombre.Text.Trim(),
                Apellido = txtApellido.Text.Trim(),
                Dni = int.TryParse(txtDni.Text.Trim(), out int dni) ? dni : 0,
                Telefono_padres = txtTelePadres.Text.Trim()
            };

            if (!ControlAlumno.ValidarAlumno(alumnoValidar))
                return;

            // Validar que al menos un instrumento esté seleccionado
            if (chkListInstrumentos.CheckedItems.Count == 0)
            {
                MessageBox.Show("Seleccione al menos un instrumento.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Crear objeto alumno con los datos actualizados
            Alumno alumno = new Alumno
            {
                Id = idSeleccionado,
                Nombre = txtNombre.Text.Trim(),
                Apellido = txtApellido.Text.Trim(),
                Dni = int.Parse(txtDni.Text.Trim()),
                Telefono_padres = txtTelePadres.Text.Trim()
            };

            // Obtener instrumentos seleccionados
            List<int> idsInstrumentos = new List<int>();
            foreach (var item in chkListInstrumentos.CheckedItems)
            {
                Instrumento instrumento = (Instrumento)item;
                idsInstrumentos.Add(instrumento.Id);
            }

            // Modificar alumno
            bool exito = controlAlumno.ModificarAlumnoConInstrumentos(alumno, idsInstrumentos);

            if (exito)
            {
                CargarListaAlumnos();

                // Limpiar formulario
                txtNombre.Clear();
                txtApellido.Clear();
                txtDni.Clear();
                txtTelePadres.Clear();
                for (int i = 0; i < chkListInstrumentos.Items.Count; i++)
                {
                    chkListInstrumentos.SetItemChecked(i, false);
                }
                idSeleccionado = -1;
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
        private void FrmModificarAlumnos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                BtnVolver_Click(sender, e);
            else if (e.KeyCode == Keys.F4 && e.Alt)
                BtnSalir_Click(sender, e);
        }
    }
}