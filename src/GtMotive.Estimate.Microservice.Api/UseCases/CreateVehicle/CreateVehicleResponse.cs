using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateVehicle
{
    public class CreateVehicleResponse
    {
        public CreateVehicleResponse(Guid id, Guid fleet, string brand, string model, DateTime manufacturingDate, bool isRental)
        {
            Id = id;
            Fleet = fleet;
            Brand = brand;
            Model = model;
            ManufacturingDate = manufacturingDate;
            IsRental = isRental;
        }

        public Guid Id { get; private set; }

        public Guid Fleet { get; private set; }

        public string Brand { get; private set; }

        public string Model { get; private set; }

        public DateTime ManufacturingDate { get; private set; }

        public bool IsRental { get; private set; }
    }
}
