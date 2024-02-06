namespace GtMotive.Estimate.Microservice.Api.DTOs
{
    /// <summary>
    /// DTO for adding a new vehicle to the fleet.
    /// </summary>
    public class VehicleAddDto
    {
        /// <summary>
        /// Gets or sets the license plate of the vehicle to add.
        /// </summary>
        public string LicensePlate { get; set; }

        /// <summary>
        /// Gets or sets the make of the new vehicle.
        /// </summary>
        public string Make { get; set; }

        /// <summary>
        /// Gets or sets the model of the new vehicle.
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// Gets or sets the manufacture year of the new vehicle.
        /// </summary>
        public int ManufactureYear { get; set; }
    }
}
