using System.Collections.Generic;
using GtMotive.Estimate.Microservice.Api.Action;
using GtMotive.Estimate.Microservice.Api.Models;

namespace GtMotive.Estimate.Microservice.Api.Interfaces
{
    public interface IRentBusiness
    {
        Result<RentApi> GetById(string id);

        Result<IEnumerable<RentApi>> GetAll();

        Result<RentApi> Create(RentApi rentDto);

        SimpleResult Devolution(string id);
    }
}
