using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.Application.CreateRental;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateRental;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.CreateRental
{
    public class CreateRentalRequestHandler
        : IRequestHandler<CreateRentalRequest, IWebApiPresenter>
    {
        private readonly ICreateRentalUseCase _useCase;
        private readonly ICreateRentalPresenter _presenter;

        public CreateRentalRequestHandler(
            ICreateRentalUseCase useCase,
            ICreateRentalPresenter presenter)
        {
            _useCase = useCase;
            _presenter = presenter;
        }

        public async Task<IWebApiPresenter> Handle(CreateRentalRequest request, CancellationToken cancellationToken)
        {
            var input = new CreateRentalInput(request.VehicleId, request.CustomerId);
            await _useCase.Execute(input);
            return _presenter;
        }
    }
}
