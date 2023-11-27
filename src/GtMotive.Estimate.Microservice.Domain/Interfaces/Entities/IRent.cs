using System;

namespace GtMotive.Estimate.Microservice.Domain.Interfaces.Entities
{
    public interface IRent
    {
        string Id { get; }

        string VehicleId { get; set; }

        DateTime InitialDate { get; set; }

        DateTime FinalDate { get; set; }

        DateTime OperationDate { get; set; }
    }
}
