using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace SRV.Api.Filters
{
    public class RoleCheckAttribute : ActionFilterAttribute
    {
        private readonly string _role;

        public RoleCheckAttribute(string role)
        {
            _role = role;
        }
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if(!context.HttpContext.User.HasClaim("userRole", _role))
            {
                context.Result = new UnauthorizedObjectResult("You do not have enough permissions to add a student");
            }
            else
                await next();
        }
    }
}
