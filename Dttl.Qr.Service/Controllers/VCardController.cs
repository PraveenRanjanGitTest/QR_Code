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
            if (result.Count == 0)
            {
                return StatusCode(StatusCodes.Status404NotFound, "No Results Found");
            }
            return Ok(result);
        }

        [HttpGet("GetVCardById")]
        public async Task<IActionResult> GetVCardById(int Id)
        {
            var result = await _vCardService.GetVCardById(Id);
            if (result.Count == 0)
            {
                return StatusCode(StatusCodes.Status404NotFound, "No Results Found");
            }
            return Ok(result);
        }

        [HttpPost("AddVCard")]
        public async Task<IActionResult> AddVCard([FromBody] VCardQRCode vCardDetails)
        {
            var result = await _vCardService.AddVCard(vCardDetails);
            return StatusCode(StatusCodes.Status201Created, "Data Save Successfully");
        }

        [HttpPut("UpdateVCard")]
        public async Task<IActionResult> UpdateVCarde([FromBody] VCardQRCode vCardDetails)
        {
            var result = await _vCardService.UpdateVCarde(vCardDetails);
            return StatusCode(StatusCodes.Status200OK, "Data Updated Successfully");
        }

        [HttpDelete("DeleteVCard")]
        public async Task<IActionResult> DeleteVCard(int Id)
        {
            var result = await _vCardService.DeleteVCard(Id);
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