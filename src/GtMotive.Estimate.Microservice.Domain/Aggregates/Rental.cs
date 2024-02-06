using System;

namespace GtMotive.Estimate.Microservice.Domain.Aggregates
{
    /// <summary>
    /// Represents a rental agreement for a vehicle.
    /// </summary>
    public class Rental
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Rental"/> class.
        /// </summary>
        /// <param name="vehicleId">The ID of the vehicle being rented.</param>
        /// <param name="customerId">The ID of the customer renting the vehicle.</param>
        /// <param name="startDate">The start date of the rental period.</param>
        public Rental(Guid vehicleId, Guid customerId, DateTime startDate)
        {
            RentalId = Guid.NewGuid();
            VehicleId = vehicleId;
            CustomerId = customerId;
            StartDate = startDate;
            EndDate = null;
            IsActive = true;
        }

        private Rental()
        {
        }

        /// <summary>
        /// Gets the unique identifier for the rental.
        /// </summary>
        public Guid RentalId { get; private set; }

        /// <summary>
        /// Gets the unique identifier of the rented vehicle.
        /// </summary>
        public Guid VehicleId { get; private set; }

        /// <summary>
        /// Gets the unique identifier of the customer who rents the vehicle.
        /// </summary>
        public Guid CustomerId { get; private set; }

        /// <summary>
        /// Gets the start date of the rental.
        /// </summary>
        public DateTime StartDate { get; private set; }

        /// <summary>
        /// Gets the end date of the rental.
        /// </summary>
        public DateTime? EndDate { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the rental is currently active.
        /// </summary>
        public bool IsActive { get; private set; }

        /// <summary>
        /// Completes the rental.
        /// </summary>
        /// <param name="endDate">The end date of the rental period.</param>
        public void CompleteRental(DateTime endDate)
        {
            if (endDate <= StartDate)
            {
                throw new InvalidOperationException("End date must be later than start date.");
            }

            EndDate = endDate;
            IsActive = false;
        }
    }
}
