using Dttl.Qr.Model;
using Dttl.Qr.Repository;
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
            if (result == null)
            {
                return NotFound();
            }
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpGet("GetQRTemplateListById")]
        public async Task<IActionResult> GetQRTemplateListById(int Id)
        {
            var result = await _qRTemplateService.GetQRTemplateListById(Id);
            if (result == null)
            {
                return NotFound();
            }
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpPost("AddQRTemplate")]
        public async Task<IActionResult> AddQRTemplate([FromBody] QRTemplate qRTemplate)
        {
            if (ModelState.IsValid)
            {
                var result = await _qRTemplateService.AddQRTemplate(qRTemplate);
                return StatusCode(StatusCodes.Status201Created, result);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("UpdateQRTemplate")]
        public async Task<IActionResult> UpdateQRTemplate([FromBody] QRTemplate qRTemplate)
        {
            if (ModelState.IsValid)
            {
                var result = await _qRTemplateService.AddQRTemplate(qRTemplate);
                return StatusCode(StatusCodes.Status200OK, qRTemplate);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("DeleteQRTemplate")]
        public async Task<IActionResult> DeleteQRTemplate(int Id)
        {
            var result = await _qRTemplateService.DeleteQRTemplate(Id);
            if (result == null)
            {
                return NotFound();
            }
            else
            {
                return StatusCode(StatusCodes.Status200OK, result);
            }
        }
    }
}