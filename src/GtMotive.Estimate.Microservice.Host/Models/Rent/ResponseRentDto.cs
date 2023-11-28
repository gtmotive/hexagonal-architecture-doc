using System;

namespace GtMotive.Estimate.Microservice.Host.Models.Rent
{
    public class ResponseRentDto
    {
        public string Id { get; set; }

        public string VehicleId { get; set; }

        public int UserId { get; set; }

        public DateTime InitialDate { get; set; }

        public DateTime FinalDate { get; set; }

        public DateTime? DevolutionDate { get; set; }
    }
}
