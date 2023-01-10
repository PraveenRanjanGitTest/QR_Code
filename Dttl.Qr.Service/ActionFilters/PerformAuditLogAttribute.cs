using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using ActionFilterAttribute = Microsoft.AspNetCore.Mvc.Filters.ActionFilterAttribute;

namespace Dttl.Qr.Service.ActionFilters
{
    public class PerformAuditLogAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var parameters = context.ActionArguments.Where(a => a.Value != null).ToList();
            var actions = context.ActionDescriptor.RouteValues.Where(a => a.Value != null).ToList();

            if (context.Controller is BaseController)
            {
                var controller = context.Controller as BaseController;
                controller!._logger.LogInformation(
                    $@"Action: {JsonConvert.SerializeObject(actions)} Parameters: {JsonConvert.SerializeObject(parameters)}"
                    );
            }
            base.OnActionExecuting(context);
        }
    }
}