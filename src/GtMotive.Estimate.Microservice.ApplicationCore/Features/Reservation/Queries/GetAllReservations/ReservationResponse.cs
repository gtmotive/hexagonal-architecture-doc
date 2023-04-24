using System;
using System.ComponentModel.DataAnnotations;

namespace GtMotive.Estimate.Microservice.ApplicationCore.Features.Reservation.Queries.GetAllReservations
{
    /// <summary>
    /// ReservationResponse.
    /// </summary>
    public class ReservationResponse
    {
        /// <summary>
        /// Gets or sets Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets date from.
        /// </summary>
        public DateTime DateFrom { get; set; }

        /// <summary>
        /// Gets or sets date to.
        /// </summary>
        public DateTime DateTo { get; set; }

        /// <summary>
        /// Gets or sets Vehicle Id.
        /// </summary>
        [Required]
        public int VehicleId { get; set; }

        /// <summary>
        /// Gets or sets VehicleRegistrationNumber.
        /// </summary>
        [Required]
        public string VehicleRegistrationNumber { get; set; }

        /// <summary>
        /// Gets or sets User Id.
        /// </summary>
        [Required]
        public Guid UserId { get; set; }

        /// <summary>
        /// Gets or sets User email.
        /// </summary>
        [Required]
        public string UserEmail { get; set; }
    }
}
