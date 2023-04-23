using System.Collections.Generic;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Entities;

namespace GtMotive.Estimate.Microservice.ApplicationCore.Contracts.Repositories
{
    /// <summary>
    /// IVehicleRepository.
    /// </summary>
    public interface IVehicleRepository : IAsyncRepository<Vehicle>
    {
        /// <summary>
        /// GetVehicleInfoByIdAsync.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <returns>Vehicle.</returns>
        public Task<Vehicle> GetVehicleInfoByIdAsync(int id);

        /// <summary>
        /// GetVehiclesInfoAsync.
        /// </summary>
        /// <returns>Vehicles List.</returns>
        public Task<List<Vehicle>> GetVehiclesInfoAsync();
    }
}
