namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ReturnVehicle
{
    /// <summary>
    /// Represents the output data produced by the use case for returning a rented vehicle.
    /// </summary>
    public class ReturnVehicleOutput : IUseCaseOutput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReturnVehicleOutput"/> class.
        /// </summary>
        /// <param name="msg">A message indicating the status of the vehicle return operation.</param>
        public ReturnVehicleOutput(string msg)
        {
            Message = msg;
        }

        /// <summary>
        /// Gets a message indicating the status of the vehicle return operation.
        /// </summary>
        public string Message { get; private set; }
    }
}
