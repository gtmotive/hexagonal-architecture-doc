namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateRental
{
    /// <summary>
    /// ICreateRentalOutputPort base interface.
    /// </summary>
    public interface ICreateRentalOutputPort : IOutputPortStandard<CreateRentalOutput>
    {
        /// <summary>
        /// Defines not found handler.
        /// </summary>
        /// <param name="message">Message.</param>
        void NotFoundHandle(string message);

        /// <summary>
        /// Defines not vehicle available handler.
        /// </summary>
        /// <param name="message">Message.</param>
        void BadRequestHandle(string message);
    }
}
