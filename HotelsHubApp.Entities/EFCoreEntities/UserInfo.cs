using System.ComponentModel.DataAnnotations;

namespace HotelsHubApp.Entities.EFCoreEntities


{
    public class UserInfo : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public string IpAddress { get; set; }
    }
}
