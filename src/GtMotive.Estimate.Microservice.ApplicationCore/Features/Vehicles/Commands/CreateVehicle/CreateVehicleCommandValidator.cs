using FluentValidation;

namespace GtMotive.Estimate.Microservice.ApplicationCore.Features.Vehicles.Commands.CreateVehicle
{
    /// <summary>
    /// CreateVehicleCommand.
    /// </summary>
    public class CreateVehicleCommandValidator : AbstractValidator<CreateVehicleCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateVehicleCommandValidator"/> class.
        /// </summary>
        public CreateVehicleCommandValidator()
        {
            RuleFor(p => p.ManufacturingDate)
                .NotEmpty().WithMessage("{ManufacturingDate} is empty")
                .NotNull().WithMessage("{ManufacturingDate} is null");

            RuleFor(p => p.RegistrationNumber)
                .NotEmpty().WithMessage("{RegistrationNumber} is empty")
                .NotNull().WithMessage("{RegistrationNumber} is null")
                .MaximumLength(50).WithMessage("{RegistrationNumber} is too long");
        }
    }
}
