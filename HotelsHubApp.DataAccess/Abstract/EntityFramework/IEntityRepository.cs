using HotelsHubApp.Entities;
using System.Linq.Expressions;

namespace HotelsHubApp.DataAccess.Abstract
{
    public interface IEntityRepository<T> where T : class, IEntity
    {
        ValueTask<T> GetByIdAsync(int id);
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);

        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task RemoveAsync(T entity);

        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetWhereAsync(Expression<Func<T, bool>> predicate);

        Task<int> CountAllAsync();
        Task<int> CountWhereAsync(Expression<Func<T, bool>> predicate);
    }
}
