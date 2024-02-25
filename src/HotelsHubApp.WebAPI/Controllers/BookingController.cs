using HotelsHubApp.Business.Abstract.Hotelbeds.Services;
using HotelsHubApp.Business.BusinessModels.MainModel.messages;
using Microsoft.AspNetCore.Mvc;

namespace HotelsHubApp.WebAPI.Controllers
{
    [Route("hotel-api")]
    [ApiController]
    public class BookingController : ControllerBase
    {    
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {          
            _bookingService = bookingService;
        }

        [Route("bookings")]
        [HttpPost]
        public async Task<IActionResult> Book(BookingRequest request)
        {
            var response = await _bookingService.Book(request);

            return Ok(new ApiResponse<BookingResponse>(response.Data));
        }

        [Route("bookings")]
        [HttpGet]
        public async Task<IActionResult> BookList(BookingRequest request)
        {
           throw new NotImplementedException();
        }

        [Route("bookings/{bookingId}")]
        [HttpGet]
        public async Task<IActionResult> BookDetail(int id)
        {
            throw new NotImplementedException();
        }

        [Route("bookings/{bookingId}")]
        [HttpPut]
        public async Task<IActionResult> BookChange(int id)
        {
            throw new NotImplementedException();
        }
    }
}
