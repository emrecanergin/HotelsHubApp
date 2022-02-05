namespace HotelsHubApp.Entities.EFCoreEntities
{
    public class Remarks : IEntity
    {
        public int Id { get; set; }
        public string Remark { get; set; }
        public virtual Reservation Reservation { get; set; }
    }
}
