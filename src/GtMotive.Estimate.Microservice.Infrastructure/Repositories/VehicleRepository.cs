using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Infrastructure.MongoDb;
using MongoDB.Driver;

namespace GtMotive.Estimate.Microservice.Infrastructure.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly IMongoCollection<Vehicle> _vehicleCollection;

        public VehicleRepository(MongoService mongoService)
        {
            if (mongoService == null)
            {
                throw new ArgumentNullException(nameof(mongoService));
            }

            _vehicleCollection = mongoService.Vehicles;
        }

        public async Task<Vehicle> AddVehicle(Vehicle vehicle)
        {
            await _vehicleCollection.InsertOneAsync(vehicle);
            return vehicle;
        }

        public async Task<List<Vehicle>> GetAllAvailableVehicles(Guid fleetId)
        {
            var fiveYearsAgo = DateTime.UtcNow.AddYears(-5);
            var filter = Builders<Vehicle>.Filter.And(
                Builders<Vehicle>.Filter.Eq(v => v.IsRental, false),
                Builders<Vehicle>.Filter.Eq(v => v.Fleet, fleetId),
                Builders<Vehicle>.Filter.Gte(v => v.ManufacturingDate, fiveYearsAgo));

            return await _vehicleCollection.Find(filter).ToListAsync();
        }

        public async Task<Vehicle> GetVehicleById(Guid vehicleId)
        {
            return await _vehicleCollection.Find(vehicle => vehicle.Id == vehicleId).FirstOrDefaultAsync();
        }

        public async Task ModifyVehicleRental(Guid vehicleId, bool isRental)
        {
            var filter = Builders<Vehicle>.Filter.Eq(v => v.Id, vehicleId);
            var update = Builders<Vehicle>.Update.Set(v => v.IsRental, isRental);

            await _vehicleCollection.UpdateOneAsync(filter, update);
        }
    }
}
