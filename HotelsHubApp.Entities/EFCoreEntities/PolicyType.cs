using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HotelsHubApp.Entities.EFCoreEntities
{
    public class PolicyType : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Type { get; set; }
    }
}
