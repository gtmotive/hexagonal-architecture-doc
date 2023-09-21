using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.RentVehicle
{
    /// <summary>
    /// Represents the output data produced by the use case for renting a vehicle.
    /// </summary>
    public class RentVehicleOutput : IUseCaseOutput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RentVehicleOutput"/> class.
        /// </summary>
        /// <param name="id">The unique identifier of the rental.</param>
        /// <param name="vehicleId">The unique identifier of the rented vehicle.</param>
        /// <param name="startTime">The start time of the rental.</param>
        /// <param name="endTime">The end time of the rental.</param>
        /// <param name="clientIdCard">The client's identification card.</param>
        public RentVehicleOutput(Guid id, Guid vehicleId, DateTime startTime, DateTime endTime, string clientIdCard)
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
        /// Gets the start time of the rental.
        /// </summary>
        public DateTime StartTime { get; private set; }

        /// <summary>
        /// Gets the end time of the rental.
        /// </summary>
        public DateTime EndTime { get; private set; }

        /// <summary>
        /// Gets the client's identification card.
        /// </summary>
        public string ClientIdCard { get; private set; }
    }
}
