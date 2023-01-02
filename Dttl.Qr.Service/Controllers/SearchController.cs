using Dttl.Qr.Data;
using Dttl.Qr.Model;
using Dttl.Qr.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Dttl.Qr.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : BaseController
    {
        private readonly ISearchService _searchService;
        public SearchController(ISearchService searchService, ILogger<SearchController> logger) : base(logger)
        {
            _searchService = searchService;
        }

        [HttpGet("GetSearchByFilter")]
        public async Task<IActionResult> GetSearchByFilter([FromBody] SearchFilter searchFilter)
        {
            var result = await _searchService.GetSearchByFilter(searchFilter);
            return Ok(result);
        }
    }
}