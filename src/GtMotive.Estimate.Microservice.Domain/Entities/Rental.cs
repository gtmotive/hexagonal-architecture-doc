using System;

namespace GtMotive.Estimate.Microservice.Domain.Entities
{
    /// <summary>
    /// Represents a rental of a vehicle.
    /// </summary>
    public class Rental
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Rental"/> class.
        /// </summary>
        /// <param name="id">The unique identifier of the rental.</param>
        /// <param name="vehicleId">The unique identifier of the rented vehicle.</param>
        /// <param name="startTime">The start time of the rental period.</param>
        /// <param name="endTime">The end time of the rental period.</param>
        /// <param name="clientIdCard">The client's identification card associated with the rental.</param>
        public Rental(Guid id, Guid vehicleId, DateTime startTime, DateTime endTime, string clientIdCard)
        {
            Id = id;
            VehicleId = vehicleId;
            StartTime = startTime;
            EndTime = endTime;
            ClientIdCard = clientIdCard;
        }

        /// <summary>
        /// Gets the unique identifier of the rental.
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Gets the unique identifier of the rented vehicle.
        /// </summary>
        public Guid VehicleId { get; private set; }

        /// <summary>
        /// Gets the start time of the rental period.
        /// </summary>
        public DateTime StartTime { get; private set; }

        /// <summary>
        /// Gets the end time of the rental period.
        /// </summary>
        public DateTime EndTime { get; private set; }

        /// <summary>
        /// Gets the client's identification card associated with the rental.
        /// </summary>
        public string ClientIdCard { get; private set; }
    }
}
