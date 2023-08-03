using System;

namespace HotelsHubApp.Entities.EFCoreEntities
{
    public class Search : BaseEntity, IEntity
    {
        public int TotalHotel { get; set; }
        public int TotalRoom { get; set; }
        public DateTime RequestTime { get; set; }
        public DateTime ResponseTime { get; set; }
        public string DestinationCode { get; set; }
        public string Nationality { get; set; }
        public string Language { get; set; }
        public int AgentId { get; set; }
        public virtual UserInfo UserInfo { get; set; }
        public virtual Users User { get; set; }
    }
}
