using HotelsHubApp.Business.BusinessModels.MainModel.bookingModel;

namespace HotelsHubApp.Business.BusinessModels.MainModel.model
{
    public class RequestRoom
    {
        public int RoomIndex { get; set; }
        public IList<Pax>? Paxes { get; set; }
    }
}
