using GtMotive.Estimate.Microservice.Domain.Aggregates.CustomerAggregate;
using GtMotive.Estimate.Microservice.Domain.Aggregates.VehicleAggregate;
using MongoDB.Driver;

namespace GtMotive.Estimate.Microservice.Infrastructure.MongoDb
{
    public partial class AppDbContext
    {
        public IMongoCollection<Customer> Customers =>
            MongoDatabase.GetCollection<Customer>("Customers");

        public IMongoCollection<Vehicle> Vehicles =>
            MongoDatabase.GetCollection<Vehicle>("Vehicles");
    }
}
