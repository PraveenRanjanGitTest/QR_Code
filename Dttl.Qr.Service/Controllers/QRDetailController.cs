using Dttl.Qr.Model;
using Dttl.Qr.Repository.Interface;
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
            if (result.Count == 0)
            {
                return StatusCode(StatusCodes.Status404NotFound, "No Results Found");
            }
            return Ok(result);
        }

        [HttpGet("GetQRDetailListById")]
        public async Task<IActionResult> GetQRDetailListById(int Id)
        {
            var result = await _qRDetailService.GetQRDetailListById(Id);
            if (result == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, "No Results Found");
            }
            return Ok(result);
        }

        [HttpPost("AddQRDetails")]
        public async Task<IActionResult> AddQRDetails([FromBody] QRDetails qRDetails)
        {
            var result = await _qRDetailService.AddQRDetails(qRDetails);
            return StatusCode(StatusCodes.Status201Created, "Data Save Successfully");
        }

        [HttpPut("UpdateQReDetails")]
        public async Task<IActionResult> UpdateQReDetails([FromBody] QRDetails qRDetails)
        {
            var result = await _qRDetailService.UpdateQReDetails(qRDetails);
            return StatusCode(StatusCodes.Status200OK, "Data Updated Successfully");
        }

        [HttpDelete("DeleteQRDetails")]
        public async Task<IActionResult> DeleteQRDetails(int Id)
        {
            var result = await _qRDetailService.DeleteQRDetails(Id);
            return StatusCode(StatusCodes.Status200OK, "Data Deleted Successfully");
        }
    }
}