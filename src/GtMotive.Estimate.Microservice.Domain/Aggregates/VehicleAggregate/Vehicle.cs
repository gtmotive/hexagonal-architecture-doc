using System;
using GtMotive.Estimate.Microservice.Domain.Exceptions;
using GtMotive.Estimate.Microservice.Domain.Interfaces;

namespace GtMotive.Estimate.Microservice.Domain.Aggregates.VehicleAggregate
{
    /// <summary>
    /// Vehicle aggregate root.
    /// </summary>
    public class Vehicle : Entity, IAggregateRoot
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Vehicle"/> class.
        /// </summary>
        /// <param name="model">Model.</param>
        /// <param name="manufacturingDate">Manufacturing date.</param>
        /// <exception cref="VehicleAgeException">Vehicle age exception.</exception>
        public Vehicle(Model model, DateOnly manufacturingDate)
        {
            // Validate vehicle isn't older than 5 years
            if (DateOnly.FromDateTime(DateTime.UtcNow.AddYears(-5)) > manufacturingDate)
            {
                throw new VehicleAgeException(manufacturingDate);
            }

            Id = Guid.NewGuid();

            Model = model;
            ManufacturingDate = manufacturingDate;
            IsAvailable = true;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vehicle"/> class.
        /// MongoDb deserialization constructor.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <param name="model">Model.</param>
        /// <param name="manufacturingDate">ManufacturingDate.</param>
        /// <param name="isAvailable">IsAvailable.</param>
        public Vehicle(Guid id, Model model, DateOnly manufacturingDate, bool isAvailable)
        {
            Id = id;
            Model = model;
            ManufacturingDate = manufacturingDate;
            IsAvailable = isAvailable;
        }

        /// <summary>
        /// Gets the vehicle identifier.
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Gets the vehicle model.
        /// </summary>
        public Model Model { get; private set; }

        /// <summary>
        /// Gets the vehicle manufacturing date.
        /// </summary>
        public DateOnly ManufacturingDate { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the vehicle is available.
        /// </summary>
        public bool IsAvailable { get; private set; }

        /// <summary>
        /// Enable the availability.
        /// </summary>
        public void EnableAvailability()
        {
            IsAvailable = true;
        }

        /// <summary>
        /// Disable the availability.
        /// </summary>
        public void DisableAvailability()
        {
            IsAvailable = false;
        }
    }
}
