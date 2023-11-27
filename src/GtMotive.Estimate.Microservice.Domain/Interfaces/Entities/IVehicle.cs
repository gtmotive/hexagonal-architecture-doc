using System;

namespace GtMotive.Estimate.Microservice.Domain.Interfaces.Entities
{
    public interface IVehicle
    {
        string Id { get; }

        string Model { get; set; }

        string Color { get; set; }

        DateTime ManufactureDate { get; set; }

        DateTime PurchaseDate { get; set; }
    }
}
