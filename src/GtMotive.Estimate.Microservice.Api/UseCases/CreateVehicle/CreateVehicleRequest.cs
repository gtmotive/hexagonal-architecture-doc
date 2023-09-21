using System;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.CreateVehicle
{
    public class CreateVehicleRequest : IRequest<ICreateVehiclePresenter>
    {
        public CreateVehicleRequest(Guid fleet, string brand, string model, DateTime manufacturingDate, bool isRental)
        {
            Fleet = fleet;
            Brand = brand;
            Model = model;
            ManufacturingDate = manufacturingDate;
            IsRental = isRental;
        }

        public Guid Fleet { get; private set; }

        public string Brand { get; private set; }

        public string Model { get; private set; }

        public DateTime ManufacturingDate { get; private set; }

        public bool IsRental { get; private set; }
    }
}
