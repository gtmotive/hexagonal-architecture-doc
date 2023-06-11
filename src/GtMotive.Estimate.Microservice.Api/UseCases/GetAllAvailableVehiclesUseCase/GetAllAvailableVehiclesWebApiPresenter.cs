using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.GetAllAvailableVehiclesUseCase;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.UseCases.GetAllAvailableVehiclesUseCase
{
    public class GetAllAvailableVehiclesWebApiPresenter : IGetAllAvailableVehiclesWebApiPresenter
    {
        public IActionResult ActionResult { get; private set; }

        public void StandardHandle(GetAllAvailableVehiclesOutput response)
        {
            ActionResult = new OkObjectResult(GetAllAvailableVehiclesMapper.Map(response));
        }
    }
}
