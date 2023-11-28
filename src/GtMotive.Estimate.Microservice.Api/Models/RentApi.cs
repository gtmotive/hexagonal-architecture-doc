using System;

namespace GtMotive.Estimate.Microservice.Api.Models
{
    public class RentApi
    {
        public string Id { get; set; }

        public string VehicleId { get; set; }

        public string UserId { get; set; }

        public DateTime InitialDate { get; set; }

        public DateTime? DevolutionDate { get; set; }

        public bool IsReturned => DevolutionDate.HasValue;

        public void SetId()
        {
            Id = Guid.NewGuid().ToString();
        }

        public void SetInitialDate()
        {
            InitialDate = DateTime.Now;
        }
    }
}
