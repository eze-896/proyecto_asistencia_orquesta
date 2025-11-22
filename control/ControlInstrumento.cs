using GUI_Login.modelo;
using System;
using System.Collections.Generic;

namespace GUI_Login.control
{
    /// <summary>
    /// Controlador para la gestión de instrumentos musicales
    /// Maneja las operaciones relacionadas con instrumentos en la orquesta
    /// </summary>
    public class ControlInstrumento
    {
        public ModeloInstrumento modeloInstrumento;

        /// <summary>
        /// Constructor que inicializa el modelo de instrumentos
        /// </summary>
        public ControlInstrumento()
        {
            modeloInstrumento = new ModeloInstrumento();
        }

        /// <summary>
        /// Elimina un instrumento de la orquesta (tabla instrumento_orquesta)
        /// </summary>
        /// idInstrumento: ID del instrumento a eliminar

        public bool EliminarInstrumentoDeOrquesta(int idInstrumento)
        {
            return modeloInstrumento.EliminarInstrumentoOrquesta(idInstrumento);
        }

        /// <summary>
        /// Verifica si un instrumento está siendo usado por algún profesor
        /// Previene la eliminación de instrumentos en uso
        /// </summary>
        /// idInstrumento: ID del instrumento a verificar
        /// Retorna True si el instrumento está en uso por profesores
        public bool EstaInstrumentoEnUso(int idInstrumento)
        {
            return modeloInstrumento.EstaInstrumentoEnUso(idInstrumento);
        }

        /// <summary>
        /// Verifica si un instrumento está siendo usado por algún alumno
        /// Previene la eliminación de instrumentos asignados a alumnos
        /// </summary>
        /// idInstrumento: ID del instrumento a verificar
        /// Retorna True si el instrumento está en uso por alumnos
        public bool EstaInstrumentoEnUsoPorAlumnos(int idInstrumento)
        {
            return modeloInstrumento.EstaInstrumentoEnUsoPorAlumnos(idInstrumento);
        }

        /// <summary>
        /// Obtiene la lista de instrumentos disponibles para asignar
        /// </summary>
        /// Retorna una Lista de instrumentos disponibles
        public List<Instrumento> ListarInstrumentosDisponibles()
        {
            return modeloInstrumento.ListarInstrumentosDisponibles();
        }

        /// <summary>
        /// Obtiene la lista de instrumentos que actualmente están en la orquesta
        /// </summary>
        /// Retorna una Lista de instrumentos en la orquesta
        public List<Instrumento> ListarInstrumentosEnOrquesta()
        {
            return modeloInstrumento.ListarInstrumentosOrquesta();
        }

        /// <summary>
        /// Agrega un instrumento a la orquesta
        /// </summary>
        /// idInstrumento: ID del instrumento a agregar

        public bool AgregarInstrumentoAOrquesta(int idInstrumento)
        {
            return modeloInstrumento.AgregarInstrumentoOrquesta(idInstrumento);
        }
    }
}