using System;
using System.Collections.Generic;

public class ControlInstrumento
{
    public ModeloInstrumento modeloInstrumento;

    public ControlInstrumento()
    {
        modeloInstrumento = new ModeloInstrumento();
    }

    // Devuelve lista de instrumentos disponibles (no en la orquesta)
    public List<Instrumento> ListarInstrumentosDisponibles()
    {
        return modeloInstrumento.ListarInstrumentosDisponibles();
    }

    // Devuelve lista de instrumentos que ya están en la orquesta
    public List<Instrumento> ListarInstrumentosEnOrquesta()
    {
        return modeloInstrumento.ListarInstrumentosOrquesta();
    }

    // Agrega un instrumento a la orquesta por su ID
    public bool AgregarInstrumentoAOrquesta(int idInstrumento)
    {
        return modeloInstrumento.AgregarInstrumentoOrquesta(idInstrumento);
    }
}
