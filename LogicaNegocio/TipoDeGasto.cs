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

    public void Validar()
    {
        this.ValidarNombre();
        this.ValidarDescripcion();
    }

    private void ValidarNombre()
    {
        if (string.IsNullOrEmpty(this._nombre))
        {
            throw new Exception("El nombre no puede estar vacío");
        }
    }

    private void ValidarDescripcion()
    {
        if (string.IsNullOrEmpty(this._descripcion))
        {
            throw new Exception("La descripcion no puede estar vacía");
        }
    }
}