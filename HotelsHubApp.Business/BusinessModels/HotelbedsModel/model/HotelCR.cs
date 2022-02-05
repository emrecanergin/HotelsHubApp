namespace HotelsHubApp.Business.BusinessModels.HotelbedsModel.model
{
    public class HotelCR
    {
        public DateTime checkOut { get; set; }
        public DateTime checkIn { get; set; }
        public int code { get; set; }
        public string name { get; set; }
        public string categoryCode { get; set; }
        public string categoryName { get; set; }
        public string destinationCode { get; set; }
        public string destinationName { get; set; }
        public int zoneCode { get; set; }
        public string zoneName { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public IList<Room> rooms { get; set; }
        public decimal totalNet { get; set; }
        public string currency { get; set; }
        public bool paymentDataRequired { get; set; }
    }
}
