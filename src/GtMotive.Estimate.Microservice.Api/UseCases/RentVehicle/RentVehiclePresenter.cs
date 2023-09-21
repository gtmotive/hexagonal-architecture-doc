using System;
using GtMotive.Estimate.Microservice.Api.Filters;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.RentVehicle;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.UseCases.RentVehicle
{
    public class RentVehiclePresenter : IRentVehiclePresenter, IRentVehicleOutputPort
    {
        public IActionResult ActionResult
        {
            get; private set;
        }

        public void ExceptionHandle(string message)
        {
            ActionResult = new InternalServerErrorObjectResult(message);
        }

        public void NotFoundHandle(string message)
        {
            ActionResult = new NotFoundObjectResult(message);
        }

        public void StandardHandle(RentVehicleOutput output)
        {
            if (output == null)
            {
                throw new ArgumentNullException(nameof(output));
            }

            var response = new RentVehicleResponse(output.Id, output.VehicleId, output.StartTime, output.EndTime, output.ClientIdCard);
            ActionResult = new OkObjectResult(response);
        }
    }
}
