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
            if (result.Count == 0)
            {
                return StatusCode(StatusCodes.Status404NotFound, "No Results Found");
            }
            return Ok(result);
        }

        [HttpGet("GetQRCodeListById")]
        public async Task<IActionResult> GetQRCodeListById(int Id)
        {
            var result = await _qRCodeService.GetQRCodeListById(Id);
            if (result.Count == 0)
            {
                return StatusCode(StatusCodes.Status404NotFound, "No Results Found");
            }
            return Ok(result);
        }

        [HttpPost("AddQRCodes")]
        public async Task<IActionResult> AddQRCodes([FromBody] QrCode qrCode)
        {
            var result = await _qRCodeService.AddQRCodes(qrCode);
            return StatusCode(StatusCodes.Status201Created, "Data Save Successfully");
        }

        [HttpPut("UpdateQRCode")]
        public async Task<IActionResult> UpdateQRCode([FromBody] QrCode qRCode)
        {
            var result = await _qRCodeService.UpdateQRCode(qRCode);
            return StatusCode(StatusCodes.Status200OK, "Data Updated Successfully");
        }

        [HttpDelete("DeleteQRCodes")]
        public async Task<IActionResult> DeleteQRCodes(int Id)
        {
            var result = await _qRCodeService.DeleteQRCodes(Id);
            if (result == 1)
            {
                return StatusCode(StatusCodes.Status200OK, "Data Deleted Successfully");
            }
            else
            {
                return StatusCode(StatusCodes.Status404NotFound, "No Results Found");
            }
        }
    }
}