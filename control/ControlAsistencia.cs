using GUI_Login.modelo;
using System;
using System.Collections.Generic;
using System.Data;

namespace GUI_Login.control
{
    /// <summary>
    /// Controlador para la gestión de asistencias
    /// Maneja el registro y consulta de asistencias a diferentes actividades del orquesta
    /// </summary>
    public class ControlAsistencia
    {
        private readonly ModeloAsistencia modeloAsistencia;

        /// <summary>
        /// Constructor que inicializa el modelo de asistencias
        /// </summary>
        public ControlAsistencia()
        {
            modeloAsistencia = new ModeloAsistencia();
        }

        /// <summary>
        /// Obtiene la lista completa de alumnos para el registro de asistencias
        /// </summary>
        /// Retorna una Lista de objetos Alumno
        public List<Alumno> ObtenerAlumnos()
        {
            try
            {
                return modeloAsistencia.ListarAlumnos();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en ObtenerAlumnos: " + ex.Message);
                return [];
            }
        }

        /// <summary>
        /// Guarda una lista de asistencias en la base de datos
        /// Registra tanto presentes como ausentes para tener control completo
        /// </summary>
        /// asistencias: Lista de objetos Asistencia a guardar

        public bool GuardarAsistencias(List<Asistencia> asistencias)
        {
            if (asistencias == null || asistencias.Count == 0)
            {
                Console.WriteLine("Lista de asistencias vacía");
                return false;
            }

            bool todosGuardados = true;

            foreach (Asistencia a in asistencias)
            {
                try
                {
                    if (a == null || !ValidarAsistencia(a))
                    {
                        todosGuardados = false;
                        continue;
                    }

                    // Guarda a los presentes y ausentes
                    bool ok = modeloAsistencia.MarcarAsistencia(a);
                    if (!ok) todosGuardados = false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error guardando asistencia: {ex.Message}");
                    todosGuardados = false;
                }
            }

            return todosGuardados;
        }

        /// <summary>
        /// Valida que una asistencia tenga todos los datos requeridos
        /// </summary>
        /// asistencia: Objeto Asistencia a validar

        private static bool ValidarAsistencia(Asistencia asistencia)
        {
            return asistencia.IdAlumno > 0 &&
                   asistencia.Fecha != DateTime.MinValue &&
                   Enum.IsDefined(typeof(Asistencia.Tipo_Actividad), asistencia.TipoActividad);
        }

        /// <summary>
        /// Obtiene los datos de asistencias en formato DataTable para mostrar en GridView
        /// </summary>
        /// Retornar un DataTable con el historial de asistencias
        public DataTable ObtenerDatosParaGrid()
        {
            try
            {
                return modeloAsistencia.ObtenerTablaAsistencia();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en ObtenerDatosParaGrid: " + ex.Message);
                return new DataTable();
            }
        }
    }
}