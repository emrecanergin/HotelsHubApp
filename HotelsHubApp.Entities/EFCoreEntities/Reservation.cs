using System.ComponentModel.DataAnnotations;

namespace HotelsHubApp.Entities.EFCoreEntities
{
    public class Reservation : BaseEntity, IEntity
    {
        public Reservation()
        {
            Policies = new List<Policies>();
            TaxesAndFees = new List<TaxesAndFees>();
        }
        public DateTime CheckIn { get; set; }   
        public DateTime CheckOut { get; set; }       
        public int HotelCode { get; set; }       
        public string RoomCode { get; set; }       
        public string RoomName { get; set; } 
        public decimal Price { get; set; }
        public string SearchId { get; set; }
        public virtual ICollection<Policies> Policies { get; set; }
        public virtual ICollection<Remarks> Remarks { get; set; }
        public virtual ICollection<TaxesAndFees> TaxesAndFees { get; set; }
        public int AgentId { get; set; }
        public virtual Users User { get; set; }
    }
}
