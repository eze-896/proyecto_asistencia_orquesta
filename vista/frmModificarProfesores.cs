using GUI_Login.control;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GUI_Login.vista
{
    /// <summary>
    /// Formulario para modificar datos de profesores existentes
    /// Permite buscar, cargar y actualizar información de profesores
    /// </summary>
    public partial class FrmModificarProfesores : Form
    {
        private readonly ControlProfesor controlProfesor;
        private readonly ControlInstrumento controlInstrumento;
        private int idSeleccionado = -1;

        /// <summary>
        /// Constructor que inicializa los controladores
        /// </summary>
        public FrmModificarProfesores()
        {
            InitializeComponent();
            controlProfesor = new ControlProfesor();
            controlInstrumento = new ControlInstrumento();
        }

        /// <summary>
        /// Carga inicial del formulario
        /// </summary>
        private void FrmModificarProfesores_Load(object sender, EventArgs e)
        {
            CargarProfesores();
            CargarInstrumentos();
            this.KeyPreview = true;
        }

        /// <summary>
        /// Carga la lista de profesores en el ListBox
        /// </summary>
        private void CargarProfesores()
        {
            lstProfesoresModificar.Items.Clear();
            var profesores = controlProfesor.ObtenerProfesores();

            foreach (var prof in profesores)
            {
                lstProfesoresModificar.Items.Add($"{prof.Id} - {prof.Nombre} {prof.Apellido}");
            }
        }

        /// <summary>
        /// Carga los instrumentos disponibles en el ComboBox
        /// </summary>
        private void CargarInstrumentos()
        {
            cmbInstrumentos.DisplayMember = "Nombre";
            cmbInstrumentos.ValueMember = "Id";
            cmbInstrumentos.DataSource = controlInstrumento.ListarInstrumentosEnOrquesta();
            cmbInstrumentos.SelectedIndex = -1;
        }

        /// <summary>
        /// Maneja la selección de un profesor en la lista
        /// </summary>
        private void LstProfesoresModificar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstProfesoresModificar.SelectedItem == null) return;

            string? seleccionado = lstProfesoresModificar.SelectedItem.ToString();
            if (!string.IsNullOrEmpty(seleccionado))
            {
                // Extraer ID del profesor seleccionado
                string idPart = seleccionado.Split('-')[0].Trim();
                if (int.TryParse(idPart, out int id))
                {
                    idSeleccionado = id;
                    Profesor? prof = controlProfesor.BuscarProfesor(idSeleccionado);
                    if (prof != null)
                    {
                        // Cargar datos del profesor en los controles
                        txtNombre.Text = prof.Nombre;
                        txtApellido.Text = prof.Apellido;
                        txtDni.Text = prof.Dni.ToString();
                        txtTelefono.Text = prof.Telefono;
                        txtEmail.Text = prof.Email;
                        cmbInstrumentos.SelectedValue = prof.Id_instrumento;
                    }
                }
                else
                {
                    MessageBox.Show("Error al obtener el ID del profesor seleccionado.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Guarda los cambios realizados en los datos del profesor
        /// </summary>
        private void BtnGuardarCambios_Click(object sender, EventArgs e)
        {
            // Validar selección de profesor
            if (idSeleccionado == -1)
            {
                MessageBox.Show("Seleccione un profesor para modificar.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Crear objeto profesor con los datos actualizados
            if (cmbInstrumentos.SelectedValue is int selectedValue)
            {
                Profesor profesor = new Profesor
                {
                    Id = idSeleccionado,
                    Dni = int.Parse(txtDni.Text),
                    Nombre = txtNombre.Text.Trim(),
                    Apellido = txtApellido.Text.Trim(),
                    Telefono = txtTelefono.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Id_instrumento = selectedValue
                };

                // Ejecutar modificación
                bool exito = controlProfesor.ModificarProfesor(profesor);
                if (exito)
                {
                    CargarProfesores(); // Recargar lista actualizada

                    // Limpiar formulario
                    txtNombre.Clear();
                    txtApellido.Clear();
                    txtDni.Clear();
                    txtTelefono.Clear();
                    txtEmail.Clear();
                    cmbInstrumentos.SelectedIndex = -1;
                    idSeleccionado = -1;
                }
            }
            else
            {
                MessageBox.Show("Seleccione un instrumento válido.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Regresa al formulario principal
        /// </summary>
        private void BtnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmPrincipal formPrincipal = new();
            formPrincipal.Show();
        }

        /// <summary>
        /// Sale del sistema con confirmación
        /// </summary>
        private void BtnSalir_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "¿Está seguro que desea salir del sistema?",
                "Confirmar Salida",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        /// <summary>
        /// Maneja atajos de teclado en el formulario
        /// </summary>
        private void FrmModificarProfesores_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                BtnVolver_Click(sender, e);
            else if (e.KeyCode == Keys.F4 && e.Alt)
                BtnSalir_Click(sender, e);
        }
    }
}