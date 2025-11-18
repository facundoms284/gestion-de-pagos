using Microsoft.AspNetCore.Mvc;
using LogicaNegocio;

namespace WebApp.Controllers;

public class UsuarioController : Controller
{
    private Sistema sistema = Sistema.Instancia;
    
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
                return RedirectToAction("Perfil");
            }
        }
        catch(Exception ex)
        {
            ViewBag.Mensaje = ex.Message;
        }

        return View();
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Login");
    }

    public IActionResult Perfil()
    {
        string email = HttpContext.Session.GetString("Email");
        //string rol = HttpContext.Session.GetString("Rol");
        
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