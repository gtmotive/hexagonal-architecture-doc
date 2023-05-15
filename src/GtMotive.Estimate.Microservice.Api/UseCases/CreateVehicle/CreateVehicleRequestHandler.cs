using System;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateVehicle;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.CreateVehicle
{
    public class CreateVehicleRequestHandler
        : IRequestHandler<CreateVehicleRequest, IWebApiPresenter>
    {
        private readonly ICreateVehicleUseCase _useCase;
        private readonly ICreateVehiclePresenter _presenter;

        public CreateVehicleRequestHandler(
            ICreateVehicleUseCase useCase,
            ICreateVehiclePresenter presenter)
        {
            _useCase = useCase;
            _presenter = presenter;
        }

        public async Task<IWebApiPresenter> Handle(CreateVehicleRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var input = new CreateVehicleInput(request.FleetId, request.Name, request.ModelYear);
            await _useCase.Execute(input);
            return _presenter;
        }
    }
}
