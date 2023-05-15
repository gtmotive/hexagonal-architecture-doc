using System;
using GtMotive.Estimate.Microservice.Domain.SeedWork;
using GtMotive.Estimate.Microservice.Domain.ValueObjects;

namespace GtMotive.Estimate.Microservice.Domain.Aggregates.Fleet
{
    /// <summary>
    /// Vehicle base class.
    /// </summary>
    public class Vehicle
        : Entity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Vehicle"/> class.
        /// </summary>
        /// <param name="modelYear">Model Year.</param>
        /// <param name="name">Name.</param>
        public Vehicle(int modelYear, string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            Name = new Name(name);
            ModelYear = modelYear;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vehicle"/> class.
        /// Default Constructor.
        /// </summary>
        protected Vehicle()
        {
        }

        /// <summary>
        /// Gets the Fleed Identifier.
        /// </summary>
        public int FleetId { get; private set; }

        /// <summary>
        /// Gets the name.
        /// </summary>
        public Name Name { get; private set; }

        /// <summary>
        /// Gets the model Year.
        /// </summary>
        public int ModelYear { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the available status.
        /// </summary>
        public bool IsAvailable { get; private set; }

        /// <summary>
        /// Set as Available.
        /// </summary>
        public void SetAsAvailable() => IsAvailable = true;

        /// <summary>
        /// Set as UnAvailable.
        /// </summary>
        public void SetAsUnAvailable() => IsAvailable = false;
    }
}
