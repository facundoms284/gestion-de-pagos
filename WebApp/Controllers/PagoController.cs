using Microsoft.AspNetCore.Mvc;
using LogicaNegocio;

namespace WebApp.Controllers;

public class PagoController : Controller
{
    private Sistema sistema = Sistema.Instancia;

    public IActionResult Index()
    {
        string email = HttpContext.Session.GetString("Email");
        if (email == null)
        {
            return RedirectToAction("Login", "Usuario");
        }

        List<Pago> pagosMes = sistema.ObtenerPagosMesPorUsuario(email);
        pagosMes = sistema.OrdenarPagosPorMontoDesc(pagosMes);
        return View(pagosMes);
    }

    public IActionResult AgregarPago()
    {
        string email = HttpContext.Session.GetString("Email");
        Usuario usuario = sistema.BuscarUsuarioPorEmail(email);
        ViewBag.Usuario = usuario;
        List<TipoDeGasto> tiposDeGastos = sistema.ObtenerTiposDeGastos();
        ViewBag.TiposDeGastos = tiposDeGastos;
        return View();
    }
    
    [HttpPost]
    public IActionResult AgregarPago
    (
        string Descripcion,
        double Monto,
        MetodoDePago MetodoDePago,
        string TipoPagoSeleccionado,
        string TipoDeGasto,
        DateTime FechaDesde,
        DateTime? FechaHasta,
        DateTime FechaPago,
        string NumeroRecibo)
    {
        try
        {
            Usuario usuario = sistema.BuscarUsuarioPorEmail(HttpContext.Session.GetString("Email"));
            //Obtenemos el tipo de gasto por nombre
            TipoDeGasto encontrado = sistema.ObtenerTipoDeGastoPorNombre(TipoDeGasto);
            TipoDeGasto tipoDeGasto = new TipoDeGasto(encontrado.Nombre, encontrado.Descripcion);
            
            Pago nuevoPago;
            
            if (TipoPagoSeleccionado == "RECURRENTE")
            {
                nuevoPago = new Recurrente(
                    Descripcion,
                    Monto,
                    MetodoDePago,
                    tipoDeGasto,
                    usuario,
                    FechaDesde,
                    FechaHasta
                );

            }  else
            {
                nuevoPago = new Unico(
                    Descripcion,
                    Monto,
                    MetodoDePago,
                    tipoDeGasto,
                    usuario,
                    FechaPago,
                    NumeroRecibo
                );

            }
        
            sistema.AgregarPago(nuevoPago);
            return RedirectToAction("Index");
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
            return View();
        }
    }
    
}