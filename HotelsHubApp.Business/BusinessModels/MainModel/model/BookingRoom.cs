using HotelsHubApp.Business.BusinessModels.MainModel.bookingModel;

namespace HotelsHubApp.Business.BusinessModels.MainModel.model
{
    public class BookingRoom
    {
        public int RoomIndex { get; set; }
        public string RateKey { get; set; }
        public string RoomCode { get; set; }
        public string RoomName { get; set; }
        public IList<Pax> Paxes { get; set; }
    }
}
