using GUI_Login.control;
using GUI_Login.modelo;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace GUI_Login
{
    public partial class Registro : Form
    {
        private readonly ModeloSesion modeloSesion;

        public Registro()
        {
            InitializeComponent();
            modeloSesion = new ModeloSesion();
            ConfigureEventHandlers();
        }

        private void ConfigureEventHandlers()
        {
            txtNombreRegistro.KeyPress += TextBox_KeyPress;
            txtContraRegistro.KeyPress += TextBox_KeyPress;
            txtContraConfirm.KeyPress += ConfirmTextBox_KeyPress;

            checkMostrarContraseña.CheckedChanged += CheckMostrarContraseña_CheckedChanged;
            txtContraRegistro.TextChanged += ContraRegistro_TextChanged;
            txtContraConfirm.TextChanged += ContraConfirm_TextChanged;
        }

        private void Registro_Load(object sender, EventArgs e)
        {
            txtNombreRegistro.Focus();
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

                if (!ValidarFormularioRegistro(usuario, pass, confirmar))
                    return;

                Usuario nuevoUser = CrearUsuario(usuario, pass);
                EjecutarRegistro(nuevoUser);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar usuario: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarFormularioRegistro(string usuario, string pass, string confirmar)
        {
            if (string.IsNullOrEmpty(usuario))
            {
                MessageBox.Show("Debe ingresar un nombre de usuario", "Registro",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreRegistro.Focus();
                return false;
            }

            if (usuario.Length < 3)
            {
                MessageBox.Show("El nombre de usuario debe tener al menos 3 caracteres", "Registro",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreRegistro.Focus();
                txtNombreRegistro.SelectAll();
                return false;
            }

            if (usuario.Length > 20)
            {
                MessageBox.Show("El nombre de usuario no puede tener más de 20 caracteres", "Registro",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreRegistro.Focus();
                txtNombreRegistro.SelectAll();
                return false;
            }

            if (string.IsNullOrEmpty(pass) || string.IsNullOrEmpty(confirmar))
            {
                MessageBox.Show("Debe completar ambos campos de contraseña", "Registro",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtContraRegistro.Focus();
                return false;
            }

            if (pass != confirmar)
            {
                MessageBox.Show("Las contraseñas no coinciden", "Registro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                LimpiarCamposContraseña();
                return false;
            }

            var resultadoFortaleza = ControlSesion.ValidarFortalezaContrasena(pass);
            if (!resultadoFortaleza.EsValida)
            {
                MessageBox.Show($"Contraseña no válida:\n{resultadoFortaleza.Mensaje}", "Registro",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LimpiarCamposContraseña();
                return false;
            }

            return true;
        }

        private Usuario CrearUsuario(string usuario, string pass)
        {
            try
            {
                string hashContrasena = ControlSesion.GenerarSHA1(pass);

                return new Usuario
                {
                    Nombre = usuario,
                    Contrasena = hashContrasena
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al crear usuario: {ex.Message}");
            }
        }

        private void EjecutarRegistro(Usuario usuario)
        {
            try
            {
                bool exito = modeloSesion.RegistrarUsuario(usuario);

                if (exito)
                {
                    MessageBox.Show("Usuario registrado con éxito", "Registro",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    VolverALogin();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar usuario: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNombreRegistro.Focus();
                txtNombreRegistro.SelectAll();
            }
        }

        private void ActualizarIndicadorFortaleza(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                lblFortaleza.Text = "Fortaleza: -";
                lblFortaleza.ForeColor = Color.Gray;
                return;
            }

            string nivel = ControlSesion.EvaluarNivelFortaleza(password);
            lblFortaleza.Text = $"Fortaleza: {nivel}";

            lblFortaleza.ForeColor = nivel switch
            {
                "Débil" => Color.Red,
                "Media" => Color.Orange,
                "Fuerte" => Color.Green,
                "Muy Fuerte" => Color.DarkGreen,
                _ => Color.Gray
            };
        }

        private void ValidarConfirmacionContraseña()
        {
            string pass = txtContraRegistro.Text;
            string confirm = txtContraConfirm.Text;

            if (string.IsNullOrEmpty(confirm))
            {
                lblConfirmacion.Text = "Confirmación: -";
                lblConfirmacion.ForeColor = Color.Gray;
                return;
            }

            if (pass == confirm)
            {
                lblConfirmacion.Text = "Confirmación: ✓ Coinciden";
                lblConfirmacion.ForeColor = Color.Green;
            }
            else
            {
                lblConfirmacion.Text = "Confirmación: ✗ No coinciden";
                lblConfirmacion.ForeColor = Color.Red;
            }
        }

        private void ContraRegistro_TextChanged(object sender, EventArgs e)
        {
            string password = txtContraRegistro.Text;
            ActualizarIndicadorFortaleza(password);
            ValidarConfirmacionContraseña();
        }

        private void ContraConfirm_TextChanged(object sender, EventArgs e)
        {
            ValidarConfirmacionContraseña();
        }

        private void LimpiarCamposContraseña()
        {
            txtContraRegistro.Clear();
            txtContraConfirm.Clear();
            txtContraRegistro.Focus();
            ActualizarIndicadorFortaleza("");
            lblConfirmacion.Text = "Confirmación: -";
            lblConfirmacion.ForeColor = Color.Gray;
        }

        private void VolverALogin()
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }

        private void CheckMostrarContraseña_CheckedChanged(object sender, EventArgs e)
        {
            char passwordChar = checkMostrarContraseña.Checked ? '\0' : '•';
            txtContraRegistro.PasswordChar = passwordChar;
            txtContraConfirm.PasswordChar = passwordChar;
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void ConfirmTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                RegistrarUsuario();
            }
        }

        private void BtnVolver_Click(object sender, EventArgs e)
        {
            VolverALogin();
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
    }
}