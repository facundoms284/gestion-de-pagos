using LogicaNegocio;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

public class TipoDeGastoController : Controller
{
    private Sistema sistema = Sistema.Instancia;
    
    public IActionResult Index()
    {
        List<TipoDeGasto> tiposDeGastos = sistema.ObtenerTiposDeGastos();

        return View(tiposDeGastos);
    }

    public IActionResult AgregarTipoDeGasto()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult AgregarTipoDeGasto(string Nombre, string Descripcion)
    {
        try
        {
            //validar que no exista
            if (sistema.ObtenerTipoDeGastoPorNombre(Nombre) != null)
            {
                ViewBag.Mensaje = "Tipo de Gasto ya existente";
                return View();
            }
            else
            {
                TipoDeGasto nuevo = new TipoDeGasto(Nombre, Descripcion);
                sistema.AgregarTipoDeGasto(nuevo);
            }
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
        return RedirectToAction("Index");
    }

    public IActionResult EliminarTipoDeGasto(string Nombre)
    {
        TipoDeGasto gasto =  sistema.ObtenerTipoDeGastoPorNombre(Nombre);
        if (gasto != null)
        {
        return View(gasto);
        }

        return RedirectToAction("Index");
    }
    
    [HttpPost]
    public IActionResult EliminarTipoDeGasto(string Nombre, string Descripcion)
    {
        try
        {
            List<Pago> pagosARecorrer = new List<Pago>(sistema.ObtenerPagos());
            TipoDeGasto gasto =  sistema.ObtenerTipoDeGastoPorNombre(Nombre);
            
            foreach (Pago pago in pagosARecorrer)
            {
                if (pago.TipoDeGasto.Nombre == Nombre && pago.TipoDeGasto.Descripcion == Descripcion)
                {
                    ViewBag.Mensaje = "No es posible eliminar este Tipo de Gasto.";
                    return View(gasto);
                }
            }

            sistema.EliminarTipoDeGastoPorNombre(Nombre);

        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
        return RedirectToAction("Index");
    }
}