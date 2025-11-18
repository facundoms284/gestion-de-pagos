namespace LogicaNegocio;

public class Equipo
{
    private int _id;
    private string _nombre;

    public string Nombre
    {
        get { return this._nombre; }
    }
    public Equipo(int id, string nombre)
    {
        this._id = id;
        this._nombre = nombre;
    }

    public override string ToString()
    {
        return $"{this._nombre}";
    }
}