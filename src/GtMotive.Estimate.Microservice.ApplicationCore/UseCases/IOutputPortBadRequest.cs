namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases
{
    /// <summary>
    /// Interface to define the Bad Request Output Port.
    /// </summary>
    public interface IOutputPortBadRequest
    {
        /// <summary>
        /// Informs the user that the request is invalid.
        /// </summary>
        /// <param name="message">Text description.</param>
        void BadRequest(string message);
    }
}
