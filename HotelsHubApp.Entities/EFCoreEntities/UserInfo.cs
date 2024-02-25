namespace HotelsHubApp.Entities.EFCoreEntities
{
    public class UserInfo : BaseEntity, IEntity
    {
        public string Username { get; set; }
        public string IpAddress { get; set; }
    }
}
