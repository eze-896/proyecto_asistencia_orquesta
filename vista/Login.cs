using GUI_Login.control;
using System;
using System.Windows.Forms;

namespace GUI_Login
{
    public partial class Login : Form
    {
        private readonly ControlSesion controlsesion;
        /// <summary>
        /// Constructor que inicializa el formulario y configura eventos
        /// </summary>
        public Login()
        {
            controlsesion = new ControlSesion();
            InitializeComponent();
            ConfigureEventHandlers();
            txtUsuario.Focus();
        }

        /// <summary>
        /// Configura los manejadores de eventos para los controles
        /// </summary>
        private void ConfigureEventHandlers()
        {
            txtUsuario.KeyPress += UsuarioTextBox_KeyPress;
            txtContraseña.KeyPress += ContraseñaTextBox_KeyPress;
            checkBxMostrarContraseña.CheckedChanged += CheckBxMostrarContraseña_CheckedChanged;
        }

        /// <summary>
        /// Maneja el clic en el botón de iniciar sesión
        /// </summary>
        private void BtnIniciarsesion_Click(object sender, EventArgs e)
        {
            IniciarSesion();
        }

        /// <summary>
        /// Procesa el inicio de sesión del usuario
        /// </summary>
        private void IniciarSesion()
        {
            try
            {
                string usuario = txtUsuario.Text.Trim();
                string pass = txtContraseña.Text.Trim();

                // Validar campos completos
                if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(pass))
                {
                    MessageBox.Show("Debe completar todos los campos", "Login",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUsuario.Focus();
                    return;
                }

                // Autenticar usuario
                string respuestaControlador = controlsesion.CtrlLogin(usuario, pass);

                // Procesar respuesta de autenticación
                if (respuestaControlador == "¡Bienvenido!")
                {
                    FrmPrincipal principal = new FrmPrincipal();
                    this.Hide();
                    principal.Show();
                }
                else
                {
                    MessageBox.Show(respuestaControlador, "Control de usuarios",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                    // Establecer foco en el campo apropiado
                    if (string.IsNullOrEmpty(txtUsuario.Text))
                        txtUsuario.Focus();
                    else
                        txtContraseña.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al iniciar sesión: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Maneja el cambio en la opción de mostrar contraseña
        /// </summary>
        private void CheckBxMostrarContraseña_CheckedChanged(object sender, EventArgs e)
        {
            txtContraseña.PasswordChar = checkBxMostrarContraseña.Checked ? '\0' : '•';
        }

        /// <summary>
        /// Maneja la tecla Enter en el campo de usuario
        /// </summary>
        private void UsuarioTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                txtContraseña.Focus();
            }
        }

        /// <summary>
        /// Maneja la tecla Enter en el campo de contraseña
        /// </summary>
        private void ContraseñaTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                IniciarSesion();
            }
        }

        /// <summary>
        /// Maneja el clic en el botón Salir
        /// </summary>
        private void BtnSalir_Click(object sender, EventArgs e)
        {
            DialogResult rta = MessageBox.Show("¿Seguro que desea salir?", "Control de usuarios",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rta == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        /// <summary>
        /// Maneja el clic en el botón Registro
        /// </summary>
        private void BtnRegistro_Click(object sender, EventArgs e)
        {
            this.Hide();
            Registro registro = new Registro();
            registro.Show();
        }
    }
}