
namespace HotelsHubApp.Entities.EFCoreEntities
{
    public class TaxesAndFees : IEntity
    {
        public int Id { get; set; }
        public bool IncludedPrice { get; set; }
        public int Description { get; set; }
        public bool Mandatory { get; set; }
        public int Currency { get; set; }
        public decimal Amount { get; set; }
        public bool Bar { get; set; }
        public double ComissionPrice { get; set; }

        public virtual Reservation Reservation { get; set; }
    }
}
