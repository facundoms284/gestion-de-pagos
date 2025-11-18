namespace LogicaNegocio.Ordenamiento;

public class EquipoUsuariosPorEmailAsc : IComparer<Usuario>
{
    public int Compare(Usuario? este, Usuario? otro)
    {
        return este.Email.CompareTo(otro.Email);
    }
}