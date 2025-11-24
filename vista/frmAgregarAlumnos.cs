using GUI_Login.control;
using System;
using System.Collections.Generic;
using System.Drawing;
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

        /// <summary>
        /// Carga inicial del formulario
        /// </summary>
        private void FrmAgregarAlumnos_Load(object sender, EventArgs e)
        {
            try
            {
                // Cargar instrumentos disponibles
                List<Instrumento> instrumentos = controlInstrumento.ListarInstrumentosEnOrquesta();
                chkListInstrumentos.DataSource = null;
                chkListInstrumentos.DataSource = instrumentos;
                chkListInstrumentos.DisplayMember = "Nombre";
                chkListInstrumentos.ValueMember = "Id";

                // Desmarcar todos los items
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

        /// <summary>
        /// Maneja el clic en el botón Ingresar para registrar alumno
        /// </summary>
        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            // Validar datos del formulario
            Alumno alumnoValidar = new Alumno
            {
                Dni = int.TryParse(txtDni.Text, out int dni) ? dni : 0,
                Nombre = txtNombre.Text.Trim(),
                Apellido = txtApellido.Text.Trim(),
                Telefono_padres = txtTelePadres.Text.Trim()
            };

            if (!ControlAlumno.ValidarAlumno(alumnoValidar))
                return;

            // Validar selección de instrumentos
            if (chkListInstrumentos.CheckedItems.Count == 0)
            {
                MessageBox.Show("Seleccione al menos un instrumento.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Crear objeto alumno
            Alumno alumno = new Alumno
            {
                Dni = int.Parse(txtDni.Text),
                Nombre = txtNombre.Text.Trim(),
                Apellido = txtApellido.Text.Trim(),
                Telefono_padres = txtTelePadres.Text.Trim()
            };

            // Obtener instrumentos seleccionados
            List<int> idsInstrumentos = new List<int>();
            foreach (var item in chkListInstrumentos.CheckedItems)
            {
                Instrumento instrumento = (Instrumento)item;
                idsInstrumentos.Add(instrumento.Id);
            }

            // Registrar alumno con instrumentos
            bool exito = controlAlumno.RegistrarAlumnoConInstrumentos(alumno, idsInstrumentos);

            if (exito)
            {
                // Limpiar formulario después del registro exitoso
                txtDni.Clear();
                txtNombre.Clear();
                txtApellido.Clear();
                txtTelePadres.Clear();
                for (int i = 0; i < chkListInstrumentos.Items.Count; i++)
                {
                    chkListInstrumentos.SetItemChecked(i, false);
                }
                txtNombre.Focus();
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

        /// <summary>
        /// Efecto visual al entrar en un control
        /// </summary>
        private void Control_Enter(object sender, EventArgs e)
        {
            if (sender is TextBox textBox)
                textBox.BackColor = Color.LightYellow;
        }

        /// <summary>
        /// Efecto visual al salir de un control
        /// </summary>
        private void Control_Leave(object sender, EventArgs e)
        {
            if (sender is TextBox textBox)
                textBox.BackColor = Color.White;
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
        private void FrmAgregarAlumnos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                BtnVolver_Click(sender, e);
            else if (e.KeyCode == Keys.F4 && e.Alt)
                BtnSalir_Click(sender, e);
        }
    }
}