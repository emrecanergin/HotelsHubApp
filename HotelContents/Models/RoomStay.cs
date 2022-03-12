namespace HotelContents.Models
{
    public class RoomStay
    {
        public string stayType { get; set; }
        public string order { get; set; }
        public string description { get; set; }
        public List<RoomStayFacility> roomStayFacilities { get; set; }
    }
}
