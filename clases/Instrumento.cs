/// <summary>
/// Clase que representa un instrumento musical en el sistema
/// Define las características de cada instrumento y su categoría
/// </summary>
public class Instrumento
{
    /// <summary>
    /// Enum que clasifica los instrumentos por catedra
    /// </summary>
    public enum Tipo_Catedra
    {
        percusion,      // Instrumentos de percusión
        cuerda,         // Instrumentos de cuerda
        viento_metales, // Instrumentos de viento metal
        viento_maderas  // Instrumentos de viento madera
    }

    // Atributos que describen el instrumento
    private int id; // Identificador único del instrumento
    private string nombre; // Nombre del instrumento (ej: violín, trompeta)
    private Tipo_Catedra catedra; // Familia a la que pertenece el instrumento

    // Getters y Setters
    public int Id { get => id; set => id = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public Tipo_Catedra Catedra { get => catedra; set => catedra = value; }
}