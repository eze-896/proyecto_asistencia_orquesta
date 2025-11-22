using GUI_Login.control;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GUI_Login.vista
{
    /// <summary>
    /// Formulario para agregar nuevos alumnos al sistema
    /// Permite registrar alumnos y asignarles instrumentos
    /// </summary>
    public partial class FrmAgregarAlumnos : Form
    {
        private readonly ControlAlumno controlAlumno;
        private readonly ControlInstrumento controlInstrumento;

        /// <summary>
        /// Constructor que inicializa los controladores necesarios
        /// </summary>
        public FrmAgregarAlumnos()
        {
            InitializeComponent();
            controlAlumno = new ControlAlumno();
            controlInstrumento = new ControlInstrumento();
        }

        // ==================== MÉTODOS DE CARGA Y CONFIGURACIÓN ====================

        private void FrmAgregarAlumnos_Load(object sender, EventArgs e)
        {
            CargarCheckListInstrumentos();
        }

        /// <summary>
        /// Carga la lista de instrumentos disponibles en el CheckedListBox
        /// </summary>
        private void CargarCheckListInstrumentos()
        {
            try
            {
                List<Instrumento> instrumentos = controlInstrumento.ListarInstrumentosEnOrquesta();
                chkListInstrumentos.DataSource = null;
                chkListInstrumentos.DataSource = instrumentos;
                chkListInstrumentos.DisplayMember = "Nombre";
                chkListInstrumentos.ValueMember = "Id";

                // Desmarca todos los items al cargar
                for (int i = 0; i < chkListInstrumentos.Items.Count; i++)
                {
                    chkListInstrumentos.SetItemChecked(i, false);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar instrumentos: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==================== OPERACIONES PRINCIPALES ====================

        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            if (!ValidarFormularioCompleto())
                return;

            Alumno alumno = CrearObjetoAlumno();
            List<int> idsInstrumentos = ObtenerInstrumentosSeleccionados();

            // Registra alumno con instrumentos
            bool exito = controlAlumno.RegistrarAlumnoConInstrumentos(alumno, idsInstrumentos);

            if (exito)
            {
                LimpiarFormulario();
            }
        }

        /// <summary>
        /// Valida todos los campos del formulario
        /// </summary>
        /// <returns>True si todos los campos son válidos</returns>
        private bool ValidarFormularioCompleto()
        {
            if (!ControlAlumno.ValidarAlumno(
                nombre: txtNombre.Text,
                apellido: txtApellido.Text,
                dni: txtDni.Text,
                telefono: txtTelePadres.Text))
                return false;

            // Valida que al menos un instrumento esté seleccionado
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
        /// <returns>Objeto Alumno con los datos ingresados</returns>
        private Alumno CrearObjetoAlumno()
        {
            return new Alumno
            {
                Dni = int.Parse(txtDni.Text),
                Nombre = txtNombre.Text.Trim(),
                Apellido = txtApellido.Text.Trim(),
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
            txtDni.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtTelePadres.Clear();

            // Desmarca todos los instrumentos
            for (int i = 0; i < chkListInstrumentos.Items.Count; i++)
            {
                chkListInstrumentos.SetItemChecked(i, false);
            }

            txtNombre.Focus();
        }

        // ==================== VALIDACIONES EN TIEMPO REAL ====================

        private void TxtDni_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtDni.Text) && !int.TryParse(txtDni.Text, out _))
            {
                MessageBox.Show("El DNI debe ser un número válido.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDni.Clear();
                txtDni.Focus();
            }
        }

        private void TxtTelePadres_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtTelePadres.Text) && !long.TryParse(txtTelePadres.Text, out _))
            {
                MessageBox.Show("El teléfono debe ser un número válido.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTelePadres.Clear();
                txtTelePadres.Focus();
            }
        }

        /// <summary>
        /// Formatea el nombre con la primera letra mayúscula
        /// </summary>
        private void TxtNombre_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                txtNombre.Text = char.ToUpper(txtNombre.Text[0]) + txtNombre.Text.Substring(1).ToLower();
            }
        }

        /// <summary>
        /// Formatea el apellido con la primera letra mayúscula
        /// </summary>
        private void TxtApellido_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                txtApellido.Text = char.ToUpper(txtApellido.Text[0]) + txtApellido.Text.Substring(1).ToLower();
            }
        }

        // ==================== EFECTOS VISUALES ====================

        private void Control_Enter(object sender, EventArgs e)
        {
            if (sender is TextBox textBox)
                textBox.BackColor = Color.LightYellow;
        }

        private void Control_Leave(object sender, EventArgs e)
        {
            if (sender is TextBox textBox)
                textBox.BackColor = Color.White;
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

        private void FrmAgregarAlumnos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                BtnVolver_Click(sender, e);
            else if (e.KeyCode == Keys.F4 && e.Alt)
                BtnSalir_Click(sender, e);
        }
    }
}