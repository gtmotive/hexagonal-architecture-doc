using System.ComponentModel.DataAnnotations;
using MediatR;

namespace GtMotive.Estimate.Microservice.ApplicationCore.Features.Reservation.Commands.DeleteReservation
{
    /// <summary>
    /// DeleteReservationCommand.
    /// </summary>
    public class DeleteReservationCommand : IRequest<bool>
    {
        /// <summary>
        /// Gets or sets Id.
        /// </summary>
        [Required]
        public int Id { get; set; }
    }
}
