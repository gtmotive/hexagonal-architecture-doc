using System;

namespace GtMotive.Estimate.Microservice.Api.UseCases.GetAllAvailableVehiclesUseCase
{
    public record VehicleDto(Guid Id, DateTime ManufacturingDate, string ModelName, string ModelBrand);
}
