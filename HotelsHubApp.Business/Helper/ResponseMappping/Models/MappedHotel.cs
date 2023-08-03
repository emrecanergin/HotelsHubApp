namespace HotelsHubApp.Business.Helper.ResponseMappping.Models
{
    public class MappedHotel
    {
        public HotelFeatures hotelFeatures { get; set; }
        public List<List<Room>> roomGroups { get; set; } = new();
    }
}
