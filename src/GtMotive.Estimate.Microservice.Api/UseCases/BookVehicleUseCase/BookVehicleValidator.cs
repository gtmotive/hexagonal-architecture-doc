using FluentValidation;

namespace GtMotive.Estimate.Microservice.Api.UseCases.BookVehicleUseCase
{
    public class BookVehicleValidator : AbstractValidator<BookVehicleRequest>
    {
        public BookVehicleValidator()
        {
            RuleFor(x => x.ReturnDate).NotNull();
        }
    }
}
