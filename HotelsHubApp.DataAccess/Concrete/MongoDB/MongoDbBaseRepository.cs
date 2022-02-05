using HotelsHubApp.DataAccess.Abstract.MongoDB;
using HotelsHubApp.DataAccess.Concrete.MongoDB;
using HotelsHubApp.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace Core.DataAccess.MongoDB
{
    public class MongoDbBaseRepository<TEntity> : IMongoDbRepository<TEntity>
       where TEntity : MongoDbEntity, IEntity, new()
    {
        protected readonly IMongoCollection<TEntity> Collection;

        public MongoDbBaseRepository(IConfiguration configuration)
        {
            var client = new MongoClient(configuration["MongoDbSettings:ConnectionString"]);
            var db = client.GetDatabase(configuration["MongoDbSettings:Database"]);
            Collection = db.GetCollection<TEntity>(typeof(TEntity).Name.ToLowerInvariant());
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await Collection.InsertOneAsync(entity);
            return entity;
        }

        public async Task<bool> AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await Collection.InsertManyAsync(entities);
            return true;
        }

        public async Task<TEntity> DeleteAsync(TEntity entity)
        {
            return await Collection.FindOneAndDeleteAsync(x => x.Id == entity.Id);
        }

        public async Task DeleteAsync(string id)
        {
            await Collection.DeleteOneAsync(id);
        }

        public async Task<TEntity> DeleteAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Collection.FindOneAndDeleteAsync(predicate);
        }

        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate = null)
        {
            return predicate == null
                            ? Collection.AsQueryable()
                            : Collection.AsQueryable().Where(predicate);
        }

        public Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return Collection.Find(predicate).FirstOrDefaultAsync();
        }

        public async Task<TEntity> GetByIdAsync(string id)
        {
            return await Collection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<TEntity> UpdateAsync(string id, TEntity entity)
        {
            return await Collection.FindOneAndReplaceAsync(x => x.Id == id, entity);
        }

        public async Task<TEntity> UpdateAsync(TEntity entity, Expression<Func<TEntity, bool>> predicate)
        {
            return await Collection.FindOneAndReplaceAsync(predicate, entity);
        }

    }
}
