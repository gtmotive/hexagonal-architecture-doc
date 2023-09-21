using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.RentVehicle
{
    /// <summary>
    /// Represents the input data for renting a vehicle.
    /// </summary>
    public class RentVehicleInput : IUseCaseInput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RentVehicleInput"/> class.
        /// </summary>
        /// <param name="vehicleId">The unique identifier of the vehicle to be rented.</param>
        /// <param name="startTime">The start time of the rental.</param>
        /// <param name="endTime">The end time of the rental.</param>
        /// <param name="clientIdCard">The client's identification card.</param>
        public RentVehicleInput(Guid vehicleId, DateTime startTime, DateTime endTime, string clientIdCard)
        {
            VehicleId = vehicleId;
            StartTime = startTime;
            EndTime = endTime;
            ClientIdCard = clientIdCard;
        }

        /// <summary>
        /// Gets the unique identifier of the vehicle to be rented.
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
