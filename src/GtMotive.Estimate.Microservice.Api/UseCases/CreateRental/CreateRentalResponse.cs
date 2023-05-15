using System;

namespace GtMotive.Estimate.Microservice.Api.UseCases.CreateRental
{
    public class CreateRentalResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateRentalResponse"/> class.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <param name="date">Date.</param>
        public CreateRentalResponse(int id, DateTime date)
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
