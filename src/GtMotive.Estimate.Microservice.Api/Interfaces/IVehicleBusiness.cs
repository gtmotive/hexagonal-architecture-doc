using System.Collections.Generic;
using GtMotive.Estimate.Microservice.Api.Action;
using GtMotive.Estimate.Microservice.Api.Models;

namespace GtMotive.Estimate.Microservice.Api.Interfaces
{
    public interface IVehicleBusiness
    {
        Result<VehicleApi> GetById(string id);

        Result<IEnumerable<VehicleApi>> GetAll();

        Result<VehicleApi> Create(VehicleApi vehicleApi);

        IEnumerable<VehicleApi> GetAvailables();
    }
}
