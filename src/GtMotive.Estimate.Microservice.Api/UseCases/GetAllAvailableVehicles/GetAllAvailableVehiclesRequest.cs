using System;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.GetAllAvailableVehicles
{
    public class GetAllAvailableVehiclesRequest : IRequest<IWebApiPresenter>
    {
        public GetAllAvailableVehiclesRequest(Guid fleedId)
        {
            FleetId = fleedId;
        }

        public Guid FleetId { get; private set; }
    }
}
