namespace LogicaNegocio;

public class TipoDeGasto
{
    private string _nombre;
    private string _descripcion;

    public string Nombre
    {
        get { return _nombre; }
    }
    public string Descripcion
    {
        get { return _descripcion; }
        set { this._descripcion = value; }
    }
    public TipoDeGasto(string nombre, string descripcion)
    {
        this._nombre = nombre;
        this._descripcion = descripcion;
    }
}