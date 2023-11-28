using System;

namespace GtMotive.Estimate.Microservice.Domain.Interfaces.Entities
{
    public interface IRent
    {
        string Id { get; set; }

        string VehicleId { get; set; }

        string UserId { get; set; }

        DateTime InitialDate { get; set; }

        DateTime? DevolutionDate { get; set; }
    }
}
