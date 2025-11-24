using GUI_Login.control;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace GUI_Login
{
    public partial class Registro : Form
    {
        private readonly ControlSesion _controlSesion;

        /// <summary>
        /// Constructor que inicializa el controlador de sesión y configura eventos
        /// </summary>
        public Registro()
        {
            InitializeComponent();
            _controlSesion = new ControlSesion();
            ConfigureEventHandlers();
        }

        /// <summary>
        /// Configura los manejadores de eventos para los controles
        /// </summary>
        private void ConfigureEventHandlers()
        {
            txtNombreRegistro.KeyPress += TextBox_KeyPress;
            txtContraRegistro.KeyPress += TextBox_KeyPress;
            txtContraConfirm.KeyPress += ConfirmTextBox_KeyPress;

            checkMostrarContraseña.CheckedChanged += CheckMostrarContraseña_CheckedChanged;
            txtContraRegistro.TextChanged += ContraRegistro_TextChanged;
            txtContraConfirm.TextChanged += ContraConfirm_TextChanged;
        }

        /// <summary>
        /// Carga inicial del formulario
        /// </summary>
        private void Registro_Load(object sender, EventArgs e)
        {
            txtNombreRegistro.Focus();
        }

        /// <summary>
        /// Maneja el clic en el botón de registro
        /// </summary>
        private void BtnRegistro_Click(object sender, EventArgs e)
        {
            RegistrarUsuario();
        }

        /// <summary>
        /// Procesa el registro de un nuevo usuario
        /// </summary>
        private void RegistrarUsuario()
        {
            try
            {
                string usuario = txtNombreRegistro.Text.Trim();
                string pass = txtContraRegistro.Text.Trim();
                string confirmar = txtContraConfirm.Text.Trim();

                // Validar campos del formulario
                if (string.IsNullOrEmpty(usuario))
                {
                    MessageBox.Show("Debe ingresar un nombre de usuario", "Registro",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNombreRegistro.Focus();
                    return;
                }

                if (usuario.Length < 3)
                {
                    MessageBox.Show("El nombre de usuario debe tener al menos 3 caracteres", "Registro",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNombreRegistro.Focus();
                    txtNombreRegistro.SelectAll();
                    return;
                }

                if (usuario.Length > 20)
                {
                    MessageBox.Show("El nombre de usuario no puede tener más de 20 caracteres", "Registro",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNombreRegistro.Focus();
                    txtNombreRegistro.SelectAll();
                    return;
                }

                if (string.IsNullOrEmpty(pass) || string.IsNullOrEmpty(confirmar))
                {
                    MessageBox.Show("Debe completar ambos campos de contraseña", "Registro",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtContraRegistro.Focus();
                    return;
                }

                if (pass != confirmar)
                {
                    MessageBox.Show("Las contraseñas no coinciden", "Registro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LimpiarCamposContraseña();
                    return;
                }

                // Validar fortaleza de la contraseña
                var resultadoFortaleza = _controlSesion.ValidarFortalezaContrasena(pass);
                if (!resultadoFortaleza.EsValida)
                {
                    MessageBox.Show($"Contraseña no válida:\n{resultadoFortaleza.Mensaje}", "Registro",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    LimpiarCamposContraseña();
                    return;
                }

                // Ejecutar registro en la base de datos
                try
                {
                    bool exito = _controlSesion.RegistrarUsuario(usuario, pass);

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
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar usuario: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Actualiza el indicador de fortaleza de la contraseña
        /// </summary>
        private void ContraRegistro_TextChanged(object sender, EventArgs e)
        {
            string password = txtContraRegistro.Text;

            // Actualizar indicador de fortaleza
            if (string.IsNullOrEmpty(password))
            {
                lblFortaleza.Text = "Fortaleza: -";
                lblFortaleza.ForeColor = Color.Gray;
            }
            else
            {
                string nivel = _controlSesion.EvaluarNivelFortaleza(password);
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

            // Actualizar confirmación de contraseña
            ValidarConfirmacionContraseña();
        }

        /// <summary>
        /// Valida la confirmación de la contraseña
        /// </summary>
        private void ContraConfirm_TextChanged(object sender, EventArgs e)
        {
            ValidarConfirmacionContraseña();
        }

        /// <summary>
        /// Valida y muestra el estado de la confirmación de contraseña
        /// </summary>
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

        /// <summary>
        /// Limpia los campos de contraseña y restablece los indicadores
        /// </summary>
        private void LimpiarCamposContraseña()
        {
            txtContraRegistro.Clear();
            txtContraConfirm.Clear();
            txtContraRegistro.Focus();
            lblFortaleza.Text = "Fortaleza: -";
            lblFortaleza.ForeColor = Color.Gray;
            lblConfirmacion.Text = "Confirmación: -";
            lblConfirmacion.ForeColor = Color.Gray;
        }

        /// <summary>
        /// Vuelve al formulario de login
        /// </summary>
        private void VolverALogin()
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }

        /// <summary>
        /// Maneja el cambio en la opción de mostrar contraseña
        /// </summary>
        private void CheckMostrarContraseña_CheckedChanged(object sender, EventArgs e)
        {
            char passwordChar = checkMostrarContraseña.Checked ? '\0' : '•';
            txtContraRegistro.PasswordChar = passwordChar;
            txtContraConfirm.PasswordChar = passwordChar;
        }

        /// <summary>
        /// Maneja la tecla Enter en los campos de texto
        /// </summary>
        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        /// <summary>
        /// Maneja la tecla Enter en el campo de confirmación de contraseña
        /// </summary>
        private void ConfirmTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                RegistrarUsuario();
            }
        }

        /// <summary>
        /// Maneja el clic en el botón Volver
        /// </summary>
        private void BtnVolver_Click(object sender, EventArgs e)
        {
            VolverALogin();
        }

        /// <summary>
        /// Maneja el clic en el botón Salir
        /// </summary>
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