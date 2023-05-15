using System;
using System.Collections.Generic;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Domain.SeedWork;
using GtMotive.Estimate.Microservice.Domain.ValueObjects;

namespace GtMotive.Estimate.Microservice.Domain.Aggregates.Fleet
{
    /// <summary>
    /// Aggregate root for Fleet.
    /// </summary>
    public class Fleet
        : Entity, IAggregateRoot
    {
        private readonly Vehicles _vehicles;

        /// <summary>
        /// Initializes a new instance of the <see cref="Fleet"/> class.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <exception cref="ArgumentNullException">Exception.</exception>
        public Fleet(string name)
            : this()
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            Name = new Name(name);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Fleet"/> class.
        /// </summary>
        protected Fleet()
        {
            _vehicles = new Vehicles();
        }

        /// <summary>
        /// Gets the Name.
        /// </summary>
        public Name Name { get; private set; }

        /// <summary>
        /// Gets Vehicles as ReadOnly Collection.
        /// </summary>
        public IReadOnlyCollection<Vehicle> Vehicles => _vehicles.AsReadOnly();

        /// <summary>
        /// Adds a new Vehicle to the collection.
        /// </summary>
        /// <param name="vehicle">Vehicle object to be added.</param>
        public void AddVehicle(Vehicle vehicle)
        {
            if (vehicle == null)
            {
                throw new ArgumentNullException(nameof(vehicle));
            }

            _vehicles.Add(vehicle);
        }

        /// <summary>
        /// Adds a new Vehicle to the collection.
        /// </summary>
        /// <param name="modelYear">Model Year.</param>
        /// <param name="name">Name.</param>
        public void AddVehicle(int modelYear, string name)
        {
            var vehicle = new Vehicle(modelYear, name);
            AddVehicle(vehicle);
        }
    }
}
