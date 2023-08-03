using AutoMapper;
using HotelsHubApp.Business.Abstract.Hotelbeds.Requests;
using HotelsHubApp.Business.BusinessModels.HotelbedsModel.messages;
using HotelsHubApp.Business.BusinessModels.MainModel.messages;
using HotelsHubApp.Business.HttpClients.HotelbedsClient;
using HotelsHubApp.Business.HttpRequests.Hotelbeds;

namespace HotelsHubApp.Business.Concrete.Hotelbeds.Requests
{
    public class HotelbedsBookingRequest : IBookingRequest
    {
        private readonly IHotelApiConsumer _hotelApiConsumer;
        private readonly IMapper _mapper;
        public HotelbedsBookingRequest(IHotelApiConsumer hotelApiConsumer, IMapper mapper)
        {
            _hotelApiConsumer = hotelApiConsumer;   
            _mapper = mapper;   
        }

        public async Task<BookingRS> Book(BookingRequest bookingRequest)
        {
            var request = new BookingRQ();
            _mapper.Map(bookingRequest.creditCard,request.paymentData.paymentCard);
            _mapper.Map(bookingRequest.rooms, request.rooms);
            request.clientReference = bookingRequest.clientReference;   
            request.remark = bookingRequest.remark; 
     
            var response = await _hotelApiConsumer.Book(request);    
            
            return response;
        }
    }
}
