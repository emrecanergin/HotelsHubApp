using HotelsHubApp.Business.BusinessModels.MainModel.bookingModel;

namespace HotelsHubApp.Business.BusinessModels.MainModel.model
{
    public class BookingRequestRoom
    {
        public int RoomIndex { get; set; }
        public string RoomCode { get; set; }
        public string RoomName { get; set; }
        public string SystemRoomCode { get; set; }
        public string SystemBoardCode { get; set; }
        public List<Pax> Paxes { get; set; }
    }
   
}
