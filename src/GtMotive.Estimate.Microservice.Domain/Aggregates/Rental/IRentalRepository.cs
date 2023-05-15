using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Interfaces;

namespace GtMotive.Estimate.Microservice.Domain.Aggregates.Rental
{
    /// <summary>
    /// Interface for Fleet Repository.
    /// </summary>
    public interface IRentalRepository : IRepository<Rental>
    {
        Task<bool> AnyCustomerIdAsync(int customerId);
    }
}
