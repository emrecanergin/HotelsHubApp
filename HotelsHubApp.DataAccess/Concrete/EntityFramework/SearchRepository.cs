using Core.DataAccess.Context;
using HotelsHubApp.DataAccess.Abstract;
using HotelsHubApp.Entities.EFCoreEntities;

namespace HotelsHubApp.DataAccess.Concrete.EntityFramework
{
    public class SearchRepository : EfCoreBaseRepository<Search> , ISearchRepository
    {
        public HotelbedsDBContext _context { get; set; }

        public SearchRepository(HotelbedsDBContext context) : base(context)
        {

        }
       
        
    }
}
