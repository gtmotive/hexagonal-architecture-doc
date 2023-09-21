using System;

namespace GtMotive.Estimate.Microservice.Api.UseCases.RentVehicle
{
    public class RentVehicleResponse
    {
        public RentVehicleResponse(Guid id, Guid vehicleId, DateTime startTime, DateTime endTime, string clientIdCard)
        {
            Id = id;
            VehicleId = vehicleId;
            StartTime = startTime;
            EndTime = endTime;
            ClientIdCard = clientIdCard;
        }

        public Guid Id { get; private set; }

        public Guid VehicleId { get; private set; }

        public DateTime StartTime { get; private set; }

        public DateTime EndTime { get; private set; }

        public string ClientIdCard { get; private set; }
    }
}
