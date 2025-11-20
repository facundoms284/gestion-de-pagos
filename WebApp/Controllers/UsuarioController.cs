using Microsoft.AspNetCore.Mvc;
using LogicaNegocio;
using WebApp.Filters;

namespace WebApp.Controllers;

public class UsuarioController : Controller
{
    private Sistema sistema = Sistema.Instancia;
    
    [LoginFilter]
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(string Email, string Contrasena)
    {
        try
        {
            Usuario usuario = sistema.BuscarUsuario(Email, Contrasena);
            if (usuario != null)
            {
                HttpContext.Session.SetString("Email", usuario.Email);
                HttpContext.Session.SetString("Rol", usuario.Rol.ToString());
                TempData["Mensaje"] = "Logueado con éxito";
                return RedirectToAction("Perfil");
            }
            else
            {
                ViewBag.Mensaje = "Datos incorrectos";
            }
        }
        catch(Exception ex)
        {
            ViewBag.Mensaje = ex.Message;
        }

        return View();
    }

    [LoginFilter]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Login");
    }

    [LoginFilter]
    public IActionResult Perfil()
    {
        string email = HttpContext.Session.GetString("Email");
        
        if (email == null) return RedirectToAction("Login");
        
        Usuario usuario = sistema.BuscarUsuarioPorEmail(email);
        
        List<Usuario> usuariosEquipo = sistema.ObtenerUsuariosPorEquipo(usuario.Equipo.Nombre);
        usuariosEquipo = sistema.OrdenarUsuariosEquipoPorEmailAsc(usuariosEquipo);
        ViewBag.Usuarios = usuariosEquipo;
        
        double totalGastadoMes = sistema.ObtenerTotalPagosMesPorUsuario(usuario.Email);
        ViewBag.TotalGastadoMes = totalGastadoMes;
        return View(usuario);
    }
}