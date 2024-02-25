using System;

namespace HotelsHubApp.Entities.EFCoreEntities
{
    public class Policies : BaseEntity, IEntity
    {
        public decimal Price { get; set; }
        public int Currency { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndtDate { get; set; }
        public byte PolicyType { get; set; }
        public double MinimumSellingPrice { get; set; }

        public int ReservationId { get; set; }
        public virtual Reservation Reservation { get; set; }
    }
}
