namespace HotelContents.Models
{
    public class Room
    {
        public string roomCode { get; set; }
        public bool isParentRoom { get; set; }
        public int minPax { get; set; }
        public int maxPax { get; set; }
        public int maxAdults { get; set; }
        public int maxChildren { get; set; }
        public int minAdults { get; set; }
        public string roomType { get; set; }
        public string characteristicCode { get; set; }
        public List<RoomFacility> roomFacilities { get; set; }
        public List<RoomStay> roomStays { get; set; }
        public string PMSRoomCode { get; set; }
    }
}
