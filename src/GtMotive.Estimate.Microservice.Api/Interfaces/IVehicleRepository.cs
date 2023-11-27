using System.Collections.Generic;
using GtMotive.Estimate.Microservice.Api.Models;

namespace GtMotive.Estimate.Microservice.Api.Interfaces
{
    public interface IVehicleRepository
    {
        bool Create(VehicleApi vehicleApi);

        VehicleApi GetById(string id);

        IEnumerable<VehicleApi> GetAll();

        IEnumerable<VehicleApi> GetAvailables();
    }
}
