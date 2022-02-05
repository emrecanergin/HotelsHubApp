using HotelsHubApp.Business.BusinessModels.HotelbedsModel.model;

namespace HotelsHubApp.Business.BusinessModels.HotelbedsModel.messages
{
    public abstract class AbstractGenericResponse
    {
        public string echoToken { get; set; }
        public AuditData auditData { get; set; }
        public HotelbedsError error { get; set; }

    }
}
