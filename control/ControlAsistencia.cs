using GUI_Login.modelo;
using System;
using System.Collections.Generic;
using System.Data;

namespace GUI_Login.control
{
    public class ControlAsistencia
    {
        private readonly ModeloAsistencia modeloAsistencia;

        public ControlAsistencia()
        {
            modeloAsistencia = new ModeloAsistencia();
        }

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

                    // 🔹 Ahora guardamos tanto presentes como ausentes
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


        private static bool ValidarAsistencia(Asistencia asistencia)
        {
            return asistencia.IdAlumno > 0 &&
                   asistencia.Fecha != DateTime.MinValue &&
                   Enum.IsDefined(typeof(Asistencia.Tipo_Actividad), asistencia.TipoActividad);
        }

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