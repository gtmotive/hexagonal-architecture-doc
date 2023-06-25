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
        /// Initializes a new instance of the <see cref="Vehicle"/> class.
        /// </summary>
        /// <param name="brand">Vehicle brand.</param>
        /// <param name="manufacturingDate">Vehicle manufacturing date.</param>
        public Vehicle(string brand, DateTime manufacturingDate)
        {
            Brand = brand;
            ManufacturingDate = manufacturingDate;
        }

        /// <summary>
        /// Gets or sets vehicle Identify.
        /// </summary>
        public int VehicleId { get; set; }

        /// <summary>
        /// Gets or sets vehicle brand.
        /// </summary>
        public string Brand { get; set; }

        /// <summary>
        /// Gets or sets vehicle manufactoring date.
        /// </summary>
        public DateTime ManufacturingDate { get; set; }

        /// <summary>
        /// Gets vehicles rentals.
        /// </summary>
        public Collection<Rental> Rentals { get; private set; }
    }
}
