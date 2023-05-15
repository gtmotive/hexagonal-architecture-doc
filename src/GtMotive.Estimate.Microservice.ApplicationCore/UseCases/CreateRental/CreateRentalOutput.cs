using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateRental
{
    /// <summary>
    /// CreateFleetOutput.
    /// </summary>
    public class CreateRentalOutput : IUseCaseOutput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateRentalOutput"/> class.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <param name="date">Date.</param>
        public CreateRentalOutput(int id, DateTime date)
        {
            Id = id;
            Date = date;
        }

        /// <summary>
        /// Gets the id.
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// Gets the Date.
        /// </summary>
        public DateTime Date { get; private set; }
    }
}
