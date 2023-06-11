using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Aggregates.CustomerAggregate;
using GtMotive.Estimate.Microservice.Domain.Repositories;
using GtMotive.Estimate.Microservice.Infrastructure.MongoDb;
using MongoDB.Driver;

namespace GtMotive.Estimate.Microservice.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IMongoCollection<Customer> _customers;

        public CustomerRepository(IAppDbContext appDbContext)
        {
#pragma warning disable CA1062
            _customers = appDbContext.Customers;
#pragma warning restore CA1062
        }

        public async Task<Customer> GetAsync(Guid id)
        {
            var results = await _customers
                .FindAsync(x => x.Id == id);

            var customer = await results.FirstOrDefaultAsync();

            return customer;
        }

        public async Task SaveAsync(Customer customer)
        {
            await _customers.ReplaceOneAsync(x => x.Id == customer.Id, customer, new ReplaceOptions { IsUpsert = true });
        }

        public Task DeleteAll()
        {
            return _customers
                .DeleteManyAsync(FilterDefinition<Customer>.Empty);
        }
    }
}
