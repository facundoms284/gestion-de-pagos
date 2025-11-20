using LogicaNegocio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApp.Filters;

public class GerenteFilter : ActionFilterAttribute
{
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string rol = context.HttpContext.Session.GetString("Rol");
            if (rol != Rol.GERENTE.ToString())
            {
                context.Result = new RedirectToActionResult("Perfil", "Usuario", new { error = "Permisos Insuficientes" });
            }
            base.OnActionExecuting(context);
        }
}