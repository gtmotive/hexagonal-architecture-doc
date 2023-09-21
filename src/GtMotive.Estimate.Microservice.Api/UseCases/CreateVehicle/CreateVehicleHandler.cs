using System;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateVehicle;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.CreateVehicle
{
    public class CreateVehicleHandler : IRequestHandler<CreateVehicleRequest, ICreateVehiclePresenter>
    {
        private readonly ICreateVehicleUseCase _createVehicleUseCase;
        private readonly ICreateVehiclePresenter _createVehiclePresenter;

        public CreateVehicleHandler(ICreateVehiclePresenter createVehiclePresenter, ICreateVehicleUseCase createVehicleUseCase)
        {
            _createVehiclePresenter = createVehiclePresenter ?? throw new ArgumentNullException(nameof(createVehiclePresenter));
            _createVehicleUseCase = createVehicleUseCase ?? throw new ArgumentNullException(nameof(createVehicleUseCase));
        }

        public async Task<ICreateVehiclePresenter> Handle(CreateVehicleRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var input = new CreateVehicleInput(request.Fleet, request.Brand, request.Model, request.ManufacturingDate, request.IsRental);
            await _createVehicleUseCase.Execute(input);
            return _createVehiclePresenter;
        }
    }
}
