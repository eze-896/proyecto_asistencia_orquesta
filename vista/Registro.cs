using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_Login
{
    public partial class Registro : Form
    {
        public Registro()
        {
            InitializeComponent();
            ConfigureEventHandlers();
        }

        private void ConfigureEventHandlers()
        {
            // Configurar eventos KeyPress para Enter
            txtNombreRegistro.KeyPress += TextBox_KeyPress;
            txtContraRegistro.KeyPress += TextBox_KeyPress;
            txtContraConfirm.KeyPress += ConfirmTextBox_KeyPress;

            // Configurar eventos para mostrar/ocultar contraseña
            checkMostrarContraseña.CheckedChanged += CheckMostrarContraseña_CheckedChanged;
        }

        private void Registro_Load(object sender, EventArgs e)
        {
            txtNombreRegistro.Focus();
        }

        private void BtnVolver_Click(object sender, EventArgs e)
        {
            Login login = new();
            this.Hide(); // Mejor usar Hide() en lugar de Visible = false
            login.Show();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            DialogResult rta = MessageBox.Show("¿Seguro que desea salir?", "Registro",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rta == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void BtnRegistro_Click(object sender, EventArgs e)
        {
            RegistrarUsuario();
        }

        private void RegistrarUsuario()
        {
            try
            {
                string usuario = txtNombreRegistro.Text.Trim();
                string pass = txtContraRegistro.Text.Trim();
                string confirmar = txtContraConfirm.Text.Trim();

                if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(pass) || string.IsNullOrEmpty(confirmar))
                {
                    MessageBox.Show("Debe completar todos los campos", "Registro",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNombreRegistro.Focus();
                    return;
                }

                if (pass != confirmar)
                {
                    MessageBox.Show("Las contraseñas no coinciden", "Registro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtContraRegistro.Clear();
                    txtContraConfirm.Clear();
                    txtContraRegistro.Focus();
                    return;
                }

                // Validar longitud mínima de contraseña
                if (pass.Length < 6)
                {
                    MessageBox.Show("La contraseña debe tener al menos 6 caracteres", "Registro",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtContraRegistro.Clear();
                    txtContraConfirm.Clear();
                    txtContraRegistro.Focus();
                    return;
                }

                // Crear objeto Usuario
                Usuario nuevoUser = new()
                {
                    Nombre = usuario
                };

                nuevoUser.Contrasena = ControlSesion.GenerarSHA1(pass);

                // Guardar en BD
                if (ModeloSesion.RegistrarUsuario(nuevoUser))
                {
                    MessageBox.Show("Usuario registrado con éxito", "Registro",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Login login = new();
                    this.Hide();
                    login.Show();
                }
                else
                {
                    MessageBox.Show("No se pudo registrar el usuario. El nombre de usuario puede estar en uso.",
                        "Registro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNombreRegistro.Focus();
                    txtNombreRegistro.SelectAll();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar usuario: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento para manejar Enter en TextBoxes
        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        // Evento especial para el último TextBox (registro automático)
        private void ConfirmTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                RegistrarUsuario(); // Registra automáticamente al presionar Enter en el último campo
            }
        }

        // Mostrar/ocultar contraseña
        private void CheckMostrarContraseña_CheckedChanged(object sender, EventArgs e)
        {
            if (checkMostrarContraseña.Checked)
            {
                txtContraRegistro.PasswordChar = '\0';
                txtContraConfirm.PasswordChar = '\0';
            }
            else
            {
                txtContraRegistro.PasswordChar = '•';
                txtContraConfirm.PasswordChar = '•';
            }
        }
    }
}