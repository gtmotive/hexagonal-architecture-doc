using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Aggregates.Fleet;
using GtMotive.Estimate.Microservice.Domain.Aggregates.Rental;
using GtMotive.Estimate.Microservice.Infrastructure.Contexts;

namespace GtMotive.Estimate.Microservice.Infrastructure.Repositories
{

    /// <summary>
    /// Rental Repository.
    /// </summary>
    public class RentalRepository : EfRepository<Rental>, IRentalRepository
    {
        public RentalRepository(GtMotiveFleetContext dbContext)
            : base(dbContext)
        {
        }

        public async Task<bool> AnyCustomerIdAsync(int customerId)
        {
            return await AnyAsync(item => item.CustomerId == customerId);
        }
    }
}
