using System;
using System.Collections.Generic;

public class ControlInstrumento
{
    public ModeloInstrumento modeloInstrumento;

    public ControlInstrumento()
    {
        modeloInstrumento = new ModeloInstrumento();
    }

    // Método para eliminar instrumento de la orquesta
    public bool EliminarInstrumentoDeOrquesta(int idInstrumento)
    {
        return modeloInstrumento.EliminarInstrumentoOrquesta(idInstrumento);
    }

    // Verificar si el instrumento está siendo usado por algún profesor
    public bool EstaInstrumentoEnUso(int idInstrumento)
    {
        return modeloInstrumento.EstaInstrumentoEnUso(idInstrumento);
    }

    // Verificar si el instrumento está siendo usado por algún alumno
    public bool EstaInstrumentoEnUsoPorAlumnos(int idInstrumento)
    {
        return modeloInstrumento.EstaInstrumentoEnUsoPorAlumnos(idInstrumento);
    }

    // Resto de los métodos existentes...
    public List<Instrumento> ListarInstrumentosDisponibles()
    {
        return modeloInstrumento.ListarInstrumentosDisponibles();
    }

    public List<Instrumento> ListarInstrumentosEnOrquesta()
    {
        return modeloInstrumento.ListarInstrumentosOrquesta();
    }

    public bool AgregarInstrumentoAOrquesta(int idInstrumento)
    {
        return modeloInstrumento.AgregarInstrumentoOrquesta(idInstrumento);
    }
}