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
    public partial class registro : Form
    {
        public registro()
        {
            InitializeComponent();
        }

        private void registro_Load(object sender, EventArgs e)
        {
            txtNombreRegistro.Focus(); // Cuando abre el formulario, pone el foco en usuario
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            // Volver al login
            login login = new login();
            this.Visible = false;
            login.Show();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult rta = MessageBox.Show("¿Seguro que desea salir?", "Registro",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rta == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                txtNombreRegistro.Focus();
            }
        }

        private void btnRegistro_Click(object sender, EventArgs e)
        {
            try
            {
                string usuario = txtNombreRegistro.Text.Trim();
                string pass = txtContraRegistro.Text.Trim();
                string confirmar = txtContraConfirm.Text.Trim();

                if (usuario == "" || pass == "" || confirmar == "")
                {
                    MessageBox.Show("Debe completar todos los campos", "Registro",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                // Crear objeto Usuario
                Usuario nuevoUser = new Usuario();
                nuevoUser.Nombre = usuario;
                ControlSesion cs = new ControlSesion();
                nuevoUser.Contrasena = cs.generarSHA1(pass); // Guardar encriptado

                // Guardar en BD
                ModeloSesion modelo = new ModeloSesion();
                if (modelo.registrarUsuario(nuevoUser))
                {
                    MessageBox.Show("Usuario registrado con éxito", "Registro",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    login login = new login();
                    this.Visible = false;
                    login.Show();
                }
                else
                {
                    MessageBox.Show("No se pudo registrar el usuario", "Registro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

