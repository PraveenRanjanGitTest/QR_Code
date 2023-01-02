using Dttl.Qr.Model;
using Dttl.Qr.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Dttl.Qr.Service
{
    [Route("api/[controller]")]
    [ApiController]
    public class QRDetailController : BaseController
    {
        private readonly IQRDetailService _qRDetailService;

        public QRDetailController(IQRDetailService qRDetailService, ILogger<QRDetailController> logger) : base(logger)
        {
            _qRDetailService = qRDetailService;
        }

        [HttpGet("GetQRDetailList")]
        public async Task<IActionResult> GetQRDetailList()
        {
            var result = await _qRDetailService.GetQRDetailList();
            if (result == null)
            {
                return NotFound();
            }
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpGet("GetQRDetailListById")]
        public async Task<IActionResult> GetQRDetailListById(int Id)
        {
            var result = await _qRDetailService.GetQRDetailListById(Id);
            if (result == null)
            {
                return NotFound();
            }
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpPost("AddQRDetails")]
        public async Task<IActionResult> AddQRDetails([FromBody] QRDetails qRDetails)
        {
            if (ModelState.IsValid)
            {
                var result = await _qRDetailService.AddQRDetails(qRDetails);
                return StatusCode(StatusCodes.Status201Created, result);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("UpdateQReDetails")]
        public async Task<IActionResult> UpdateQReDetails([FromBody] QRDetails qRDetails)
        {
            if (ModelState.IsValid)
            {
                var result = await _qRDetailService.UpdateQReDetails(qRDetails);
                return StatusCode(StatusCodes.Status200OK, result);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("DeleteQRDetails")]
        public async Task<IActionResult> DeleteQRDetails(int Id)
        {
            var result = await _qRDetailService.DeleteQRDetails(Id);
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