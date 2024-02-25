namespace HotelsHubApp.Entities.EFCoreEntities
{
    public class Remarks : BaseEntity, IEntity
    {
        public string Remark { get; set; }
        public virtual Reservation Reservation { get; set; }
    }
}
