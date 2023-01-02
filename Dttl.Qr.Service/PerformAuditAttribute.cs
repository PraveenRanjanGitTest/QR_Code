using Microsoft.AspNetCore.Mvc.Filters;
using ActionFilterAttribute = Microsoft.AspNetCore.Mvc.Filters.ActionFilterAttribute;

namespace Dttl.Qr.Service
{
    public class PerformAuditAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.Controller is BaseController)
            {
                var controllerName = context.ActionDescriptor.RouteValues["controller"];
                var actionName = context.ActionDescriptor.RouteValues["action"];
                var controller = context.Controller as BaseController;
                controller!._logger.LogInformation(
                    $@"{controller.Request.Method}:{controllerName}\{actionName}"
                    );
            }
            base.OnActionExecuting(context);
        }
    }
}