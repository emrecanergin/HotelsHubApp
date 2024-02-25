using HotelsHubApp.DataAccess.Concrete.MongoDB;
using System.Linq.Expressions;


namespace HotelsHubApp.DataAccess.Abstract.MongoDB
{
    public interface IMongoDbRepository<TEntity> where TEntity : MongoDbEntity
    {
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> GetByIdAsync(string id);
        Task<TEntity> AddAsync(TEntity entity);
        Task<bool> AddRangeAsync(IEnumerable<TEntity> entities);
        Task<TEntity> UpdateAsync(string id, TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity, Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> DeleteAsync(TEntity entity);
        Task<TEntity> DeleteAsync(Expression<Func<TEntity, bool>> predicate);
    }
}
