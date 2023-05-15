namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.GetAllAvailableVehicles
{
    /// <summary>
    /// GetAllAvailableVehicles Input.
    /// </summary>
    public class GetAllAvailableVehiclesInput : IUseCaseInput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllAvailableVehiclesInput"/> class.
        /// </summary>
        /// <param name="fleedId">fleedId.</param>
        public GetAllAvailableVehiclesInput(int fleedId)
        {
            FleedId = fleedId;
        }

        /// <summary>
        /// Gets fleet Id.
        /// </summary>
        public int FleedId { get; private set; }
    }
}
