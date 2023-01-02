using Dttl.Qr.Model;
using Dttl.Qr.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Dttl.Qr.Service
{
    [Route("api/[controller]")]
    [ApiController]
    public class QRCodeController : BaseController
    {
        private readonly IQRCodeService _qRCodeService;

        public QRCodeController(IQRCodeService qRCodeService, ILogger<QRCodeController> logger) : base(logger)
        {
            _qRCodeService = qRCodeService;
        }

        [HttpGet("GetQRCodeList")]
        public async Task<IActionResult> GetQRCodeList()
        {
            var result = await _qRCodeService.GetQRCodeList();
            if (result == null)
            {
                return NotFound();
            }
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpGet("GetQRCodeListById")]
        public async Task<IActionResult> GetQRCodeListById(int Id)
        {
            var result = await _qRCodeService.GetQRCodeListById(Id);
            if (result == null)
            {
                return NotFound();
            }
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpPost("AddQRCodes")]
        public async Task<IActionResult> AddQRCodes([FromBody] QrCode qrCode)
        {
            if (ModelState.IsValid)
            {
                var result = await _qRCodeService.AddQRCodes(qrCode);
                return StatusCode(StatusCodes.Status201Created, result);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("UpdateQRCode")]
        public async Task<IActionResult> UpdateQRCode([FromBody] QrCode qRCode)
        {
            if (ModelState.IsValid)
            {
                var result = await _qRCodeService.UpdateQRCode(qRCode);
                return StatusCode(StatusCodes.Status200OK, qRCode);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("DeleteQRCodes")]
        public async Task<IActionResult> DeleteQRCodes(int Id)
        {
            var result = await _qRCodeService.DeleteQRCodes(Id);
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