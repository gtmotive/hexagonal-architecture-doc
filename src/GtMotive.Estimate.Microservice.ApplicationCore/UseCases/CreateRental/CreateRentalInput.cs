namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateRental
{
    /// <summary>
    /// Create Fleet Input.
    /// </summary>
    public class CreateRentalInput : IUseCaseInput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateRentalInput"/> class.
        /// </summary>
        /// <param name="vehicleId">vehicleId.</param>
        /// <param name="customerId">customerId.</param>
        public CreateRentalInput(int vehicleId, int customerId)
        {
            VehicleId = vehicleId;
            CustomerId = customerId;
        }

        /// <summary>
        /// Gets vehicleId.
        /// </summary>
        public int VehicleId { get; private set; }

        /// <summary>
        /// Gets customerId.
        /// </summary>
        public int CustomerId { get; private set; }
    }
}
