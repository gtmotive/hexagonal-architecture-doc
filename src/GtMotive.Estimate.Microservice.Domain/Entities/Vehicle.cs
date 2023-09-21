using System;

namespace GtMotive.Estimate.Microservice.Domain.Entities
{
    /// <summary>
    /// Represents a vehicle.
    /// </summary>
    public class Vehicle
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Vehicle"/> class.
        /// </summary>
        /// <param name="id">The unique identifier of the vehicle.</param>
        /// <param name="fleet">The unique identifier of the fleet to which the vehicle belongs.</param>
        /// <param name="brand">The brand of the vehicle.</param>
        /// <param name="model">The model of the vehicle.</param>
        /// <param name="manufacturingDate">The manufacturing date of the vehicle.</param>
        /// <param name="isRental">A boolean value indicating whether the vehicle is available for rental.</param>
        public Vehicle(Guid id, Guid fleet, string brand, string model, DateTime manufacturingDate, bool isRental)
        {
            Id = id;
            Fleet = fleet;
            Brand = brand;
            Model = model;
            ManufacturingDate = manufacturingDate;
            IsRental = isRental;
        }

        /// <summary>
        /// Gets the unique identifier of the vehicle.
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Gets the unique identifier of the fleet to which the vehicle belongs.
        /// </summary>
        public Guid Fleet { get; private set; }

        /// <summary>
        /// Gets the brand of the vehicle.
        /// </summary>
        public string Brand { get; private set; }

        /// <summary>
        /// Gets the model of the vehicle.
        /// </summary>
        public string Model { get; private set; }

        /// <summary>
        /// Gets the manufacturing date of the vehicle.
        /// </summary>
        public DateTime ManufacturingDate { get; private set; }

        /// <summary>
        /// Gets a boolean value indicating whether the vehicle is available for rental.
        /// </summary>
        public bool IsRental { get; private set; }
    }
}
