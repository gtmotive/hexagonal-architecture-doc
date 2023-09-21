using System;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ReturnVehicle;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.ReturnVehicle
{
    public class ReturnVehicleHandler : IRequestHandler<ReturnVehicleRequest, IWebApiPresenter>
    {
        private readonly IReturnVehicleUseCase _returnVehicleUseCase;
        private readonly IReturnVehiclePresenter _returnVehiclePresenter;

        public ReturnVehicleHandler(IReturnVehicleUseCase returnVehicleUseCase, IReturnVehiclePresenter returnVehiclePresenter)
        {
            _returnVehicleUseCase = returnVehicleUseCase ?? throw new ArgumentNullException(nameof(returnVehicleUseCase));
            _returnVehiclePresenter = returnVehiclePresenter ?? throw new ArgumentNullException(nameof(returnVehiclePresenter));
        }

        public async Task<IWebApiPresenter> Handle(ReturnVehicleRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var input = new ReturnVehicleInput(request.RentalId);
            await _returnVehicleUseCase.Execute(input);
            return _returnVehiclePresenter;
        }
    }
}
