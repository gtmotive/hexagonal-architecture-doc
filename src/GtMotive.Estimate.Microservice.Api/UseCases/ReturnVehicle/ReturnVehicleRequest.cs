using System;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.ReturnVehicle
{
    public class ReturnVehicleRequest : IRequest<IWebApiPresenter>
    {
        public ReturnVehicleRequest(Guid rentalId)
        {
            RentalId = rentalId;
        }

        public Guid RentalId { get; private set; }
    }
}
