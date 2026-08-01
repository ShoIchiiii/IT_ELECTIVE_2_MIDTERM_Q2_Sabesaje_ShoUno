using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApplication1.Filters
{
    public class AuthorizeSessionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var userSession = context.HttpContext.Session.GetString("UserSession");

            if (string.IsNullOrEmpty(userSession))
            {
                context.Result = new RedirectToActionResult("Login", "Auth", null);
            }

            base.OnActionExecuting(context);
        }
    }
}