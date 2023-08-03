using HotelsHubApp.Business.Abstract.Hotelbeds.Services;
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
        private readonly ICheckRateService _checkRateService;
        private readonly IBookingService _bookingService;



        public MainController(ISearchService searchService,
                              ICheckRateService checkRateService,
                              IBookingService bookingService)                                  
        {
            _searchService = searchService;
            _checkRateService = checkRateService;
            _bookingService = bookingService;
        }

        [HttpPost]
        public async Task<IActionResult> Search(SearchRequest searchRequest)
        {
            var response = await _searchService.HotelsResponse(searchRequest);
            
            if (response.Data.Hotels == null)
            {
                return NoContent();
            }
            
            return Ok(new ApiResponse<SearchResponse>(response.Data){ StatusCode= Response.StatusCode});
        }

        [HttpPost]
        public async Task<IActionResult> CheckRate(CheckRequest request)
        {
            var response = await _checkRateService.CheckRateResponse(request);          

            return Ok(new ApiResponse<CheckResponse>(response.Data));
        }

        [HttpPost]
        public async Task<IActionResult> Book(BookingRequest request)
        {
            var response = await _bookingService.Book(request);

            return Ok(new ApiResponse<BookingResponse>(response.Data));
        }
    }
}
