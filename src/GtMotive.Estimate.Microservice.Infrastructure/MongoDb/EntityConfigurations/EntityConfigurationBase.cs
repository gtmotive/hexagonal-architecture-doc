using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace GtMotive.Estimate.Microservice.Infrastructure.MongoDb.EntityConfigurations
{
    public abstract class EntityConfigurationBase<TEntity>
        where TEntity : class
    {
        protected EntityConfigurationBase(IAppDbContext appDbContext)
        {
            AppDbContext = appDbContext;
        }

        protected IAppDbContext AppDbContext { get; }

        public void Configure()
        {
            CreateIndexes(Builders<TEntity>.IndexKeys);
            BsonClassMap.RegisterClassMap<TEntity>(RegisterClassMap);
        }

        protected virtual void RegisterClassMap(BsonClassMap<TEntity> classMap)
        {
        }

        protected virtual void CreateIndexes(IndexKeysDefinitionBuilder<TEntity> builder)
        {
        }
    }
}
