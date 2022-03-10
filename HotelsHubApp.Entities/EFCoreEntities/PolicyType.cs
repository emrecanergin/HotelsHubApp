

namespace HotelsHubApp.Entities.EFCoreEntities
{
    public class PolicyType : BaseEntity, IEntity
    {
        public int Id { get; set; }
        public string Type { get; set; }
    }
}
