using System;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.GetAllAvailableVehicles;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.GetAllAvailableVehicles
{
    public class GetAllAvailableVehiclesRequestHandler
        : IRequestHandler<GetAllAvailableVehiclesRequest, IWebApiPresenter>
    {
        private readonly IGetAllAvailableVehiclesUseCase _useCase;
        private readonly IGetAllAvailableVehiclesPresenter _presenter;

        public GetAllAvailableVehiclesRequestHandler(
            IGetAllAvailableVehiclesUseCase useCase,
            IGetAllAvailableVehiclesPresenter presenter)
        {
            _useCase = useCase;
            _presenter = presenter;
        }

        public async Task<IWebApiPresenter> Handle(GetAllAvailableVehiclesRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var input = new GetAllAvailableVehiclesInput(request.FleedId);
            await _useCase.Execute(input);
            return _presenter;
        }
    }
}
