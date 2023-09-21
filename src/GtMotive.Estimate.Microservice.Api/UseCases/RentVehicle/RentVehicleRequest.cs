using System;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.RentVehicle
{
    public class RentVehicleRequest : IRequest<IWebApiPresenter>
    {
        public RentVehicleRequest(Guid vehicleId, DateTime startTime, DateTime endTime, string clientIdCard)
        {
            VehicleId = vehicleId;
            StartTime = startTime;
            EndTime = endTime;
            ClientIdCard = clientIdCard;
        }

        public Guid VehicleId { get; private set; }

        public DateTime StartTime { get; private set; }

        public DateTime EndTime { get; private set; }

        public string ClientIdCard { get; private set; }
    }
}
