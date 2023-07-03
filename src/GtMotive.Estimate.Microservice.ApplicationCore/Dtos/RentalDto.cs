using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.Dtos
{
    /// <summary>
    /// Rental DTO.
    /// </summary>
    public class RentalDto
    {
        /// <summary>
        /// Gets or Sets Client Id.
        /// </summary>
        public int ClientId { get; set; }

        /// <summary>
        /// Gets or Sets Vehicle Id.
        /// </summary>
        public int VehicleId { get; set; }

        /// <summary>
        /// Gets or Sets Starting date.
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Gets or Sets Ending date.
        /// </summary>
        public DateTime EndDate { get; set; }
    }
}
