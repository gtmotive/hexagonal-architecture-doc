namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateVehicle
{
    /// <summary>
    /// ICreateFleetOutput base interface.
    /// </summary>
    public interface ICreateVehicleOutputPort : IOutputPortStandard<CreateVehicleOutput>
    {
        /// <summary>
        /// Defines not found handler.
        /// </summary>
        /// <param name="message">Message.</param>
        void NotFoundHandle(string message);

        /// <summary>
        /// Defines bad request handler.
        /// </summary>
        /// <param name="message">Message.</param>
        void BadRequestHandle(string message);
    }
}
