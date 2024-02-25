using HotelsHubApp.Business.BusinessModels.HotelbedsModel.common;
using HotelsHubApp.Business.BusinessModels.HotelbedsModel.messages;
using HotelsHubApp.Business.BusinessModels.HotelbedsModel.model;
using HotelsHubApp.Business.BusinessModels.MainModel.messages;

namespace HotelsHubApp.Business.Concrete.Hotelbeds.Requests.RequestGenerators
{
    public class AvailabilityRequestBodyGenerator : IAvailabilityRequestBodyGenerator
    {
        public AvailabilityRQ CreateHotelbedsRequestBody(SearchRequest request)
        {
            List<Occupancy> occupancies = new List<Occupancy>();
            List<Pax> paxlist = new();

            foreach (var room in request.Settings.Rooms)
            {
                foreach (var pax in room.Paxes)
                {
                    paxlist.Add(new Pax
                    {
                        age = pax.PaxAge,
                        type = (pax.PaxAge <= 18) ? SimpleTypes.HotelbedsCustomerType.CH : SimpleTypes.HotelbedsCustomerType.AD
                    });
                }

                int childrenCount = paxlist.Count(x => x.age < 18);
                int adultCount = paxlist.Count(x => x.age > 18);

                occupancies.Add(
                    new Occupancy
                    {
                        rooms = room.RoomIndex,
                        adults = adultCount,
                        children = childrenCount,
                        paxes = paxlist
                    });
                paxlist.Clear();
            }

            var destinationCode = request.Settings.DestinationCode;
            var stay = new Stay { checkIn = request.CheckIn, checkOut = request.CheckOut };
            var codes = new HotelsFilter { hotel = request.Settings.HotelCodes };
            var total = new AvailabilityRQ
            {
                stay = stay,
                occupancies = occupancies,
                hotels = (request.Settings.HotelCodes != null) ? codes : null,
                destination = (destinationCode != null) ? new Destination { code = destinationCode.Code } : null,
            };
            return total;
        }
    }
}
