using System;

namespace GtMotive.Estimate.Microservice.Api.DTOs
{
    /// <summary>
    /// DTO for listing vehicle information.
    /// </summary>
    public class VehicleListDto
    {
        /// <summary>
        /// Gets or sets the unique identifier for the vehicle.
        /// </summary>
        public Guid VehicleId { get; set; }

        /// <summary>
        /// Gets or sets the license plate of the vehicle.
        /// </summary>
        public string LicensePlate { get; set; }

        /// <summary>
        /// Gets or sets the make of the vehicle.
        /// </summary>
        public string Make { get; set; }

        /// <summary>
        /// Gets or sets the model of the vehicle.
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// Gets or sets the manufacture year of the vehicle.
        /// </summary>
        public int ManufactureYear { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the vehicle is available for rental.
        /// </summary>
        public bool IsAvailable { get; set; }
    }
}
