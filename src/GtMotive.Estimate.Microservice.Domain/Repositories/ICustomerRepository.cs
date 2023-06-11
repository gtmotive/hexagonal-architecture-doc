using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Aggregates.CustomerAggregate;

namespace GtMotive.Estimate.Microservice.Domain.Repositories
{
    /// <summary>
    /// Customer repository.
    /// </summary>
    public interface ICustomerRepository
    {
        /// <summary>
        /// Get customer by id.
        /// </summary>
        /// <param name="id">Customer identifier.</param>
        /// <returns>Customer.</returns>
        Task<Customer> GetAsync(Guid id);

        /// <summary>
        /// Save customer.
        /// </summary>
        /// <param name="customer">Customer to save.</param>
        /// <returns>Task.</returns>
        Task SaveAsync(Customer customer);

        /// <summary>
        /// Delete all customers.
        /// </summary>
        /// <returns>Task.</returns>
        Task DeleteAll();
    }
}
