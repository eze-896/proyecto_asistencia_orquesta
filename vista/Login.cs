namespace GUI_Login
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void BtnIniciarsesion_Click(object sender, EventArgs e)
        {
            try
            {
                String usuario = txtUsuario.Text;
                String pass = txtContraseña.Text;
                String respuestaControlador = ControlSesion.CtrlLogin(usuario, pass);
                ControlSesion control = new ();
                if (respuestaControlador == "¡Bienvenido!")
                {
                    FrmPrincipal p = new ();
                    this.Visible = false; //Oculta el formulario de inicio de sesión.
                    p.Show();
                }
                else
                {
                    MessageBox.Show(respuestaControlador, "Control de usuarios",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (txtUsuario.Text == "")
                        txtUsuario.Focus();
                    else
                        txtContraseña.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            // Boton salir
            DialogResult rta = MessageBox.Show("¿Seguro que desea salir?", "Control de usuarios",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rta == DialogResult.Yes)
            {
                Application.Exit(); // Cierra la aplicación
            }
            else
            {
                txtUsuario.Focus(); // Regresa el foco al campo de usuario
            }
        }

        private void BtnRegistro_Click(object sender, EventArgs e)
        {
            // Ir al formulario de registro
            Registro reg = new ();
            this.Visible = false; // Oculta el formulario de inicio de sesión.
            reg.Show();
        }

        private void CheckBxMostrarContraseña_CheckedChanged(object sender, EventArgs e)
        {
            // Mostrar u ocultar contraseña

        if (checkBxMostrarContraseña.Checked)
            {
                txtContraseña.PasswordChar = '\0'; // Mostrar contraseña
            }
            else
            {
                txtContraseña.PasswordChar = '•'; // Ocultar contraseña
            }
        }
    }
}
