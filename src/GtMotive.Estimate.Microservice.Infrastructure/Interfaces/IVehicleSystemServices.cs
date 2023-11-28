using System.Collections.Generic;
using GtMotive.Estimate.Microservice.Domain.Entities;

namespace GtMotive.Estimate.Microservice.Infrastructure.Interfaces
{
    public interface IVehicleSystemServices
    {
        string Folder { get; set; }

        bool CreateVehicle(Vehicle vehicle);
        IEnumerable<Vehicle> GetCollectionVehicles();
    }
}