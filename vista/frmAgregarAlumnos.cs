using GUI_Login.vista;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_Login.vista
{
    public partial class frmAgregarAlumnos : Form
    {
        private ControlInstrumento controlInstrumento;
        public frmAgregarAlumnos()
        {
            InitializeComponent();
            controlInstrumento = new ControlInstrumento();
        }

        private void txtDni_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtDni.Text))
            {
                if (!int.TryParse(txtDni.Text, out _))
                {
                    MessageBox.Show("El DNI debe ser un número válido.");
                    txtDni.Clear();
                    txtDni.Focus();
                }
            }
        }

        private void txtTelePadres_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtTelePadres.Text))
            {
                if (!long.TryParse(txtTelePadres.Text, out _))
                {
                    MessageBox.Show("El teléfono debe ser un número válido.");
                    txtTelePadres.Clear();
                    txtTelePadres.Focus();
                }
            }
        }

        private void txtTelePadres_Enter(object sender, EventArgs e)
        {
            txtTelePadres.BackColor = Color.LightYellow;
        }

        private void txtDni_Enter(object sender, EventArgs e)
        {
            txtDni.BackColor = Color.LightYellow;
        }

        private void txtApellido_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                txtApellido.Text = char.ToUpper(txtApellido.Text[0]) + txtApellido.Text.Substring(1).ToLower();
            }
        }

        private void txtNombre_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                txtNombre.Text = char.ToUpper(txtNombre.Text[0]) + txtNombre.Text.Substring(1).ToLower();
            }
        }

        private void txtApellido_Enter(object sender, EventArgs e)
        {
            txtApellido.BackColor = Color.LightYellow;
        }

        private void txtNombre_Enter(object sender, EventArgs e)
        {
            txtNombre.BackColor = Color.LightYellow;
        }
        private void frmAlumnos_Load(object sender, EventArgs e)
        {
            List<Instrumento> instrumentos = controlInstrumento.ListarInstrumentosEnOrquesta();
            cmbInstrumentos.DataSource = null;
            cmbInstrumentos.DataSource = instrumentos;
            cmbInstrumentos.DisplayMember = "Nombre";
            cmbInstrumentos.ValueMember = "Id";
            cmbInstrumentos.SelectedIndex = -1;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDni.Text) ||
                string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellido.Text) ||
                string.IsNullOrWhiteSpace(txtTelePadres.Text) ||
                cmbInstrumentos.SelectedIndex == -1)
            {
                MessageBox.Show("Todos los campos son obligatorios.");
                return;
            }

            Alumno alumno = new Alumno
            {
                Dni = int.Parse(txtDni.Text),
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Telefono_padres = txtTelePadres.Text
            };

            ControlAlumno controlAlumno = new ControlAlumno();
            int idAlumno = controlAlumno.RegistrarAlumnoYObtenerId(alumno); // método nuevo que devuelve el ID

            if (idAlumno > 0)
            {
                // Ahora guardamos la relación alumno-instrumento
                int idInstrumento = (int)cmbInstrumentos.SelectedValue;

                ControlAlumnoInstrumento controlRel = new ControlAlumnoInstrumento();
                bool relacionInsertada = controlRel.RegistrarRelacion(idAlumno, idInstrumento);

                if (relacionInsertada)
                {
                    MessageBox.Show("Alumno registrado correctamente junto a su instrumento.");

                    txtDni.Clear();
                    txtNombre.Clear();
                    txtApellido.Clear();
                    txtTelePadres.Clear();
                    cmbInstrumentos.SelectedIndex = -1;
                }
                else
                {
                    MessageBox.Show("Error al asociar el instrumento al alumno.");
                }
            }
            else
            {
                MessageBox.Show("Error al registrar el alumno.");
            }
        }


        private void btnVolver_Click(object sender, EventArgs e)
        {
            // Dirigir al formulario principal
            frmPrincipal principalForm = new frmPrincipal();
            principalForm.Show();
            this.Hide();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            // Cierra la pestaña y el sistema
            Application.Exit();
        }
    }
}
