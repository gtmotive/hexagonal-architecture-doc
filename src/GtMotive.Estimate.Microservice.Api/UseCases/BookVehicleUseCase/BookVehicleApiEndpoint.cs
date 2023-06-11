using System;
using System.Threading.Tasks;
using FluentValidation;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.BookVehicleUseCase;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.UseCases.BookVehicleUseCase
{
    [ApiController]
    public class BookVehicleApiEndpoint : ControllerBase
    {
        private readonly IBookVehicleWebApiPresenter _presenter;
        private readonly IValidator<BookVehicleRequest> _validator;
        private readonly IBookVehicleUseCase _useCase;

        public BookVehicleApiEndpoint(IBookVehicleWebApiPresenter presenter, IBookVehicleUseCase useCase, IValidator<BookVehicleRequest> validator)
        {
            _presenter = presenter;
            _useCase = useCase;
            _validator = validator;
        }

        [HttpPost("Customer/{customerId:guid}/BookVehicle/{vehicleId:guid}")]
        public async Task<IActionResult> BookVehicle(Guid customerId, Guid vehicleId, BookVehicleRequest request)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            await _validator.ValidateAsync(request);

            var input = new BookVehicleInput(customerId, vehicleId, DateOnly.FromDateTime(request.ReturnDate));

            await _useCase.Execute(input);

            return _presenter.ActionResult;
        }
    }
}
