using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateVehicle
{
    /// <summary>
    /// Represents the input data for creating a vehicle.
    /// </summary>
    public class CreateVehicleInput : IUseCaseInput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateVehicleInput"/> class.
        /// </summary>
        /// <param name="fleet">The ID of the fleet to which the vehicle will be associated.</param>
        /// <param name="brand">The brand of the vehicle.</param>
        /// <param name="model">The model of the vehicle.</param>
        /// <param name="manufacturingDate">The manufacturing date of the vehicle.</param>
        /// <param name="isRental">Indicates if the vehicle is rented.</param>
        public CreateVehicleInput(Guid fleet, string brand, string model, DateTime manufacturingDate, bool isRental)
        {
            Fleet = fleet;
            Brand = brand;
            Model = model;
            ManufacturingDate = manufacturingDate;
            IsRental = isRental;
        }

        /// <summary>
        /// Gets the ID of the fleet to which the vehicle will be associated.
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
        /// Gets a value that indicates whether the vehicle is rented.
        /// </summary>
        public bool IsRental { get; private set; }
    }
}
