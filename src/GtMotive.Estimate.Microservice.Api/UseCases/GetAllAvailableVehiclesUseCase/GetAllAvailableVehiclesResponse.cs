using System.Collections.Generic;

namespace GtMotive.Estimate.Microservice.Api.UseCases.GetAllAvailableVehiclesUseCase
{
    public record GetAllAvailableVehiclesResponse(IEnumerable<VehicleDto> Vehicles);
}
