using GUI_Login.control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GUI_Login.vista
{
    public partial class FrmModificarAlumnos : Form
    {
        private readonly ControlAlumno controlAlumno;
        private readonly ControlInstrumento controlInstrumento;
        private int idSeleccionado = -1;
        private List<Alumno> listaAlumnos = [];

        public FrmModificarAlumnos()
        {
            InitializeComponent();
            controlAlumno = new ControlAlumno();
            controlInstrumento = new ControlInstrumento();
        }

        private void FrmModificarAlumnos_Load(object sender, EventArgs e)
        {
            CargarListaAlumnos();
            CargarCheckListInstrumentos();
        }

        private void CargarListaAlumnos()
        {
            listaAlumnos = controlAlumno.ObtenerAlumnos();
            lstAlumnosModificar.DataSource = null;
            lstAlumnosModificar.DataSource = listaAlumnos;
            lstAlumnosModificar.DisplayMember = "Nombre";
            lstAlumnosModificar.ValueMember = "Id";

            // Seleccionar automáticamente el primer alumno si existe
            if (lstAlumnosModificar.Items.Count > 0)
            {
                lstAlumnosModificar.SelectedIndex = 0;
            }
        }

        private void CargarCheckListInstrumentos()
        {
            List<Instrumento> instrumentos = controlInstrumento.ListarInstrumentosEnOrquesta();
            chkListInstrumentos.DataSource = null;
            chkListInstrumentos.DataSource = instrumentos;
            chkListInstrumentos.DisplayMember = "Nombre";
            chkListInstrumentos.ValueMember = "Id";
        }

        private void LstAlumnosModificar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstAlumnosModificar.SelectedItem == null) return;

            Alumno alumno = (Alumno)lstAlumnosModificar.SelectedItem;
            idSeleccionado = alumno.Id;

            txtNombre.Text = alumno.Nombre;
            txtApellido.Text = alumno.Apellido;
            txtDni.Text = alumno.Dni.ToString();
            txtTelePadres.Text = alumno.Telefono_padres;

            // Cargar los instrumentos actuales del alumno
            CargarInstrumentosDelAlumno(idSeleccionado);
        }

        private void CargarInstrumentosDelAlumno(int idAlumno)
        {
            // Desmarcar todos los instrumentos primero
            for (int i = 0; i < chkListInstrumentos.Items.Count; i++)
            {
                chkListInstrumentos.SetItemChecked(i, false);
            }

            // Obtener los instrumentos actuales del alumno
            List<int> instrumentosAlumno = controlAlumno.ObtenerInstrumentosPorAlumno(idAlumno);

            // Marcar los instrumentos que el alumno ya tiene
            for (int i = 0; i < chkListInstrumentos.Items.Count; i++)
            {
                Instrumento instrumento = (Instrumento)chkListInstrumentos.Items[i];
                if (instrumentosAlumno.Contains(instrumento.Id))
                {
                    chkListInstrumentos.SetItemChecked(i, true);
                }
            }
        }

        private void BtnGuardarCambios_Click(object sender, EventArgs e)
        {
            if (idSeleccionado <= 0)
            {
                MessageBox.Show("Por favor, seleccione un alumno para modificar.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar campos obligatorios
            if (ControlAlumno.ValidarCamposObligatorios(
                txtNombre.Text, txtApellido.Text, txtDni.Text, txtTelePadres.Text))
            {
                // Validar que al menos un instrumento esté seleccionado
                if (chkListInstrumentos.CheckedItems.Count == 0)
                {
                    MessageBox.Show("Seleccione al menos un instrumento.",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Confirmar modificación
                if (MessageBox.Show("¿Está seguro que desea modificar los datos del alumno?",
                    "Confirmar Modificación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;

                // Crear objeto alumno
                Alumno alumno = new()
                {
                    Id = idSeleccionado,
                    Nombre = txtNombre.Text.Trim(),
                    Apellido = txtApellido.Text.Trim(),
                    Dni = int.Parse(txtDni.Text.Trim()),
                    Telefono_padres = txtTelePadres.Text.Trim()
                };

                // Obtener los IDs de los instrumentos seleccionados
                List<int> idsInstrumentos = [];
                foreach (var item in chkListInstrumentos.CheckedItems)
                {
                    Instrumento instrumento = (Instrumento)item;
                    idsInstrumentos.Add(instrumento.Id);
                }

                // Modificar alumno con sus instrumentos
                bool exito = controlAlumno.ModificarAlumnoConInstrumentos(alumno, idsInstrumentos);

                if (exito)
                {
                    CargarListaAlumnos();
                    LimpiarFormulario();
                }
            }
        }

        private void LimpiarFormulario()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtDni.Clear();
            txtTelePadres.Clear();
            for (int i = 0; i < chkListInstrumentos.Items.Count; i++)
            {
                chkListInstrumentos.SetItemChecked(i, false);
            }
            idSeleccionado = -1;
        }

        private void BtnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmPrincipal formPrincipal = new();
            formPrincipal.Show();
        }
        private void BtnSalir_Click(object sender, EventArgs e) => Application.Exit();
        private void FrmModificarAlumnos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) BtnVolver_Click(sender, e);
        }
    }
}