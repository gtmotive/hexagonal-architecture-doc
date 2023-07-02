using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.Dtos
{
    /// <summary>
    /// Vehicle DTO.
    /// </summary>
    public class VehicleDto
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VehicleDto"/> class.
        /// </summary>
        /// <param name="vehicleId">Vehicle Id.</param>
        /// <param name="brand">Vehicle brand.</param>
        /// <param name="manufacturingDate">Vehicle manufacturing date.</param>
        public VehicleDto(int vehicleId, string brand, DateTime manufacturingDate)
        {
            VehicleId = vehicleId;
            Brand = brand;
            ManufacturingDate = manufacturingDate;
        }

        /// <summary>
        /// Gets or sets vehicle Identify.
        /// </summary>
        public int VehicleId { get; set; }

        /// <summary>
        /// Gets or Sets Brand.
        /// </summary>
        public string Brand { get; set; }

        /// <summary>
        /// Gets or sets vehicle manufactoring date.
        /// </summary>
        public DateTime ManufacturingDate { get; set; }
    }
}
