using GUI_Login.control;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GUI_Login.vista
{
    /// <summary>
    /// Formulario para agregar nuevos profesores al sistema
    /// Permite registrar profesores y asignarles el instrumento que enseñan
    /// </summary>
    public partial class FrmAgregarProfesores : Form
    {
        private readonly ControlProfesor controlProfesor;
        private readonly ControlInstrumento controlInstrumento;

        /// <summary>
        /// Constructor que inicializa los controladores necesarios
        /// </summary>
        public FrmAgregarProfesores()
        {
            InitializeComponent();
            controlProfesor = new ControlProfesor();
            controlInstrumento = new ControlInstrumento();
        }

        // ==================== MÉTODOS DE CARGA Y CONFIGURACIÓN ====================

        private void FrmAgregarProfesores_Load(object sender, EventArgs e)
        {
            CargarInstrumentos();
        }

        /// <summary>
        /// Carga los instrumentos disponibles en el ComboBox
        /// </summary>
        private void CargarInstrumentos()
        {
            try
            {
                List<Instrumento> instrumentos = controlInstrumento.ListarInstrumentosEnOrquesta();
                cmbInstrumentos.DataSource = null;
                cmbInstrumentos.DataSource = instrumentos;
                cmbInstrumentos.DisplayMember = "Nombre";
                cmbInstrumentos.ValueMember = "Id";
                cmbInstrumentos.SelectedIndex = -1;
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
            if (!ControlProfesor.ValidarProfesor(
                nombre: txtNombre.Text,
                apellido: txtApellido.Text,
                dni: txtDni.Text,
                telefono: txtTelefono.Text,
                email: txtEmail.Text,
                idInstrumento: cmbInstrumentos.SelectedValue as int?))
                return;

            if (cmbInstrumentos.SelectedValue is int selectedValue)
            {
                // Crea objeto profesor
                Profesor profesor = new()
                {
                    Dni = int.Parse(txtDni.Text),
                    Nombre = txtNombre.Text.Trim(),
                    Apellido = txtApellido.Text.Trim(),
                    Telefono = txtTelefono.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Id_instrumento = selectedValue
                };

                // Registra profesor
                bool exito = controlProfesor.RegistrarProfesor(profesor);

                if (exito)
                {
                    LimpiarFormulario();
                }
            }
            else
            {
                MessageBox.Show("Seleccione un instrumento válido.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Limpia todos los campos del formulario
        /// </summary>
        private void LimpiarFormulario()
        {
            txtDni.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
            cmbInstrumentos.SelectedIndex = -1;
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

        private void TxtTelefono_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtTelefono.Text) && !long.TryParse(txtTelefono.Text, out _))
            {
                MessageBox.Show("El teléfono debe ser un número válido.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTelefono.Clear();
                txtTelefono.Focus();
            }
        }

        // ==================== NAVEGACIÓN Y CIERRE ====================

        private void BtnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmPrincipal formPrincipal = new();
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

        private void FrmAgregarProfesores_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                BtnVolver_Click(sender, e);
            else if (e.KeyCode == Keys.F4 && e.Alt)
                BtnSalir_Click(sender, e);
        }
    }
}