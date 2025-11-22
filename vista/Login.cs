using GUI_Login.control;
using System;
using System.Windows.Forms;

namespace GUI_Login
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            ConfigureEventHandlers();
            ConfigureInitialFocus();
        }

        private void ConfigureEventHandlers()
        {
            txtUsuario.KeyPress += UsuarioTextBox_KeyPress;
            txtContraseña.KeyPress += ContraseñaTextBox_KeyPress;
            checkBxMostrarContraseña.CheckedChanged += CheckBxMostrarContraseña_CheckedChanged;
        }

        private void ConfigureInitialFocus()
        {
            txtUsuario.Focus();
        }

        private void BtnIniciarsesion_Click(object sender, EventArgs e)
        {
            IniciarSesion();
        }

        private void IniciarSesion()
        {
            try
            {
                string usuario = txtUsuario.Text.Trim();
                string pass = txtContraseña.Text.Trim();

                if (!ValidarCamposLogin(usuario, pass))
                    return;

                string respuestaControlador = ControlSesion.CtrlLogin(usuario, pass);
                ProcesarRespuestaAutenticacion(respuestaControlador);
            }
            catch (Exception ex)
            {
                // CORREGIDO: Ahora captura excepciones del Controlador
                MessageBox.Show($"Error al iniciar sesión: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarCamposLogin(string usuario, string pass)
        {
            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Debe completar todos los campos", "Login",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsuario.Focus();
                return false;
            }
            return true;
        }

        // CORREGIDO: Manejo simplificado de foco
        private void ProcesarRespuestaAutenticacion(string respuesta)
        {
            if (respuesta == "¡Bienvenido!")
            {
                FrmPrincipal principal = new FrmPrincipal();
                this.Hide(); // Solo ocultar
                principal.Show();
            }
            else
            {
                MessageBox.Show(respuesta, "Control de usuarios",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (string.IsNullOrEmpty(txtUsuario.Text))
                    txtUsuario.Focus();
                else
                    txtContraseña.Focus();
            }
        }

        private void CheckBxMostrarContraseña_CheckedChanged(object sender, EventArgs e)
        {
            txtContraseña.PasswordChar = checkBxMostrarContraseña.Checked ? '\0' : '•';
        }

        private void UsuarioTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                txtContraseña.Focus();
            }
        }

        private void ContraseñaTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                IniciarSesion();
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            DialogResult rta = MessageBox.Show("¿Seguro que desea salir?", "Control de usuarios",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rta == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void BtnRegistro_Click(object sender, EventArgs e)
        {
            this.Hide(); // Solo ocultar
            Registro registro = new Registro();
            registro.Show();
        }
    }
}