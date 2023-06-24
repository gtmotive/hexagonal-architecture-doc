using System;
using System.Collections.ObjectModel;

namespace GtMotive.Estimate.Microservice.Domain.Entities
{
    /// <summary>
    /// Represents the domain model of a Vehicle.
    /// </summary>
    public class Vehicle
    {
        /// <summary>
        /// Gets or sets vehicle Identify.
        /// </summary>
        public Guid VehicleId { get; set; }

        /// <summary>
        /// Gets or sets vehicle brand.
        /// </summary>
        public string Marca { get; set; }

        /// <summary>
        /// Gets or sets vehicle model.
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// Gets vehicles rentals.
        /// </summary>
        public Collection<Rental> Rentals { get; private set; }
    }
}
