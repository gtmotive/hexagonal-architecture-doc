using System;

namespace GtMotive.Estimate.Microservice.Host.Models
{
    public abstract class RentDto
    {
        public string VehicleId { get; set; }

        public DateTime InitialDate { get; set; }

        public DateTime FinalDate { get; set; }

        public DateTime OperationDate { get; set; }
    }
}
