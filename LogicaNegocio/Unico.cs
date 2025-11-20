namespace LogicaNegocio;

public class Unico : Pago
{
    private DateTime _fechaPago;
    private string _numeroRecibo;

    public DateTime FechaPago
    {
        get { return _fechaPago; }
    }

    public Unico(string descripcion, double monto, MetodoDePago metodo, TipoDeGasto tipo, Usuario usuario, DateTime fechaPago, string numeroRecibo)
        : base(descripcion, monto, metodo, tipo, usuario)
    {
        this._fechaPago = fechaPago;
        this._numeroRecibo = numeroRecibo;
    }

    public override void Validar()
    {
        this.ValidarFechaPago();
        this.ValidarNumeroRecibo();
        this.ValidarMonto();
        this.ValidarDescripcion();
    }

    private void ValidarFechaPago()
    {
        if (this._fechaPago.Day < DateTime.Now.Day)
        {
            throw new Exception("Fecha de pago inválida.");
        }
    }

    private void ValidarNumeroRecibo()
    {
        if (string.IsNullOrEmpty(this._numeroRecibo))
        {
            throw new Exception("Numero de recibo inválido.");
        }
    }

    private void ValidarMonto()
    {
        if (this.Monto < 1)
        {
            throw new Exception("Monto inválido.");
        }
    }

    private void ValidarDescripcion()
    {
        if (string.IsNullOrEmpty(this.Descripcion))
        {
            throw new Exception("Descripción inválida.");
        }
    }
    
    public override double CalcularCosto()
    {
        double descuento = this.Monto * (1 - CalcularDescuento());
        return this.Monto - descuento;
    }

    public double CalcularDescuento()
    {
        if (this.MetodoDePago == MetodoDePago.EFECTIVO)
        {
            return 0.2;
        }
        return 0.1;
    }
        
}