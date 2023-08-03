using HotelsHubApp.Business.BusinessModels.HotelbedsModel.model;


namespace HotelsHubApp.Business.BusinessModels.HotelbedsModel.messages
{
    public class AvailabilityRS : AbstractGenericResponse
    {
        public List<string> providerDetails { get; set; }
        //public Hotels hotels; if you write like this , serialization gonna be wrong
        public Hotels hotels { get; set; }
        public Source source { get; set; }
    }
}
