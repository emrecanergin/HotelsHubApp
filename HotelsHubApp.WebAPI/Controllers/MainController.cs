using HotelsHubApp.Business.Abstract.Hotelbeds.Services;
using HotelsHubApp.Business.BusinessModels.MainModel.messages;
using HotelsHubApp.WebAPI;
using Microsoft.AspNetCore.Mvc;
using Serilog;

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
            if (response.Success)
            {
                return Ok(new ApiResponse<SearchResponse>(response.Data));
            }

            return BadRequest(new ApiResponse<object> { ErrorMessage = response.Message });
        }
        
        [HttpPost]
        public async Task<IActionResult> CheckRate(CheckRequest request)
        {
            var response = await _checkRateService.CheckRateResponse(request);
            if (response.Success)
            {
                return Ok(new ApiResponse<CheckResponse>(response.Data));
            }
            return Ok(response);
            //return BadRequest(new ApiResponse<object> { ErrorMessage = response.Message });
        }

        [HttpPost]
        public async Task<IActionResult> Book(BookingRequest request)
        {
            var response = await _bookingService.Book(request);
            if (response.Success)
            {
                return Ok(new ApiResponse<BookingResponse>(response.Data));
            }
            return Ok(response);
            

        }

    }
}
