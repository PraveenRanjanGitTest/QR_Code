using Dttl.Qr.Model;
using Dttl.Qr.Repository;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Dttl.Qr.Service
{
    [Route("api/[controller]")]
    [ApiController]
    public class QRTemplateController : BaseController
    {
        private readonly IQRTemplateService _qRTemplateService;

        public QRTemplateController(IQRTemplateService qRTemplateService, ILogger<QRTemplateController> logger) : base(logger)
        {
            _qRTemplateService = qRTemplateService;
        }

        [HttpGet("GetQRTemplateList")]
        public async Task<IActionResult> GetQRTemplateList()
        {
            var result = await _qRTemplateService.GetQRTemplateList();
            if (result.Count == 0)
            {
                return NotFound("Template Not Found");
            }
            return Ok(result);
        }

        [HttpGet("GetQRTemplateListById")]
        public async Task<IActionResult> GetQRTemplateListById(int Id)
        {
            var result = await _qRTemplateService.GetQRTemplateListById(Id);
            if (result.Count == 0)
            {
                return NotFound("Template Not Found");
            }
            return Ok(result);
        }

        [HttpPost("AddQRTemplate")]
        public async Task<IActionResult> AddQRTemplate([FromBody] QRTemplate qRTemplate)
        {
            var result = await _qRTemplateService.AddQRTemplate(qRTemplate);
            return Ok("Data Save Successfully");
        }

        [HttpPut("UpdateQRTemplate")]
        public async Task<IActionResult> UpdateQRTemplate([FromBody] QRTemplate qRTemplate)
        {
            var result = await _qRTemplateService.UpdateQRTemplate(qRTemplate);
            return Ok("Data Updated Successfully");
        }

        [HttpDelete("DeleteQRTemplate")]
        public async Task<IActionResult> DeleteQRTemplate(int Id)
        {
            var result = await _qRTemplateService.DeleteQRTemplate(Id);
            if (result == 1)
            {
                return Ok("Data Deleted Successfully");
            }
            else
            {
                return NotFound("Template Id Not Found");
            }
        }
    }
}