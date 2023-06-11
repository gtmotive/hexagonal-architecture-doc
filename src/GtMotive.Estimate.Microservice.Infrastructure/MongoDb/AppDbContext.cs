using GtMotive.Estimate.Microservice.Infrastructure.MongoDb.EntityConfigurations;
using GtMotive.Estimate.Microservice.Infrastructure.MongoDb.Serializers;
using GtMotive.Estimate.Microservice.Infrastructure.MongoDb.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace GtMotive.Estimate.Microservice.Infrastructure.MongoDb
{
    public partial class AppDbContext : IAppDbContext
    {
        // TODOFAKE: La inicialización habría que cambiarla para que fuera diferidad...
        public AppDbContext(IOptions<MongoDbSettings> options)
        {
            MongoClient = new MongoClient(options.Value.ConnectionString);
            MongoDatabase = MongoClient.GetDatabase(options.Value.DatabaseName);

            RegisterSerializers();

            Configure();
        }

        public MongoClient MongoClient { get; }

        public IMongoDatabase MongoDatabase { get; }

        private static void RegisterSerializers()
        {
            BsonSerializer.RegisterSerializer(new DateOnlySerializer());
        }

        private void Configure()
        {
            new CustomerEntityConfiguration(this).Configure();
        }
    }
}
