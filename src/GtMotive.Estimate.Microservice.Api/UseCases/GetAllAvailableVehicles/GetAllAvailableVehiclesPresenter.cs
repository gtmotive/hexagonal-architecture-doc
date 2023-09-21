using System.Linq;
using GtMotive.Estimate.Microservice.Api.Filters;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.GetAllAvailableVehicles;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.UseCases.GetAllAvailableVehicles
{
    public class GetAllAvailableVehiclesPresenter : IGetAllAvailableVehiclesPresenter, IGetAvailableVehiclesOutputPort
    {
        public IActionResult ActionResult
        {
            get; set;
        }

        public void ExceptionHandle(string message)
        {
            ActionResult = new InternalServerErrorObjectResult(message);
        }

        public void StandardHandle(GetAvailableVehiclesOutput output)
        {
            var response = output == null
                ? new()
                : output.VehicleList
                                .Select(o => new GetAllAvailableVehiclesResponse(o.Id, o.Fleet, o.Brand, o.Model, o.ManufacturingDate, o.IsRental))
                                .ToList();

            ActionResult = new OkObjectResult(response);
        }
    }
}
