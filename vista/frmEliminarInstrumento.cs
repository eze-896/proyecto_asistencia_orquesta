using GUI_Login.control;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GUI_Login.vista
{
    public partial class FrmEliminarInstrumento : Form
    {
        private readonly ControlInstrumento controlInstrumento;
        private List<Instrumento> listaInstrumentos;

        public FrmEliminarInstrumento()
        {
            InitializeComponent();
            controlInstrumento = new ControlInstrumento();
            listaInstrumentos = new List<Instrumento>();
        }

        private void FrmEliminarInstrumento_Load(object sender, EventArgs e)
        {
            CargarInstrumentos();
            this.KeyPreview = true;

            // Configuración de navegación por tabulación
            lstInstrumentos.TabStop = true;
            btnEliminar.TabStop = true;
            btnVolver.TabStop = true;
            btnSalir.TabStop = false;
        }

        private void CargarInstrumentos()
        {
            try
            {
                lstInstrumentos.Items.Clear();
                listaInstrumentos = controlInstrumento.ListarInstrumentosEnOrquesta();

                foreach (var instrumento in listaInstrumentos)
                {
                    lstInstrumentos.Items.Add($"{instrumento.Nombre} - {instrumento.Catedra}");
                }

                if (lstInstrumentos.Items.Count > 0)
                {
                    lstInstrumentos.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("No hay instrumentos en la orquesta para eliminar.",
                        "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                // CORREGIDO: Ahora captura excepciones del Controlador
                MessageBox.Show($"Error al cargar los instrumentos: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (!ValidarSeleccionInstrumento())
                return;

            Instrumento seleccionado = ObtenerInstrumentoSeleccionado();

            if (!ValidarUsoInstrumento(seleccionado))
                return;

            if (!ConfirmarEliminacion(seleccionado))
                return;

            EjecutarEliminacion(seleccionado);
        }

        private bool ValidarSeleccionInstrumento()
        {
            if (lstInstrumentos.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un instrumento para eliminar de la orquesta.", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lstInstrumentos.Focus();
                return false;
            }
            return true;
        }

        private Instrumento ObtenerInstrumentoSeleccionado()
        {
            return listaInstrumentos[lstInstrumentos.SelectedIndex];
        }

        private bool ValidarUsoInstrumento(Instrumento instrumento)
        {
            // Verifica si el instrumento está siendo usado por algún profesor
            if (controlInstrumento.EstaInstrumentoEnUso(instrumento.Id))
            {
                MessageBox.Show($"No se puede eliminar el instrumento '{instrumento.Nombre}' porque está asignado a uno o más profesores.",
                    "No se puede eliminar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Verifica si el instrumento está siendo usado por algún alumno
            if (controlInstrumento.EstaInstrumentoEnUsoPorAlumnos(instrumento.Id))
            {
                MessageBox.Show($"No se puede eliminar el instrumento '{instrumento.Nombre}' porque está asignado a uno o más alumnos.",
                    "No se puede eliminar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private bool ConfirmarEliminacion(Instrumento instrumento)
        {
            DialogResult resultado = MessageBox.Show(
                $"¿Está seguro de eliminar el instrumento '{instrumento.Nombre}' de la orquesta?\n\n" +
                $"Cátedra: {instrumento.Catedra}",
                "Confirmar Eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            return resultado == DialogResult.Yes;
        }

        private void EjecutarEliminacion(Instrumento instrumento)
        {
            try
            {
                bool exito = controlInstrumento.EliminarInstrumentoDeOrquesta(instrumento.Id);
                if (exito)
                {
                    MessageBox.Show("Instrumento eliminado de la orquesta correctamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarInstrumentos();
                }
                else
                {
                    MessageBox.Show("Error al eliminar el instrumento de la orquesta.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // CORREGIDO: Ahora captura excepciones del Controlador
                MessageBox.Show($"Error al eliminar el instrumento: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // CORREGIDO: Simplificado el manejo de teclado
        private void LstInstrumentos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && lstInstrumentos.SelectedIndex != -1)
            {
                BtnEliminar_Click(sender, e);
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Escape)
            {
                BtnVolver_Click(sender, e);
                e.Handled = true;
            }
        }

        // CORREGIDO: Eliminado ProcessCmdKey redundante
        private void FrmEliminarInstrumento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                BtnVolver_Click(sender, e);
            else if (e.KeyCode == Keys.F4 && e.Alt)
                BtnSalir_Click(sender, e);
        }

        private void BtnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmPrincipal formPrincipal = new FrmPrincipal();
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
    }
}