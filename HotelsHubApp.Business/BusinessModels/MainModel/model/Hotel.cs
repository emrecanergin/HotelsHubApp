namespace HotelsHubApp.Business.BusinessModels.MainModel.model
{
    public class Hotel
    {
        public int? Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string CityId { get; set; }
        public string CityName { get; set; }
        public string CountryId { get; set; }
        public string CountryName { get; set; }
        public string Category { get; set; }
        public IList<string> Themes { get; set; }
        public IList<string> Facilities { get; set; }
        public GeoLocation Geolocation { get; set; }
        public IList<RoomGroup> RoomGroups { get; set; }
        
    }
}
