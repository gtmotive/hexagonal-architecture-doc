using GtMotive.Estimate.Microservice.Domain.Aggregates.CustomerAggregate;
using GtMotive.Estimate.Microservice.Domain.Aggregates.VehicleAggregate;
using MongoDB.Driver;

namespace GtMotive.Estimate.Microservice.Infrastructure.MongoDb
{
    public interface IAppDbContext
    {
        MongoClient MongoClient { get; }

        IMongoDatabase MongoDatabase { get; }

        IMongoCollection<Customer> Customers { get; }

        IMongoCollection<Vehicle> Vehicles { get; }
    }
}
