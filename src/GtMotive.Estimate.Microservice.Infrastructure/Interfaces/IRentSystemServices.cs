using System.Collections.Generic;
using GtMotive.Estimate.Microservice.Domain.Entities;

namespace GtMotive.Estimate.Microservice.Infrastructure.Interfaces
{
    public interface IRentSystemServices
    {
        string Folder { get; set; }

        bool CreateRent(Rent rent);
        IEnumerable<Rent> GetCollectionRents();
    }
}