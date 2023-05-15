namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.DeleteRental
{
    /// <summary>
    /// DeleteRentalOutput.
    /// </summary>
    public class DeleteRentalOutput : IUseCaseOutput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteRentalOutput"/> class.
        /// </summary>
        /// <param name="vehicleId">vehicleId.</param>
        /// <param name="isAvailable">isAvailable.</param>
        public DeleteRentalOutput(int vehicleId, bool isAvailable)
        {
            VehicleId = vehicleId;
            IsAvailable = isAvailable;
        }

        /// <summary>
        /// Gets vehicleId.
        /// </summary>
        public int VehicleId { get; private set; }

        /// <summary>
        /// Gets a value indicating whether isAvailable.
        /// </summary>
        public bool IsAvailable { get; private set; }
    }
}
