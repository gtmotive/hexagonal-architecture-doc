using System;
using GtMotive.Estimate.Microservice.Domain.Interfaces.Entities;

namespace GtMotive.Estimate.Microservice.Domain.Entities
{
    public class Rent : IRent
    {
        public string Id { get; set; }

        public string VehicleId { get; set; }

        public DateTime InitialDate { get; set; }

        public DateTime FinalDate { get; set; }

        public DateTime OperationDate { get; set; }

        public void SetId()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
