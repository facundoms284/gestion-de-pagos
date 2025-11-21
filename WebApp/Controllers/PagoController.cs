using Microsoft.AspNetCore.Mvc;
using LogicaNegocio;
using WebApp.Filters;

namespace WebApp.Controllers;

[LoginFilter]
public class PagoController : Controller
{
    private Sistema sistema = Sistema.Instancia;

    public IActionResult Index()
    {
        string email = HttpContext.Session.GetString("Email");
        Usuario usuarioActual = sistema.ObtenerUsuarioPorEmail(email);
        
        if (HttpContext.Session.GetString("Rol") == Rol.EMPLEADO.ToString())
        {
            List<Pago> pagosMes = sistema.ObtenerPagosMesPorUsuario(email);
            pagosMes = sistema.OrdenarPagosPorMontoDesc(pagosMes);
            return View(pagosMes);
        }

        if (usuarioActual != null)
        {
            List<Pago> pagosEquipo = new List<Pago>(sistema.ObtenerPagosPorEquipo(usuarioActual.Equipo.Nombre));
            pagosEquipo = sistema.OrdenarPagosPorMontoDesc(sistema.ObtenerPagosMes((pagosEquipo)));
            return View(pagosEquipo);
        }
        
        return View();
    }

    public IActionResult AgregarPago(string mensaje)
    {
        if (mensaje != null && !string.IsNullOrEmpty(mensaje))
        {
            ViewBag.Mensaje = mensaje;
        }
        
        string email = HttpContext.Session.GetString("Email");
        Usuario usuario = sistema.ObtenerUsuarioPorEmail(email);
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
            Usuario usuario = sistema.ObtenerUsuarioPorEmail(HttpContext.Session.GetString("Email"));
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
            TempData["Mensaje"] = "Pago cargado con éxito!";
            return RedirectToAction("Index");
        }
        catch (Exception e)
        {
            return RedirectToAction("AgregarPago", new { mensaje = e.Message });
        }
    }

    [GerenteFilter]
    public IActionResult FiltrarPorFecha(DateTime Fecha)
    {
        string email = HttpContext.Session.GetString("Email");
        Usuario usuarioActual = sistema.ObtenerUsuarioPorEmail(email);
        
        if (usuarioActual != null)
        {
            List<Pago> pagosFiltrados = new List<Pago>(sistema.ObtenerPagosPorEquipo(usuarioActual.Equipo.Nombre));
            pagosFiltrados = sistema.ObtenerPagosPorFecha(Fecha);
            return View("Index", pagosFiltrados);
        }

        return View();
    }
    
}