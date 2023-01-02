using Dttl.Qr.Model;
using Dttl.Qr.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Dttl.Qr.Service
{
    [Route("api/[controller]")]
    [ApiController]
    public class VCardController : BaseController
    {
        private readonly IVCardService _vCardService;

        public VCardController(IVCardService vCardService, ILogger<VCardController> logger) : base(logger)
        {
            _vCardService = vCardService;
        }

        [HttpGet("GetVCardList")]
        public async Task<IActionResult> GetVCardList()
        {
            var result = await _vCardService.GetVCardList();
            if (result == null)
            {
                return NotFound();
            }
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpGet("GetVCardById")]
        public async Task<IActionResult> GetVCardById(int Id)
        {
            var result = await _vCardService.GetVCardById(Id);
            if (result == null)
            {
                return NotFound();
            }
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpPost("AddVCard")]
        public async Task<IActionResult> AddVCard([FromBody] VCardQRCode vCardDetails)
        {
            if (ModelState.IsValid)
            {
                var result = await _vCardService.AddVCard(vCardDetails);
                return StatusCode(StatusCodes.Status201Created, result);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("UpdateVCard")]
        public async Task<IActionResult> UpdateVCarde([FromBody] VCardQRCode vCardDetails)
        {
            if (ModelState.IsValid)
            {
                var result = await _vCardService.UpdateVCarde(vCardDetails);
                return StatusCode(StatusCodes.Status200OK, result);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("DeleteVCard")]
        public async Task<IActionResult> DeleteVCard(int Id)
        {
            var result = await _vCardService.DeleteVCard(Id);
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