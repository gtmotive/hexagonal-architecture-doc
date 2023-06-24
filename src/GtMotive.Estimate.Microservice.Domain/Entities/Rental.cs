using System;

namespace GtMotive.Estimate.Microservice.Domain.Entities
{
    /// <summary>
    /// Represents the domain model of a Rental.
    /// </summary>
    public class Rental
    {
        /// <summary>
        /// Gets or Sets the rented vehicle Identify.
        /// </summary>
        public int VehicleId { get; set; }

        /// <summary>
        /// Gets or Sets the reting client Identify.
        /// </summary>
        public int ClientId { get; set; }

        /// <summary>
        /// Gets or Sets the reference of the rented vehicle.
        /// </summary>
        public Vehicle Vehicle { get; set; }

        /// <summary>
        /// Gets or Sets the reference of the renting client.
        /// </summary>
        public Client Client { get; set; }

        /// <summary>
        /// Gets or Sets the starting rental date.
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Gets or Sets the ending rental date.
        /// </summary>
        public DateTime EndDate { get; set; }
    }
}
