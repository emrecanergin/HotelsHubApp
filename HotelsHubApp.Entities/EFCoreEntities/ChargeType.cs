using System.ComponentModel.DataAnnotations;

namespace HotelsHubApp.Entities.EFCoreEntities
{
    public class ChargeType : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Type { get; set; }
    }
}
