using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.Application.CreateFleet;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateFleet;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.CreateFleet
{
    public class CreateFleetRequestHandler
        : IRequestHandler<CreateFleetRequest, IWebApiPresenter>
    {
        private readonly ICreateFleetUseCase _useCase;
        private readonly ICreateFleetPresenter _presenter;

        public CreateFleetRequestHandler(
            ICreateFleetUseCase useCase,
            ICreateFleetPresenter presenter)
        {
            _useCase = useCase;
            _presenter = presenter;
        }

        public async Task<IWebApiPresenter> Handle(CreateFleetRequest request, CancellationToken cancellationToken)
        {
            var input = new CreateFleetInput(request?.Name);
            await _useCase.Execute(input);
            return _presenter;
        }
    }
}
