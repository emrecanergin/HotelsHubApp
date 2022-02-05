using HotelsHubApp.Business.BusinessModels.HotelbedsModel.model;

namespace HotelsHubApp.Business.BusinessModels.HotelbedsModel.messages
{
    public class CheckRateRS
    {
        public List<string> providerDetails { get; set; }
        public AuditData auditData { get; set; }
        public HotelCR hotel { get; set; }
        public Source source { get; set; }
    }
}
