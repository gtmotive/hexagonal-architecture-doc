namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.DeleteRental
{
    /// <summary>
    /// Delete Remtal Input.
    /// </summary>
    public class DeleteRentalInput : IUseCaseInput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteRentalInput"/> class.
        /// </summary>
        /// <param name="id">id.</param>
        public DeleteRentalInput(int id)
        {
            Id = id;
        }

        /// <summary>
        /// Gets Id.
        /// </summary>
        public int Id { get; private set; }
    }
}
