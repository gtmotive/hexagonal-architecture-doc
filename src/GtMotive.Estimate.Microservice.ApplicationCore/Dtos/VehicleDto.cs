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
        /// <param name="brand">Vehicle brand.</param>
        /// <param name="manufacturingDate">Vehicle manufacturing date.</param>
        public VehicleDto(string brand, DateTime manufacturingDate)
        {
            Brand = brand;
            ManufacturingDate = manufacturingDate;
        }

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
