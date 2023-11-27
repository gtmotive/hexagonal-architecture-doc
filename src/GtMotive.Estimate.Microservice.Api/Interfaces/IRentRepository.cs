using System.Collections.Generic;
using GtMotive.Estimate.Microservice.Api.Models;

namespace GtMotive.Estimate.Microservice.Api.Interfaces
{
    public interface IRentRepository
    {
        RentApi GetById(string id);

        IEnumerable<RentApi> GetAll();

        bool Create(RentApi rentDto);
    }
}
