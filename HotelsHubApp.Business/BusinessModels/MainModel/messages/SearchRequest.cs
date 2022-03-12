using HotelsHubApp.Business.BusinessModels.MainModel.model;



namespace HotelsHubApp.Business.BusinessModels.MainModel.messages
{
    public class SearchRequest
    {
        public Authentication Authentication { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public string? Language { get; set; }
        public string? Nationality { get; set; }
        public MultiRoomGroup? MultiRoomGroup { get; set; }
        public Filter? Filter { get; set; }
        public Setting? Settings { get; set; }
        public Info? Info { get; set; }
    }
}
