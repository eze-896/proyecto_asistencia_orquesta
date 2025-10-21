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
                String pass = txtContrase�a.Text;
                ControlSesion control = new ();
                String respuestaControlador = control.ctrlLogin(usuario, pass);
                if (respuestaControlador == "�Bienvenido!")
                {
                    MessageBox.Show(control.ctrlLogin(usuario, pass), "Control de usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FrmPrincipal p = new ();
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

        private void BtnSalir_Click(object sender, EventArgs e)
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

        private void BtnRegistro_Click(object sender, EventArgs e)
        {
            // Ir al formulario de registro
            Registro reg = new ();
            this.Visible = false; // Oculta el formulario de inicio de sesi�n.
            reg.Show();
        }

        private void CheckBxMostrarContrase�a_CheckedChanged(object sender, EventArgs e)
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
