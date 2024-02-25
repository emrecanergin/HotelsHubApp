using HotelsHubApp.Business.Abstract.Hotelbeds.Services;
using HotelsHubApp.Business.BusinessModels.MainModel.messages;
using Microsoft.AspNetCore.Mvc;

namespace HotelsHubApp.WebAPI.Controllers
{
    [Route("hotel-api")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ISearchService _searchService;
        public SearchController(ISearchService searchService)
        {
            _searchService = searchService;           
        }

        [Route("hotels")]
        [HttpPost]
        public async Task<IActionResult> Search(SearchRequest searchRequest)
        {
            var response = await _searchService.HotelsResponse(searchRequest);

            if (response.Data.Hotels == null)
            {
                return NoContent();
            }
            return Ok(new ApiResponse<SearchResponse>(response.Data) { StatusCode = Response.StatusCode });
        }
    }
}
