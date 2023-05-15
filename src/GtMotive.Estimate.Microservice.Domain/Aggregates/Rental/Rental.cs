using System;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Domain.SeedWork;

namespace GtMotive.Estimate.Microservice.Domain.Aggregates.Rental
{
    /// <summary>
    /// Rental Entity.
    /// </summary>
    public class Rental
        : Entity, IAggregateRoot
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Rental"/> class.
        /// </summary>
        /// <param name="vehicleId">Vehicle Id.</param>
        /// <param name="customerId">Customer Id.</param>
        /// <param name="date">Date.</param>
        public Rental(int vehicleId, int customerId, DateTime date)
        {
            VehicleId = vehicleId;
            CustomerId = customerId;
            Date = date;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Rental"/> class.
        /// </summary>
        protected Rental()
        {
        }

        /// <summary>
        /// Gets vehicle IDentifier.
        /// </summary>
        public int VehicleId { get; private set; }

        /// <summary>
        /// Gets customerId.
        /// </summary>
        public int CustomerId { get; private set; }

        /// <summary>
        /// Gets date.
        /// </summary>
        public DateTime Date { get; private set; }
    }
}
