using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.Interfaces.Repositories;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Interfaces.Repositories
{
    /// <summary>
    /// Vehicle Repository.
    /// </summary>
    public interface IVehicleRepository
        : IRepository<Vehicle>
    {
    }
}
