using HotelsHubApp.Business.Abstract;
using HotelsHubApp.Business.BusinessModels.MainModel.messages;
using HotelsHubApp.WebAPI;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly ISearchService _searchService;

        public MainController(ISearchService searchService)
        {
            _searchService = searchService;

        }

        [HttpPost]
        public async Task<IActionResult> Search(SearchRequest searchRequest)
        {
            var response = await _searchService.HotelsResponse(searchRequest);
            if (response.Success)
            {
                return Ok(new ApiResponse<SearchResponse>(response.Data));
            }

            return BadRequest(new ApiResponse<object> { ErrorMessage = response.Message });
        }

    }
}
