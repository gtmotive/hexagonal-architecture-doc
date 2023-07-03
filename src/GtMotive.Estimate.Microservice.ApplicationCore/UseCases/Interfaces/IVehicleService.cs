using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.Interfaces.Cruds;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases
{
    /// <summary>
    /// Service base.
    /// </summary>
    public interface IVehicleService
        : IAddable<Vehicle>, IListable<Vehicle>
    {
    }
}
