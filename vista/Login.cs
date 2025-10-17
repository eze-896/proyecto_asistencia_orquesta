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
                String pass = txtContrase�a.Text;
                ControlSesion control = new ControlSesion();
                String respuestaControlador = control.ctrlLogin(usuario, pass);
                if (respuestaControlador == "�Bienvenido!")
                {
                    MessageBox.Show(control.ctrlLogin(usuario, pass), "Control de usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmPrincipal p = new frmPrincipal();
                    this.Visible = false; //Oculta el formulario de inicio de sesi�n.
                    p.Show();
                }
                else
                {
                    MessageBox.Show(respuestaControlador, "Control de usuarios",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (txtUsuario.Text == "")
                        txtUsuario.Focus();
                    else
                        txtContrase�a.Focus();
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
            DialogResult rta = MessageBox.Show("�Seguro que desea salir?", "Control de usuarios",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rta == DialogResult.Yes)
            {
                Application.Exit(); // Cierra la aplicaci�n
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
            this.Visible = false; // Oculta el formulario de inicio de sesi�n.
            reg.Show();
        }

        private void checkBxMostrarContrase�a_CheckedChanged(object sender, EventArgs e)
        {
            // Mostrar u ocultar contrase�a

        if (checkBxMostrarContrase�a.Checked)
            {
                txtContrase�a.PasswordChar = '\0'; // Mostrar contrase�a
            }
            else
            {
                txtContrase�a.PasswordChar = '�'; // Ocultar contrase�a
            }
        }
    }
}
