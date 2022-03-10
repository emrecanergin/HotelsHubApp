using System.ComponentModel.DataAnnotations;

namespace HotelsHubApp.Entities.EFCoreEntities
{
    public class Users : BaseEntity, IEntity
    {
        public int AgentId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public int PhoneNumber { get; set; }
        public bool IsActive { get; set; }
    }
}
