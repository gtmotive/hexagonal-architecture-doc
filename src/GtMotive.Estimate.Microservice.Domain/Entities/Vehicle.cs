using System;

namespace GtMotive.Estimate.Microservice.Domain.Entities
{
    /// <summary>
    /// Represents a vehicle in the rental fleet.
    /// </summary>
    public class Vehicle
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Vehicle"/> class.
        /// </summary>
        /// <param name="licensePlate">The license plate of the vehicle.</param>
        /// <param name="make">The make of the vehicle.</param>
        /// <param name="model">The model of the vehicle.</param>
        /// <param name="manufactureYear">The year of manufacture of the vehicle.</param>
        public Vehicle(string licensePlate, string make, string model, int manufactureYear)
        {
            VehicleId = Guid.NewGuid();
            LicensePlate = licensePlate;
            Make = make;
            Model = model;
            ManufactureYear = manufactureYear;
            IsAvailable = true;
        }

        /// <summary>
        /// Gets the unique identifier for the vehicle.
        /// </summary>
        public Guid VehicleId { get; private set; }

        /// <summary>
        /// Gets the license plate of the vehicle.
        /// </summary>
        public string LicensePlate { get; private set; }

        /// <summary>
        /// Gets the make of the vehicle.
        /// </summary>
        public string Make { get; private set; }

        /// <summary>
        /// Gets the model of the vehicle.
        /// </summary>
        public string Model { get; private set; }

        /// <summary>
        /// Gets the year of manufacture of the vehicle.
        /// </summary>
        public int ManufactureYear { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the vehicle is available for rental.
        /// </summary>
        public bool IsAvailable { get; private set; }

        /// <summary>
        /// Rents the vehicle.
        /// </summary>
        public void Rent()
        {
            if (!IsAvailable)
            {
                throw new InvalidOperationException("Vehicle is already rented.");
            }

            IsAvailable = false;
        }

        /// <summary>
        /// Returns the vehicle from rental.
        /// </summary>
        public void Return()
        {
            IsAvailable = true;
        }
    }
}
