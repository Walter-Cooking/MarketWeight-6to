using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;

namespace Marketweight_6to.mvc.Filters
{
    public class Authorize : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var httpContext = context.HttpContext;
            var isLoggedIn = !string.IsNullOrEmpty(httpContext.Session.GetString("UsuarioId"));

            if (!isLoggedIn)
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary
                {
                    { "controller", "Home" },
                    { "action", "Login" }
                });
            }

            base.OnActionExecuting(context);
        }
    }
}


