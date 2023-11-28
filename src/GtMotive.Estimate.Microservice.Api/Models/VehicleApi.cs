using System;

namespace GtMotive.Estimate.Microservice.Api.Models
{
    public class VehicleApi
    {
        public const short VALIDATIONYEARS = 5;

        public string Id { get; set; }

        public string Model { get; set; }

        public string Color { get; set; }

        public DateTime ManufactureDate { get; set; }

        public DateTime PurchaseDate { get; set; }

        public bool IsValidDate => ManufactureDate.AddYears(VALIDATIONYEARS) < DateTime.Now;

        public void SetId()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
