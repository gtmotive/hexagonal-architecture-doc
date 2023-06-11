using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Aggregates.VehicleAggregate;
using GtMotive.Estimate.Microservice.Domain.Repositories;
using GtMotive.Estimate.Microservice.Infrastructure.MongoDb;
using MongoDB.Driver;

namespace GtMotive.Estimate.Microservice.Infrastructure.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly IMongoCollection<Vehicle> _vehicles;

        public VehicleRepository(IAppDbContext appDbContext)
        {
#pragma warning disable CA1062
            _vehicles = appDbContext.Vehicles;
#pragma warning restore CA1062
        }

        public async Task<Vehicle> GetAsync(Guid id)
        {
            var results = await _vehicles
                .FindAsync(x => x.Id == id);

            var vehicle = await results.FirstOrDefaultAsync();

            return vehicle;
        }

        public async Task SaveAsync(Vehicle vehicle)
        {
            await _vehicles.ReplaceOneAsync(x => x.Id == vehicle.Id, vehicle, new ReplaceOptions { IsUpsert = true });
        }

        public async Task<List<Vehicle>> GetAllAvailableVehicles()
        {
            var results = await _vehicles
                .FindAsync(x => x.IsAvailable);

            var vehicles = await results.ToListAsync();

            return vehicles;
        }

        public Task DeleteAll()
        {
            return _vehicles
                .DeleteManyAsync(FilterDefinition<Vehicle>.Empty);
        }
    }
}
