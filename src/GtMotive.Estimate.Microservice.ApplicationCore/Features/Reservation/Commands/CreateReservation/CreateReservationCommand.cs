using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using MediatR;

namespace GtMotive.Estimate.Microservice.ApplicationCore.Features.Reservation.Commands.CreateReservation
{
    /// <summary>
    /// CreateReservationCommand.
    /// </summary>
    public class CreateReservationCommand : IRequest<int?>
    {
        /// <summary>
        /// Gets or sets UserId.
        /// </summary>
        [JsonIgnore]
        public Guid UserId { get; set; }

        /// <summary>
        /// Gets or sets VehicleId.
        /// </summary>
        [Required]
        public int VehicleId { get; set; }

        /// <summary>
        /// Gets or sets date from.
        /// </summary>
        [Required]
        public DateTime DateFrom { get; set; }

        /// <summary>
        /// Gets or sets date to.
        /// </summary>
        [Required]
        public DateTime DateTo { get; set; }
    }
}
