namespace HotelsHubApp.Business.BusinessModels.HotelbedsModel.model
{
    public class Hotels
    {
        public IList<Hotel> hotels { get; set; }
        public string checkIn { get; set; }
        public string checkOut { get; set; }
        public int total { get; set; }
    }
}
