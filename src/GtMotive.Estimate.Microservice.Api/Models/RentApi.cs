using System;

namespace GtMotive.Estimate.Microservice.Api.Models
{
    public class RentApi
    {
        public string Id { get; set; }

        public string VehicleId { get; set; }

        public DateTime InitialDate { get; set; }

        public DateTime FinalDate { get; set; }

        public DateTime OperationDate { get; set; }
    }
}
