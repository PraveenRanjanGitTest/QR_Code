using Dttl.Qr.Data;
using Dttl.Qr.Model;
using Dttl.Qr.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

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
            if (result == null)
            {
                return NotFound();
            }
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpGet("GetURLQRCodeListById")]
        public async Task<IActionResult> GetURLQRCodeListById(int Id)
        {
            var result = await _uRLService.GetURLQRCodeListById(Id);
            if (result == null)
            {
                return NotFound();
            }
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpPost("AddURLQRCode")]
        public async Task<IActionResult> AddURLQRCode([FromBody] URLQRCode uRLQRCode)
        {
            if (ModelState.IsValid)
            {
                var result = await _uRLService.AddURLQRCode(uRLQRCode);
                return StatusCode(StatusCodes.Status201Created, uRLQRCode);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("UpdateURLQRCode")]
        public async Task<IActionResult> UpdateURLQRCode([FromBody] URLQRCode uRLQRCode)
        {
            if (ModelState.IsValid)
            {
                var result = await _uRLService.UpdateURLQRCode(uRLQRCode);
                return StatusCode(StatusCodes.Status200OK, result);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("DeleteURLQRCode")]
        public async Task<IActionResult> DeleteURLQRCode(int Id)
        {
            var result = await _uRLService.DeleteURLQRCode(Id);
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