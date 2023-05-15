using System.Collections.Generic;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Interfaces;

namespace GtMotive.Estimate.Microservice.Domain.Aggregates.Fleet
{
    /// <summary>
    /// Interface for Fleet Repository.
    /// </summary>
    public interface IFleetRepository : IRepository<Fleet>
    {
        /// <summary>
        /// GetAvailableVehiclesAsync.
        /// </summary>
        /// <param name="idFleet">idFleet.</param>
        /// <returns>Vehicles.</returns>
        Task<IEnumerable<Vehicle>> GetAvailableVehiclesAsync(int idFleet);

        /// <summary>
        /// GetVehicleAsync.
        /// </summary>
        /// <param name="idVehicle">idVehicle.</param>
        /// <returns>Vehicle.</returns>
        Task<Vehicle> GetVehicleAsync(int idVehicle);
    }
}
