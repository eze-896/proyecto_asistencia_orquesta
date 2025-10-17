namespace GUI_Login
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void btnIniciarsesion_Click(object sender, EventArgs e)
        {
            try
            {
                String usuario = txtUsuario.Text;
                String pass = txtContraseña.Text;
                ControlSesion control = new ControlSesion();
                String respuestaControlador = control.ctrlLogin(usuario, pass);
                if (respuestaControlador == "¡Bienvenido!")
                {
                    MessageBox.Show(control.ctrlLogin(usuario, pass), "Control de usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmPrincipal p = new frmPrincipal();
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

        private void btnSalir_Click(object sender, EventArgs e)
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

        private void btnRegistro_Click(object sender, EventArgs e)
        {
            // Ir al formulario de registro
            registro reg = new registro();
            this.Visible = false; // Oculta el formulario de inicio de sesión.
            reg.Show();
        }

        private void checkBxMostrarContraseña_CheckedChanged(object sender, EventArgs e)
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
