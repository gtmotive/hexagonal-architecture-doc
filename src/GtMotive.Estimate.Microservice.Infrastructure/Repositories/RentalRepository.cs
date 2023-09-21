using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Infrastructure.MongoDb;
using MongoDB.Driver;

namespace GtMotive.Estimate.Microservice.Infrastructure.Repositories
{
    public class RentalRepository : IRentalRepository
    {
        private readonly IMongoCollection<Rental> _rentalCollection;

        public RentalRepository(MongoService mongoService)
        {
            if (mongoService == null)
            {
                throw new ArgumentNullException(nameof(mongoService));
            }

            _rentalCollection = mongoService.Rentals;
        }

        public async Task<Rental> AddRental(Rental rental)
        {
            if (rental == null)
            {
                throw new ArgumentNullException(nameof(rental));
            }

            await _rentalCollection.InsertOneAsync(rental);
            return rental;
        }

        public async Task CompleteRental(Guid rentalId)
        {
            var filter = Builders<Rental>.Filter.Eq(r => r.Id, rentalId);
            await _rentalCollection.DeleteOneAsync(filter);
        }

        public async Task<Rental> GetRentalById(Guid rentalId)
        {
            if (rentalId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(rentalId));
            }

            return await _rentalCollection.Find(r => r.Id == rentalId).FirstOrDefaultAsync();
        }

        public async Task<bool> HasActiveRental(string clientId)
        {
            if (clientId == null)
            {
                throw new ArgumentNullException(nameof(clientId));
            }

            var rental = await _rentalCollection.Find(r => r.ClientIdCard == clientId).FirstOrDefaultAsync();
            return rental != null;
        }
    }
}
