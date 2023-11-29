using System;

namespace GtMotive.Estimate.Microservice.Host.Models.Vehicle
{
    public abstract class VehicleDto
    {
        public string Model { get; set; }

        public string Color { get; set; }

        public DateTime ManufactureDate { get; set; }

        public DateTime PurchaseDate { get; set; }
    }
}
