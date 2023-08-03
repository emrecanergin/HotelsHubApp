using Core.DataAccess.Context;
using HotelsHubApp.DataAccess.Abstract;
using HotelsHubApp.Entities.EFCoreEntities;

namespace HotelsHubApp.DataAccess.Concrete.EntityFramework
{
    public class ReservationRepository : EfCoreBaseRepository<Reservation> , IReservationRepository
    {
        public HotelbedsDBContext _context { get; set; }

        public ReservationRepository(HotelbedsDBContext context) : base(context)
        {

        }
        
    }
}
