namespace LogicaNegocio.Ordenamiento;

public class PagoOrdenPorMonto : IComparer<Pago>
{
    public int Compare(Pago? este, Pago? otro)
    {
        return este.CostoMostrar.CompareTo(otro.CostoMostrar) * -1;
    }
}