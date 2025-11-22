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

        // ==================== MÉTODOS DE CARGA Y CONFIGURACIÓN ====================

        private void FrmModificarAlumnos_Load(object sender, EventArgs e)
        {
            CargarListaAlumnos();
            CargarCheckListInstrumentos();
            this.KeyPreview = true;
        }

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

        private void CargarCheckListInstrumentos()
        {
            List<Instrumento> instrumentos = controlInstrumento.ListarInstrumentosEnOrquesta();
            chkListInstrumentos.DataSource = null;
            chkListInstrumentos.DataSource = instrumentos;
            chkListInstrumentos.DisplayMember = "Nombre";
            chkListInstrumentos.ValueMember = "Id";
        }

        // ==================== MANEJO DE SELECCIONES ====================

        private void LstAlumnosModificar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstAlumnosModificar.SelectedItem == null) return;

            Alumno alumno = (Alumno)lstAlumnosModificar.SelectedItem;
            idSeleccionado = alumno.Id;

            CargarDatosAlumno(alumno);
            CargarInstrumentosDelAlumno(idSeleccionado);
        }

        /// <summary>
        /// Carga los datos del alumno seleccionado en los controles
        /// </summary>
        /// <param name="alumno">Alumno seleccionado</param>
        private void CargarDatosAlumno(Alumno alumno)
        {
            txtNombre.Text = alumno.Nombre;
            txtApellido.Text = alumno.Apellido;
            txtDni.Text = alumno.Dni.ToString();
            txtTelePadres.Text = alumno.Telefono_padres;
        }

        /// <summary>
        /// Carga y marca los instrumentos actuales del alumno
        /// </summary>
        /// <param name="idAlumno">ID del alumno</param>
        private void CargarInstrumentosDelAlumno(int idAlumno)
        {
            // Desmarcar todos los instrumentos primero
            for (int i = 0; i < chkListInstrumentos.Items.Count; i++)
            {
                chkListInstrumentos.SetItemChecked(i, false);
            }

            // Obtener los instrumentos actuales del alumno
            List<int> instrumentosAlumno = controlAlumno.ObtenerInstrumentosPorAlumno(idAlumno);

            // Marcar los instrumentos que el alumno ya tiene
            for (int i = 0; i < chkListInstrumentos.Items.Count; i++)
            {
                Instrumento instrumento = (Instrumento)chkListInstrumentos.Items[i];
                if (instrumentosAlumno.Contains(instrumento.Id))
                {
                    chkListInstrumentos.SetItemChecked(i, true);
                }
            }
        }

        // ==================== OPERACIONES PRINCIPALES ====================

        private void BtnGuardarCambios_Click(object sender, EventArgs e)
        {
            if (!ValidarSeleccionAlumno())
                return;

            if (!ValidarFormularioCompleto())
                return;

            if (!ControlAlumno.ConfirmarModificacion())
                return;

            Alumno alumno = CrearObjetoAlumno();
            List<int> idsInstrumentos = ObtenerInstrumentosSeleccionados();

            // Modificar alumno con sus instrumentos
            bool exito = controlAlumno.ModificarAlumnoConInstrumentos(alumno, idsInstrumentos);

            if (exito)
            {
                CargarListaAlumnos();
                LimpiarFormulario();
            }
        }

        /// <summary>
        /// Valida que se haya seleccionado un alumno
        /// </summary>
        /// <returns>True si hay un alumno seleccionado</returns>
        private bool ValidarSeleccionAlumno()
        {
            if (idSeleccionado <= 0)
            {
                MessageBox.Show("Por favor, seleccione un alumno para modificar.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Valida todos los campos del formulario
        /// </summary>
        /// <returns>True si todos los campos son válidos</returns>
        private bool ValidarFormularioCompleto()
        {
            // Usar ValidarAlumno directamente
            if (!ControlAlumno.ValidarAlumno(
                nombre: txtNombre.Text,
                apellido: txtApellido.Text,
                dni: txtDni.Text,
                telefono: txtTelePadres.Text))
                return false;

            // Validar que al menos un instrumento esté seleccionado
            if (chkListInstrumentos.CheckedItems.Count == 0)
            {
                MessageBox.Show("Seleccione al menos un instrumento.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Crea un objeto Alumno con los datos del formulario
        /// </summary>
        /// <returns>Objeto Alumno con los datos actualizados</returns>
        private Alumno CrearObjetoAlumno()
        {
            return new Alumno
            {
                Id = idSeleccionado,
                Nombre = txtNombre.Text.Trim(),
                Apellido = txtApellido.Text.Trim(),
                Dni = int.Parse(txtDni.Text.Trim()),
                Telefono_padres = txtTelePadres.Text.Trim()
            };
        }

        /// <summary>
        /// Obtiene los IDs de los instrumentos seleccionados
        /// </summary>
        /// <returns>Lista de IDs de instrumentos seleccionados</returns>
        private List<int> ObtenerInstrumentosSeleccionados()
        {
            List<int> idsInstrumentos = new List<int>();
            foreach (var item in chkListInstrumentos.CheckedItems)
            {
                Instrumento instrumento = (Instrumento)item;
                idsInstrumentos.Add(instrumento.Id);
            }
            return idsInstrumentos;
        }

        // ==================== MÉTODOS AUXILIARES ====================

        /// <summary>
        /// Limpia todos los campos del formulario
        /// </summary>
        private void LimpiarFormulario()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtDni.Clear();
            txtTelePadres.Clear();

            // Desmarcar todos los instrumentos
            for (int i = 0; i < chkListInstrumentos.Items.Count; i++)
            {
                chkListInstrumentos.SetItemChecked(i, false);
            }

            idSeleccionado = -1;
        }

        // ==================== NAVEGACIÓN Y CIERRE ====================

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

        private void FrmModificarAlumnos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                BtnVolver_Click(sender, e);
            else if (e.KeyCode == Keys.F4 && e.Alt)
                BtnSalir_Click(sender, e);
        }
    }
}