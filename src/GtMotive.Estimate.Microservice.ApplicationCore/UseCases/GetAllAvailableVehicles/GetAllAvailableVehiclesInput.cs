using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.GetAllAvailableVehicles
{
    /// <summary>
    /// Represents the input data for retrieving all available vehicles in a specific fleet.
    /// </summary>
    public class GetAllAvailableVehiclesInput : IUseCaseInput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllAvailableVehiclesInput"/> class.
        /// </summary>
        /// <param name="idFleet">The ID of the fleet for which available vehicles will be retrieved.</param>
        public GetAllAvailableVehiclesInput(Guid idFleet)
        {
            IdFleet = idFleet;
        }

        /// <summary>
        /// Gets the ID of the fleet for which available vehicles will be retrieved.
        /// </summary>
        public Guid IdFleet { get; private set; }
    }
}
