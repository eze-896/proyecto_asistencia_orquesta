public class Instrumento
{
    public enum Tipo_Catedra
    {
        percusion,
        cuerda,
        viento_metales,
        viento_maderas
    }

    private int id; // Viene de la tabla instrumento_orquesta

    // Vienen de la tabla instrumento
    private string nombre;
    private Tipo_Catedra catedra;

    public int Id { get => id; set => id = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public Tipo_Catedra Catedra { get => catedra; set => catedra = value; }
}
