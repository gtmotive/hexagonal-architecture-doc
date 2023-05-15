namespace GtMotive.Estimate.Microservice.Api.UseCases.DeleteRental
{
    public class DeleteRentalResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteRentalResponse"/> class.
        /// </summary>
        /// <param name="vehicleId">vehicleId.</param>
        /// <param name="isAvailable">isAvailable.</param>
        public DeleteRentalResponse(int vehicleId, bool isAvailable)
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
