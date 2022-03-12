namespace HotelContents.Models
{
    public class Hotel
    {
        public int code { get; set; }
        public Name name { get; set; }
        public Description description { get; set; }
        public string countryCode { get; set; }
        public string stateCode { get; set; }
        public string destinationCode { get; set; }
        public int zoneCode { get; set; }
        public Coordinates coordinates { get; set; }
        public string categoryCode { get; set; }
        public string categoryGroupCode { get; set; }
        public string chainCode { get; set; }
        public string accommodationTypeCode { get; set; }
        public List<string> boardCodes { get; set; }
        public List<int> segmentCodes { get; set; }
        public Address address { get; set; }
        public string postalCode { get; set; }
        public City city { get; set; }
        public string email { get; set; }
        public List<Phone> phones { get; set; }
        public List<Room> rooms { get; set; }
        public List<Facility> facilities { get; set; }
        public List<Terminal> terminals { get; set; }
        public List<Issue> issues { get; set; }
        public List<InterestPoint> interestPoints { get; set; }
        public List<Image> images { get; set; }
        public List<Wildcard> wildcards { get; set; }
        public string web { get; set; }
        public string lastUpdate { get; set; }
        public string S2C { get; set; }
        public int ranking { get; set; }
    }
}
