using System;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.RentVehicle;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.RentVehicle
{
    public class RentVehicleHandler : IRequestHandler<RentVehicleRequest, IWebApiPresenter>
    {
        private readonly IRentVehicleUseCase _rentVehicleUseCase;
        private readonly IRentVehiclePresenter _rentVehiclePresenter;

        public RentVehicleHandler(IRentVehicleUseCase rentVehicleUseCase, IRentVehiclePresenter rentVehiclePresenter)
        {
            _rentVehicleUseCase = rentVehicleUseCase ?? throw new ArgumentNullException(nameof(rentVehicleUseCase));
            _rentVehiclePresenter = rentVehiclePresenter ?? throw new ArgumentNullException(nameof(rentVehiclePresenter));
        }

        public async Task<IWebApiPresenter> Handle(RentVehicleRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var rental = new RentVehicleInput(request.VehicleId, request.StartTime, request.EndTime, request.ClientIdCard);
            await _rentVehicleUseCase.Execute(rental);
            return _rentVehiclePresenter;
        }
    }
}
