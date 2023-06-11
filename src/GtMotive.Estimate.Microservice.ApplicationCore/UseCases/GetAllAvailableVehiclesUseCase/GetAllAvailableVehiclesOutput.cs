using System.Collections.Generic;
using GtMotive.Estimate.Microservice.Domain.Aggregates.VehicleAggregate;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.GetAllAvailableVehiclesUseCase
{
    public record GetAllAvailableVehiclesOutput(IEnumerable<Vehicle> Vehicles) : IUseCaseOutput;
}
