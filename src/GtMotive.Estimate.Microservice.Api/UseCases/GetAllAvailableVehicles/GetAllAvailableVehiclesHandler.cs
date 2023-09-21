using System;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.GetAllAvailableVehicles;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.GetAllAvailableVehicles
{
    public class GetAllAvailableVehiclesHandler : IRequestHandler<GetAllAvailableVehiclesRequest, IWebApiPresenter>
    {
        private readonly IGetAllAvailableVehiclesUseCase _getAllAvailableVehiclesUseCase;
        private readonly IGetAllAvailableVehiclesPresenter _getAllAvailableVehiclesPresenter;

        public GetAllAvailableVehiclesHandler(IGetAllAvailableVehiclesUseCase getAllAvailableVehiclesUseCase, IGetAllAvailableVehiclesPresenter getAllAvailableVehiclesPresenter)
        {
            _getAllAvailableVehiclesUseCase = getAllAvailableVehiclesUseCase ?? throw new ArgumentNullException(nameof(getAllAvailableVehiclesUseCase));
            _getAllAvailableVehiclesPresenter = getAllAvailableVehiclesPresenter ?? throw new ArgumentNullException(nameof(getAllAvailableVehiclesPresenter));
        }

        public async Task<IWebApiPresenter> Handle(GetAllAvailableVehiclesRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var input = new GetAllAvailableVehiclesInput(request.FleetId);
            await _getAllAvailableVehiclesUseCase.Execute(input);
            return _getAllAvailableVehiclesPresenter;
        }
    }
}
