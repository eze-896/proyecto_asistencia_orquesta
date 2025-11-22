using GUI_Login.control;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GUI_Login.vista
{
    /// <summary>
    /// Formulario para modificar datos de profesores existentes
    /// Permite actualizar información personal y de instrumento de los profesores
    /// </summary>
    public partial class FrmModificarProfesores : Form
    {
        private readonly ControlProfesor controlProfesor;
        private readonly ControlInstrumento controlInstrumento;
        private int idSeleccionado = -1;

        /// <summary>
        /// Constructor que inicializa los controladores necesarios
        /// </summary>
        public FrmModificarProfesores()
        {
            InitializeComponent();
            controlProfesor = new ControlProfesor();
            controlInstrumento = new ControlInstrumento();
        }

        // ==================== MÉTODOS DE CARGA Y CONFIGURACIÓN ====================

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

        // ==================== MANEJO DE SELECCIONES ====================

        private void LstProfesoresModificar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstProfesoresModificar.SelectedItem == null) return;

            string? seleccionado = lstProfesoresModificar.SelectedItem.ToString();
            if (!string.IsNullOrEmpty(seleccionado))
            {
                idSeleccionado = Convert.ToInt32(seleccionado.Split('-')[0].Trim());

                Profesor? prof = controlProfesor.BuscarProfesor(idSeleccionado);
                if (prof != null)
                {
                    CargarDatosProfesor(prof);
                }
            }
        }

        /// <summary>
        /// Carga los datos del profesor seleccionado en los controles del formulario
        /// </summary>
        /// <param name="profesor">Profesor cuyos datos se cargarán</param>
        private void CargarDatosProfesor(Profesor profesor)
        {
            txtNombre.Text = profesor.Nombre;
            txtApellido.Text = profesor.Apellido;
            txtDni.Text = profesor.Dni.ToString();
            txtTelefono.Text = profesor.Telefono;
            txtEmail.Text = profesor.Email;
            cmbInstrumentos.SelectedValue = profesor.Id_instrumento;
        }

        // ==================== OPERACIONES PRINCIPALES ====================

        private void BtnGuardarCambios_Click(object sender, EventArgs e)
        {
            if (!ValidarSeleccionProfesor())
                return;

            if (!ValidarCamposFormulario())
                return;

            if (!ControlProfesor.ConfirmarModificacion())
                return;

            if (cmbInstrumentos.SelectedValue is int selectedValue)
            {
                Profesor profesor = CrearObjetoProfesor(selectedValue);
                bool exito = controlProfesor.ModificarProfesor(profesor);

                if (exito)
                {
                    CargarProfesores();
                    LimpiarFormulario();
                }
            }
            else
            {
                MessageBox.Show("Seleccione un instrumento válido.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Valida que se haya seleccionado un profesor para modificar
        /// </summary>
        /// <returns>True si la selección es válida</returns>
        private bool ValidarSeleccionProfesor()
        {
            if (idSeleccionado == -1)
            {
                MessageBox.Show("Seleccione un profesor para modificar.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Valida que todos los campos del formulario sean correctos
        /// </summary>
        /// <returns>True si todos los campos son válidos</returns>
        private bool ValidarCamposFormulario()
        {
            return ControlProfesor.ValidarProfesor(
                nombre: txtNombre.Text,
                apellido: txtApellido.Text,
                dni: txtDni.Text,
                telefono: txtTelefono.Text,
                email: txtEmail.Text,
                idInstrumento: cmbInstrumentos.SelectedValue as int?);
        }

        /// <summary>
        /// Crea un objeto Profesor con los datos del formulario
        /// </summary>
        /// <param name="idInstrumento">ID del instrumento seleccionado</param>
        /// <returns>Objeto Profesor con los datos actualizados</returns>
        private Profesor CrearObjetoProfesor(int idInstrumento)
        {
            return new Profesor
            {
                Id = idSeleccionado,
                Dni = int.Parse(txtDni.Text),
                Nombre = txtNombre.Text.Trim(),
                Apellido = txtApellido.Text.Trim(),
                Telefono = txtTelefono.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Id_instrumento = idInstrumento
            };
        }

        // ==================== MÉTODOS AUXILIARES ====================

        /// <summary>
        /// Limpia todos los campos del formulario
        /// </summary>
        private void LimpiarFormulario()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtDni.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
            cmbInstrumentos.SelectedIndex = -1;
            idSeleccionado = -1;
        }

        // ==================== NAVEGACIÓN Y CIERRE ====================

        private void BtnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmPrincipal formPrincipal = new();
            formPrincipal.Show();
        }

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

        private void FrmModificarProfesores_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                BtnVolver_Click(sender, e);
            else if (e.KeyCode == Keys.F4 && e.Alt)
                BtnSalir_Click(sender, e);
        }
    }
}