using System.Collections.Generic;
using GtMotive.Estimate.Microservice.Domain.Aggregates.Fleet;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.GetAllAvailableVehicles
{
    /// <summary>
    /// CreateFleetOutput.
    /// </summary>
    public class GetAllAvailableVehiclesOutput : IUseCaseOutput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllAvailableVehiclesOutput"/> class.
        /// </summary>
        /// <param name="vehicles">Vehicles.</param>
        public GetAllAvailableVehiclesOutput(IEnumerable<Vehicle> vehicles)
        {
            Items = vehicles;
        }

        /// <summary>
        /// Gets the items.
        /// </summary>
        public IEnumerable<Vehicle> Items { get; private set; }
    }
}
