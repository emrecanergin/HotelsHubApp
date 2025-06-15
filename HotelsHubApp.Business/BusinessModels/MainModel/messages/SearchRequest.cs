using HotelsHubApp.Business.BusinessModels.MainModel.model;



namespace HotelsHubApp.Business.BusinessModels.MainModel.messages
{
    public class SearchRequest
    {
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public Setting? Settings { get; set; }
        public Info? Info { get; set; }
    }
}
