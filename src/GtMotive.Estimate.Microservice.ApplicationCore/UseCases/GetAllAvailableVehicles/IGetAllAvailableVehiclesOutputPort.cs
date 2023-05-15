namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.GetAllAvailableVehicles
{
    /// <summary>
    /// IGetAllAvailableVehiclesOutputPort base interface.
    /// </summary>
    public interface IGetAllAvailableVehiclesOutputPort : IOutputPortStandard<GetAllAvailableVehiclesOutput>
    {
        /// <summary>
        /// Defines not found handler.
        /// </summary>
        /// <param name="message">Message.</param>
        void NotFoundHandle(string message);
    }
}
