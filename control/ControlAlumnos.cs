using GUI_Login.modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace GUI_Login.control
{
    public partial class ControlAlumno
    {
        [GeneratedRegex(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$")]
        private static partial Regex SoloLetrasRegex();

        private readonly ModeloAlumno modeloAlumno;
        private readonly ControlAlumnoInstrumento controlAlumnoInstrumento;

        public ControlAlumno()
        {
            modeloAlumno = new ModeloAlumno();
            controlAlumnoInstrumento = new ControlAlumnoInstrumento();
        }

        // ==================== OPERACIONES CRUD ====================

        public bool RegistrarAlumnoConInstrumentos(Alumno alumno, List<int> idsInstrumentos)
        {
            if (!ValidarAlumno(alumno))
                return false;

            if (!ValidarUnicidadAlumno(alumno))
                return false;

            try
            {
                int idAlumno = modeloAlumno.InsertarAlumno(alumno);
                if (idAlumno > 0)
                {
                    bool relacionesInsertadas = controlAlumnoInstrumento.RegistrarInstrumentosParaAlumno(idAlumno, idsInstrumentos);
                    if (relacionesInsertadas)
                    {
                        MessageBox.Show("Alumno registrado correctamente junto a sus instrumentos.",
                            "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;
                    }
                    else
                    {
                        modeloAlumno.EliminarAlumno(idAlumno);
                        MessageBox.Show("Error al asociar los instrumentos al alumno.",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Error al registrar el alumno en la base de datos.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception ex)
            {
                // CORREGIDO: Ahora captura excepciones del Modelo
                MessageBox.Show($"Error al registrar alumno: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool ModificarAlumnoConInstrumentos(Alumno alumno, List<int> idsInstrumentos)
        {
            if (!ValidarAlumno(alumno))
                return false;

            if (alumno.Id <= 0)
            {
                MessageBox.Show("ID de alumno no válido.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!ValidarUnicidadAlumno(alumno, alumno.Id))
                return false;

            try
            {
                bool alumnoModificado = modeloAlumno.ActualizarAlumno(alumno);
                bool instrumentosActualizados = controlAlumnoInstrumento.ActualizarInstrumentosDeAlumno(alumno.Id, idsInstrumentos);

                if (alumnoModificado && instrumentosActualizados)
                {
                    MessageBox.Show("Alumno y sus instrumentos modificados correctamente.",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    MessageBox.Show("Error al modificar el alumno o sus instrumentos.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception ex)
            {
                // CORREGIDO: Ahora captura excepciones del Modelo
                MessageBox.Show($"Error al modificar alumno: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool EliminarAlumno(int id)
        {
            if (id <= 0)
            {
                MessageBox.Show("Seleccione un alumno válido para eliminar.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!ConfirmarEliminacionAlumno(id))
                return false;

            try
            {
                bool alumnoEliminado = modeloAlumno.EliminarAlumno(id);

                if (alumnoEliminado)
                {
                    MessageBox.Show("Alumno eliminado correctamente.",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    MessageBox.Show("Error al eliminar el alumno de la base de datos.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception ex)
            {
                // CORREGIDO: Ahora captura excepciones del Modelo
                MessageBox.Show($"Error al eliminar alumno: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // ==================== VALIDACIONES MEJORADAS ====================

        public static bool ValidarAlumno(Alumno? alumno = null, string? nombre = null, string? apellido = null,
                                       object? dni = null, string? telefono = null)
        {
            if (alumno != null)
            {
                nombre = alumno.Nombre;
                apellido = alumno.Apellido;
                dni = alumno.Dni;
                telefono = alumno.Telefono_padres;
            }

            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(apellido) ||
                dni == null || string.IsNullOrWhiteSpace(telefono))
            {
                return MostrarValidacion("Todos los campos son obligatorios.");
            }

            int dniNum;
            if (dni is string dniString)
            {
                if (!int.TryParse(dniString, out dniNum) || dniNum <= 0)
                    return MostrarValidacion("El DNI debe ser un número válido.");
            }
            else if (dni is int dniInt)
            {
                dniNum = dniInt;
            }
            else
            {
                return MostrarValidacion("Formato de DNI no válido.");
            }

            // CORREGIDO: Mejor validación de DNI (ejemplo para Argentina)
            string dniStr = dniNum.ToString();
            if (dniStr.Length < 7 || dniStr.Length > 8)
                return MostrarValidacion("El DNI debe tener entre 7 y 8 dígitos.");

            // Validar teléfono
            if (!long.TryParse(telefono, out _) || telefono.Length > 15 || telefono.Length < 8)
                return MostrarValidacion("El teléfono debe contener solo números y entre 8 y 15 dígitos.");

            if (nombre.Length > 25 || !SoloLetrasRegex().IsMatch(nombre))
                return MostrarValidacion("El nombre solo puede contener letras y hasta 25 caracteres.");

            if (apellido.Length > 25 || !SoloLetrasRegex().IsMatch(apellido))
                return MostrarValidacion("El apellido solo puede contener letras y hasta 25 caracteres.");

            return true;
        }

        // ==================== MÉTODOS AUXILIARES ====================

        private static bool MostrarValidacion(string mensaje)
        {
            MessageBox.Show(mensaje, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        // Los demás métodos permanecen igual...
        public DataTable ObtenerAlumnosParaGrid()
        {
            try
            {
                return modeloAlumno.ObtenerTablaAlumnos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los alumnos: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new DataTable();
            }
        }

        public List<Alumno> ObtenerAlumnos()
        {
            try
            {
                return modeloAlumno.ObtenerAlumnosComoLista();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener la lista de alumnos: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Alumno>();
            }
        }

        public Alumno? BuscarAlumno(int id)
        {
            try
            {
                return modeloAlumno.BuscarAlumno(id);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar el alumno: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public List<int> ObtenerInstrumentosPorAlumno(int idAlumno)
        {
            try
            {
                return controlAlumnoInstrumento.ObtenerInstrumentosPorAlumno(idAlumno);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener los instrumentos del alumno: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<int>();
            }
        }

        private bool ValidarUnicidadAlumno(Alumno alumno, int idExcluir = 0)
        {
            try
            {
                if (modeloAlumno.ExisteDni(alumno.Dni, idExcluir))
                {
                    MessageBox.Show($"Ya existe un alumno con el DNI {alumno.Dni}.",
                        "DNI Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (modeloAlumno.ExisteTelefono(alumno.Telefono_padres, idExcluir))
                {
                    MessageBox.Show($"Ya existe un alumno con el teléfono {alumno.Telefono_padres}.",
                        "Teléfono Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al validar unicidad: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool ConfirmarEliminacionAlumno(int idAlumno)
        {
            Alumno? alumno = BuscarAlumno(idAlumno);
            if (alumno == null)
                return false;

            DialogResult resultado = MessageBox.Show(
                $"¿Está seguro de eliminar a {alumno.Nombre} {alumno.Apellido}?",
                "Confirmar Eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            return resultado == DialogResult.Yes;
        }

        public static bool ConfirmarModificacion()
        {
            DialogResult resultado = MessageBox.Show(
                "¿Está seguro que desea modificar los datos del alumno?",
                "Confirmar Modificación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            return resultado == DialogResult.Yes;
        }
    }
}