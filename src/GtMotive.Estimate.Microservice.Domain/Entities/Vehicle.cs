using System;
using GtMotive.Estimate.Microservice.Domain.Interfaces.Entities;

namespace GtMotive.Estimate.Microservice.Domain.Entities
{
    public class Vehicle : IVehicle
    {
        public string Id { get; set; }

        public string Model { get; set; }

        public string Color { get; set; }

        public DateTime ManufactureDate { get; set; }

        public DateTime PurchaseDate { get; set; }
    }
}
