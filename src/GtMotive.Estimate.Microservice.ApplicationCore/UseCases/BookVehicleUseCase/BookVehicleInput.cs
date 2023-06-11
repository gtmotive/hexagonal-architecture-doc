using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.BookVehicleUseCase
{
    public record BookVehicleInput(Guid CustomerId, Guid VehicleId, DateOnly ReturnDate) : IUseCaseInput;
}
