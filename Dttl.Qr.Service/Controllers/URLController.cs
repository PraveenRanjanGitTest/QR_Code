using Dttl.Qr.Model;
using Dttl.Qr.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Dttl.Qr.Service
{
    [Route("api/[controller]")]
    [ApiController]
    public class URLController : BaseController
    {
        private readonly IURLService _uRLService;

        public URLController(IURLService uRLService, ILogger<URLController> logger) : base(logger)
        {
            _uRLService = uRLService;
        }

        [HttpGet("GetURLQRCodeList")]
        public async Task<IActionResult> GetURLQRCodelList()
        {
            var result = await _uRLService.GetURLQRCodelList();
            if (result.Count == 0)
            {
                return StatusCode(StatusCodes.Status404NotFound, "No Results Found");
            }
            return Ok(result);
        }

        [HttpGet("GetURLQRCodeListById")]
        public async Task<IActionResult> GetURLQRCodeListById(int Id)
        {
            var result = await _uRLService.GetURLQRCodeListById(Id);
            if (result.Count == 0)
            {
                return StatusCode(StatusCodes.Status404NotFound, "No Results Found");
            }
            return Ok(result);
        }

        [HttpPost("AddURLQRCode")]
        public async Task<IActionResult> AddURLQRCode([FromBody] URLQRCode uRLQRCode)
        {
            var result = await _uRLService.AddURLQRCode(uRLQRCode);
            return StatusCode(StatusCodes.Status201Created, "Data Save Successfully");
        }

        [HttpPut("UpdateURLQRCode")]
        public async Task<IActionResult> UpdateURLQRCode([FromBody] URLQRCode uRLQRCode)
        {
            var result = await _uRLService.UpdateURLQRCode(uRLQRCode);
            return StatusCode(StatusCodes.Status200OK, "Data Updated Successfully");
        }

        [HttpDelete("DeleteURLQRCode")]
        public async Task<IActionResult> DeleteURLQRCode(int Id)
        {
            var result = await _uRLService.DeleteURLQRCode(Id);
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