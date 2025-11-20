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

    public void Validar()
    {
        this.ValidarNombre();
        this.ValidarId();
    }

    private void ValidarNombre()
    {
        if (string.IsNullOrEmpty(this._nombre))
        {
            throw new Exception("El nombre del equipo no puede estar vacío");
        }
    }

    private void ValidarId()
    {
        if (this._id == null)
        {
            throw new Exception("Id inválido");
        }
    }
}