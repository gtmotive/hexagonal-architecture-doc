namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.GetAllAvailableVehicles
{
    /// <summary>
    /// Represents an interface for the output port responsible for handling the results of retrieving available vehicles.
    /// </summary>
    public interface IGetAvailableVehiclesOutputPort : IOutputPortStandard<GetAvailableVehiclesOutput>
    {
        /// <summary>
        /// Handles an exception that occurred during the retrieval of available vehicles.
        /// </summary>
        /// <param name="message">The error message describing the exception.</param>
        void ExceptionHandle(string message);
    }
}
