using System.Collections.Generic;
using GtMotive.Estimate.Microservice.Domain.Entities;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.GetAllAvailableVehicles
{
    /// <summary>
    /// Represents the output data containing a list of available vehicles.
    /// </summary>
    public class GetAvailableVehiclesOutput : IUseCaseOutput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAvailableVehiclesOutput"/> class.
        /// </summary>
        /// <param name="vehicles">The list of available vehicles.</param>
        public GetAvailableVehiclesOutput(List<Vehicle> vehicles)
        {
            VehicleList = vehicles;
        }

        /// <summary>
        /// Gets the list of available vehicles.
        /// </summary>
        public List<Vehicle> VehicleList { get; private set; }
    }
}
