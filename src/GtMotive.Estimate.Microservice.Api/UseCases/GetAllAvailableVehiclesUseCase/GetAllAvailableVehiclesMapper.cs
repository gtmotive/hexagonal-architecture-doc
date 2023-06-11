using System;
using System.Linq;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.GetAllAvailableVehiclesUseCase;

namespace GtMotive.Estimate.Microservice.Api.UseCases.GetAllAvailableVehiclesUseCase
{
    public static class GetAllAvailableVehiclesMapper
    {
        public static GetAllAvailableVehiclesResponse Map(GetAllAvailableVehiclesOutput src)
        {
            return src is null
                ? throw new ArgumentNullException(nameof(src))
                : new GetAllAvailableVehiclesResponse(src.Vehicles
                    .Select(item => new VehicleDto(item.Id, item.ManufacturingDate.ToDateTime(default), item.Model.Name, item.Model.Brand)));
        }
    }
}
