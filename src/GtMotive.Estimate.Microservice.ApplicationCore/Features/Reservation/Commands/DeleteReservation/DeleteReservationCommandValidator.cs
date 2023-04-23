using FluentValidation;

namespace GtMotive.Estimate.Microservice.ApplicationCore.Features.Reservation.Commands.DeleteReservation
{
    /// <summary>
    /// DeleteReservationCommandValidator.
    /// </summary>
    public class DeleteReservationCommandValidator : AbstractValidator<DeleteReservationCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteReservationCommandValidator"/> class.
        /// </summary>
        public DeleteReservationCommandValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("{Id} is empty")
                .NotNull().WithMessage("{Id} is null");
        }
    }
}
