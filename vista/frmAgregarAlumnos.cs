using GUI_Login.control;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GUI_Login.vista
{
    public partial class FrmAgregarAlumnos : Form
    {
        private readonly ControlAlumno controlAlumno;
        private readonly ControlInstrumento controlInstrumento;

        public FrmAgregarAlumnos()
        {
            InitializeComponent();
            controlAlumno = new ControlAlumno();
            controlInstrumento = new ControlInstrumento();
        }

        private void FrmAgregarAlumnos_Load(object sender, EventArgs e)
        {
            CargarCheckListInstrumentos();
        }

        private void CargarCheckListInstrumentos()
        {
            try
            {
                List<Instrumento> instrumentos = controlInstrumento.ListarInstrumentosEnOrquesta();
                chkListInstrumentos.DataSource = null;
                chkListInstrumentos.DataSource = instrumentos;
                chkListInstrumentos.DisplayMember = "Nombre";
                chkListInstrumentos.ValueMember = "Id";

                // Desmarcar todos los items al cargar
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

        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            // Validar campos obligatorios básicos
            if (!ControlAlumno.ValidarCamposObligatorios(
                txtNombre.Text, txtApellido.Text, txtDni.Text, txtTelePadres.Text))
                return;

            // Validar que al menos un instrumento esté seleccionado
            if (chkListInstrumentos.CheckedItems.Count == 0)
            {
                MessageBox.Show("Seleccione al menos un instrumento.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Crear objeto alumno
            Alumno alumno = new()
            {
                Dni = int.Parse(txtDni.Text),
                Nombre = txtNombre.Text.Trim(),
                Apellido = txtApellido.Text.Trim(),
                Telefono_padres = txtTelePadres.Text.Trim()
            };

            // Obtener los IDs de los instrumentos seleccionados
            List<int> idsInstrumentos = [];
            foreach (var item in chkListInstrumentos.CheckedItems)
            {
                Instrumento instrumento = (Instrumento)item;
                idsInstrumentos.Add(instrumento.Id);
            }

            // Registrar alumno con instrumentos
            bool exito = controlAlumno.RegistrarAlumnoConInstrumentos(alumno, idsInstrumentos);

            if (exito)
            {
                LimpiarFormulario();
            }
        }

        private void LimpiarFormulario()
        {
            txtDni.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtTelePadres.Clear();

            // Desmarcar todos los instrumentos
            for (int i = 0; i < chkListInstrumentos.Items.Count; i++)
            {
                chkListInstrumentos.SetItemChecked(i, false);
            }

            txtNombre.Focus();
        }

        // Eventos de UI (sin lógica de negocio)
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

        private void TxtNombre_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                txtNombre.Text = char.ToUpper(txtNombre.Text[0]) + txtNombre.Text[1..].ToLower();
            }
        }

        private void TxtApellido_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                txtApellido.Text = char.ToUpper(txtApellido.Text[0]) + txtApellido.Text[1..].ToLower();
            }
        }

        // Efectos visuales
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

        private void BtnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmPrincipal formPrincipal = new();
            formPrincipal.Show();
        }
        private void BtnSalir_Click(object sender, EventArgs e) => Application.Exit();
        private void FrmAgregarAlumnos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) BtnVolver_Click(sender, e);
        }
    }
}