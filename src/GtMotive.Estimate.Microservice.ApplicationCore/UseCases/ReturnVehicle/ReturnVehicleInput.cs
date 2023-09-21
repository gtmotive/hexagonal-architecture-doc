using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ReturnVehicle
{
    /// <summary>
    /// Represents the input data for returning a rented vehicle.
    /// </summary>
    public class ReturnVehicleInput : IUseCaseInput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReturnVehicleInput"/> class.
        /// </summary>
        /// <param name="rentalId">The unique identifier of the rental to be completed.</param>
        public ReturnVehicleInput(Guid rentalId)
        {
            RentalId = rentalId;
        }

        /// <summary>
        /// Gets the unique identifier of the rental to be completed.
        /// </summary>
        public Guid RentalId { get; private set; }
    }
}
