namespace HotelsHubApp.Business.BusinessModels.MainModel.model
{
    public class RoomGroup
    {
        public IList<ResponseRoom> Rooms { get; set; }
        public IList<Policy> Policies { get; set; }
        public RateKey RateKey { get; set; }
    }
}
