using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ActionFilterAttribute = Microsoft.AspNetCore.Mvc.Filters.ActionFilterAttribute;

namespace Dttl.Qr.Service.ActionFilters
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            if (actionContext.Controller is BaseController)
            {
                if (!actionContext.ModelState.IsValid)
                {
                    actionContext.Result = new BadRequestResult();
                }
            }
        }
    }
}