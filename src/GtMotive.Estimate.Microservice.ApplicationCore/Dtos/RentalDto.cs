using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.Dtos
{
    /// <summary>
    /// Rental DTO.
    /// </summary>
    public class RentalDto
    {
        /// <summary>
        /// Gets or Sets Client.
        /// </summary>
        public ClientDto Client { get; set; }

        /// <summary>
        /// Gets or Sets Vehicle.
        /// </summary>
        public VehicleDto Vehicle { get; set; }

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
