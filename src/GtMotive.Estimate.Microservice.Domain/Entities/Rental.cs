using System;

namespace GtMotive.Estimate.Microservice.Domain.Entities
{
    /// <summary>
    /// Represents the domain model of a Rental.
    /// </summary>
    public class Rental
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Rental"/> class.
        /// </summary>
        /// <param name="vehicleId">vehicle Id.</param>
        /// <param name="clientId">client Id.</param>
        /// <param name="startingDate">start Date.</param>
        /// <param name="endingDate">end Date.</param>
        public Rental(int vehicleId, int clientId, DateTime startingDate, DateTime endingDate)
        {
            VehicleId = vehicleId;
            ClientId = clientId;
            StartingDate = startingDate;
            EndingDate = endingDate;
        }

        /// <summary>
        /// Gets or Sets the rented vehicle Identify.
        /// </summary>
        public int VehicleId { get; set; }

        /// <summary>
        /// Gets or Sets the reting client Identify.
        /// </summary>
        public int ClientId { get; set; }

        /// <summary>
        /// Gets or Sets the starting rental date.
        /// </summary>
        public DateTime StartingDate { get; set; }

        /// <summary>
        /// Gets or Sets the ending rental date.
        /// </summary>
        public DateTime EndingDate { get; set; }

        /// <summary>
        /// Gets or Sets the reference of the rented vehicle.
        /// </summary>
        public Vehicle Vehicle { get; set; }

        /// <summary>
        /// Gets or Sets the reference of the renting client.
        /// </summary>
        public Client Client { get; set; }
    }
}
