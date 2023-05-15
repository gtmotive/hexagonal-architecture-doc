using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Aggregates.Fleet;
using GtMotive.Estimate.Microservice.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace GtMotive.Estimate.Microservice.Infrastructure.Repositories
{
    /// <summary>
    /// Fleet Repository.
    /// </summary>
    public class FleetRepository : EfRepository<Fleet>, IFleetRepository
    {
        public FleetRepository(GtMotiveFleetContext dbContext)
            : base(dbContext)
        {
        }

        public async Task<Vehicle> GetVehicleAsync(int idVehicle)
        {
            var vehicle = await _gtMotiveFleetContext.Vehicles.FindAsync(idVehicle);
            return vehicle;
        }

        public async Task<IEnumerable<Vehicle>>  GetAvailableVehiclesAsync(int idFleet)
        {
            var fleet = await GetByIdAsync(idFleet);
           
            if (fleet != null)
            {
                await _gtMotiveFleetContext
                     .Entry(fleet)
                     .Collection(i => i.Vehicles)
                     .Query()
                     .Where(item => item.IsAvailable)
                     .LoadAsync();
            }

            return fleet.Vehicles;
        }
    }
}
