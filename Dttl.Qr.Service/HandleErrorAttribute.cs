using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

using System.Net;

namespace Dttl.Qr.Service
{
    public class HandleErrorAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception != null)
            {
                Exception ex = context.Exception.InnerException ?? context.Exception;
                if (context.Controller is BaseController)
                {
                    var controller = context.Controller as BaseController;
                    controller!._logger.LogError(
                        $"{ex} occured in {context.ActionDescriptor.RouteValues["controller"]}\\{context.ActionDescriptor.RouteValues["action"]}"
                        );

                    context.Result = new ObjectResult(ex.Message)
                    {
                        StatusCode = (int?)HttpStatusCode.InternalServerError
                    };
                    context.ExceptionHandled = false;
                }
            }

            base.OnActionExecuted(context);
        }
    }
}