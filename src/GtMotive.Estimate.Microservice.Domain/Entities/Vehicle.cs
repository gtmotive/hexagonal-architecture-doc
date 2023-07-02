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
        /// Manufacturing date value object.
        /// </summary>
        private readonly VehicleManufacturingDate manufacturingDate;

        /// <summary>
        /// Initializes a new instance of the <see cref="Vehicle"/> class.
        /// </summary>
        /// <param name="brand">Vehicle brand.</param>
        /// <param name="manufacturingDate">Vehicle manufacturing date.</param>
        public Vehicle(string brand, DateTime manufacturingDate)
        {
            Brand = brand;
            this.manufacturingDate = new VehicleManufacturingDate(manufacturingDate);
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
        public DateTime ManufacturingDate
        {
            get => manufacturingDate.Value;
            set => manufacturingDate.Value = value;
        }

        /// <summary>
        /// Gets vehicles rentals.
        /// </summary>
        public Collection<Rental> Rentals { get; private set; }
    }
}
