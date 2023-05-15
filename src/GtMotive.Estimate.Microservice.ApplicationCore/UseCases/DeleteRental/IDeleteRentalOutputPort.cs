namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.DeleteRental
{
    /// <summary>
    /// IDeleteRentalOutputPort base interface.
    /// </summary>
    public interface IDeleteRentalOutputPort : IOutputPortStandard<DeleteRentalOutput>
    {
        /// <summary>
        /// Defines not found handler.
        /// </summary>
        /// <param name="message">Message.</param>
        void NotFoundHandle(string message);
    }
}
