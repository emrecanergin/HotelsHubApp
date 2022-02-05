using System.ComponentModel.DataAnnotations;

namespace HotelsHubApp.Entities.EFCoreEntities
{
    public class Currencies : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Currency { get; set; }
    }
}
