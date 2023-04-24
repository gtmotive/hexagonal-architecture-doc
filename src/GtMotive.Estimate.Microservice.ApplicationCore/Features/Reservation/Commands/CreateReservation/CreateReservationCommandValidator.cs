using FluentValidation;

namespace GtMotive.Estimate.Microservice.ApplicationCore.Features.Reservation.Commands.CreateReservation
{
    /// <summary>
    /// CreateReservationCommandValidator.
    /// </summary>
    public class CreateReservationCommandValidator : AbstractValidator<CreateReservationCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateReservationCommandValidator"/> class.
        /// </summary>
        public CreateReservationCommandValidator()
        {
            RuleFor(p => p.DateFrom)
                .NotEmpty().WithMessage("{DateFrom} is empty")
                .NotNull().WithMessage("{DateFrom} is null");

            RuleFor(p => p.DateTo)
                .NotEmpty().WithMessage("{DateTo} is empty")
                .NotNull().WithMessage("{DateTo} is null");

            RuleFor(p => p.UserId)
                .NotEmpty().WithMessage("{UserId} is empty")
                .NotNull().WithMessage("{UserId} is null");

            RuleFor(p => p.VehicleId)
                .NotEmpty().WithMessage("{VehicleId} is empty")
                .NotNull().WithMessage("{VehicleId} is null");
        }
    }
}
