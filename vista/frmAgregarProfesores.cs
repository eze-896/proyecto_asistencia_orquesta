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

        /// <summary>
        /// Carga inicial del formulario
        /// </summary>
        private void FrmAgregarProfesores_Load(object sender, EventArgs e)
        {
            try
            {
                // Cargar instrumentos disponibles en el ComboBox
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

        /// <summary>
        /// Maneja el clic en el botón Ingresar para registrar un profesor
        /// </summary>
        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            // Validar datos del formulario
            Profesor profesorValidar = new()
            {
                Dni = int.TryParse(txtDni.Text, out int dni) ? dni : 0,
                Nombre = txtNombre.Text.Trim(),
                Apellido = txtApellido.Text.Trim(),
                Telefono = txtTelefono.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Id_instrumento = cmbInstrumentos.SelectedValue as int? ?? 0
            };

            if (!ControlProfesor.ValidarProfesor(profesorValidar))
                return;

            // Verificar selección de instrumento
            if (cmbInstrumentos.SelectedValue is int selectedValue)
            {
                // Crear y registrar profesor
                Profesor profesor = new()
                {
                    Dni = int.Parse(txtDni.Text),
                    Nombre = txtNombre.Text.Trim(),
                    Apellido = txtApellido.Text.Trim(),
                    Telefono = txtTelefono.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Id_instrumento = selectedValue
                };

                bool exito = controlProfesor.RegistrarProfesor(profesor);

                if (exito)
                {
                    // Limpiar formulario después del registro exitoso
                    txtDni.Clear();
                    txtNombre.Clear();
                    txtApellido.Clear();
                    txtTelefono.Clear();
                    txtEmail.Clear();
                    cmbInstrumentos.SelectedIndex = -1;
                    txtNombre.Focus();
                }
            }
            else
            {
                MessageBox.Show("Seleccione un instrumento válido.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Valida que el DNI contenga solo números
        /// </summary>
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

        /// <summary>
        /// Valida que el teléfono contenga solo números
        /// </summary>
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

        /// <summary>
        /// Regresa al formulario principal
        /// </summary>
        private void BtnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmPrincipal formPrincipal = new();
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
        private void FrmAgregarProfesores_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                BtnVolver_Click(sender, e);
            else if (e.KeyCode == Keys.F4 && e.Alt)
                BtnSalir_Click(sender, e);
        }
    }
}