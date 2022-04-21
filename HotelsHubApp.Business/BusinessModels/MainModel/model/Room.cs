using HotelsHubApp.Business.BusinessModels.MainModel.bookingModel;

namespace HotelsHubApp.Business.BusinessModels.MainModel.model
{
    public class Room
    {
        public int RoomIndex { get; set; }
        public IList<Pax>? Paxes { get; set; }
    }
}
