using System;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.Interfaces.Cruds;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases
{
    /// <summary>
    /// Rental services.
    /// </summary>
    public interface IRentalService
        : IAddable<Rental>, IListable<Rental, Guid>, IDeletable<Rental>
    {
    }
}
