using Microsoft.AspNetCore.Mvc;

namespace Dttl.Qr.Service
{
   
    [PerformAudit]
    [HandleError]
    [ValidateModel]
    public class BaseController : ControllerBase
    {
        public readonly ILogger _logger;

        public BaseController(ILogger logger)
        {
            _logger = logger;
        }
    }
}