using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApp.Filters;

public class LoginFilter : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        string? email = context.HttpContext.Session.GetString("Email");
        if (email == null)
        {
            context.Result = new RedirectToActionResult("Login", "Usuario", new { error = "Debe iniciar sesión" });
        }
        base.OnActionExecuting(context);
    }
}