namespace HotelsHubApp.Entities.EFCoreEntities
{
    public class TaxesAndFees : BaseEntity, IEntity
    {
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
