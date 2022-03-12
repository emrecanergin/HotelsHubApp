using HotelsHubApp.Business.BusinessModels.MainModel.model;

namespace HotelsHubApp.Business.BusinessModels.MainModel.messages
{
    public class SearchResponse
    {
       
        public int SearchId { get; set; }
        public IList<Hotel> Hotels { get; set; }
        public double SupplierCommunicationTime { get; set; }
    }
}
