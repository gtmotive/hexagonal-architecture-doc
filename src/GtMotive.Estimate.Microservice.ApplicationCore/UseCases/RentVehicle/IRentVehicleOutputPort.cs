namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.RentVehicle
{
    /// <summary>
    /// Represents an interface for the output port responsible for handling the results of the vehicle rental operation.
    /// </summary>
    public interface IRentVehicleOutputPort : IOutputPortStandard<RentVehicleOutput>, IOutputPortNotFound
    {
        /// <summary>
        /// Handles an exception that occurred during the vehicle rental process.
        /// </summary>
        /// <param name="message">The error message describing the exception.</param>
        void ExceptionHandle(string message);
    }
}
