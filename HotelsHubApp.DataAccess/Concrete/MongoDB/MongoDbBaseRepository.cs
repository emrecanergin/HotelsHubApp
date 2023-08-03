using HotelsHubApp.DataAccess.Abstract.MongoDB;
using HotelsHubApp.DataAccess.Concrete.MongoDB;
using HotelsHubApp.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace Core.DataAccess.MongoDB
{
    public class MongoDbBaseRepository<TEntity> : IMongoDbRepository<TEntity>
       where TEntity : MongoDbEntity, IEntity, new()
    {

        protected readonly IMongoCollection<TEntity> _collection;
       
        private readonly MongoDbSettings _settings;

        protected MongoDbBaseRepository(IOptions<MongoDbSettings> options)
        {
            _settings = options.Value;
            var client = new MongoClient(_settings.ConnectionString);
            var db = client.GetDatabase(_settings.Database);
            _collection = db.GetCollection<TEntity>(typeof(TEntity).Name.ToLowerInvariant());
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _collection.InsertOneAsync(entity);
            return entity;
        }

        public async Task<bool> AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _collection.InsertManyAsync(entities);
            return true;
        }

        public async Task<TEntity> DeleteAsync(TEntity entity)
        {
            return await _collection.FindOneAndDeleteAsync(x => x.Id == entity.Id);
        }

        public async Task<TEntity> DeleteAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _collection.FindOneAndDeleteAsync(predicate);
        }

        public Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return _collection.Find(predicate).FirstOrDefaultAsync();
        }

        public async Task<TEntity> GetByIdAsync(string id)
        {
            return await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<TEntity> UpdateAsync(string id, TEntity entity)
        {
            return await _collection.FindOneAndReplaceAsync(x => x.Id == id, entity);
        }

        public async Task<TEntity> UpdateAsync(TEntity entity, Expression<Func<TEntity, bool>> predicate)
        {
            return await _collection.FindOneAndReplaceAsync(predicate, entity);
        }

    }
}
