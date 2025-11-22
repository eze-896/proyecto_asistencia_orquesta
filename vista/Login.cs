namespace GUI_Login
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            ConfigureEventHandlers();
        }

        private void ConfigureEventHandlers()
        {
            // Configurar eventos KeyPress para Enter
            txtUsuario.KeyPress += UsuarioTextBox_KeyPress;
            txtContraseña.KeyPress += ContraseñaTextBox_KeyPress;
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

                if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(pass))
                {
                    MessageBox.Show("Debe completar todos los campos", "Login",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUsuario.Focus();
                    return;
                }

                string respuestaControlador = ControlSesion.CtrlLogin(usuario, pass);

                if (respuestaControlador == "¡Bienvenido!")
                {
                    FrmPrincipal p = new();
                    this.Hide();
                    p.Show();
                }
                else
                {
                    MessageBox.Show(respuestaControlador, "Control de usuarios",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

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
            Registro reg = new();
            this.Hide();
            reg.Show();
        }

        private void CheckBxMostrarContraseña_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBxMostrarContraseña.Checked)
            {
                txtContraseña.PasswordChar = '\0';
            }
            else
            {
                txtContraseña.PasswordChar = '•';
            }
        }

        // Eventos para manejar Enter
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
                IniciarSesion(); // Inicia sesión automáticamente al presionar Enter
            }
        }
    }
}