using System;
using GtMotive.Estimate.Microservice.Api.Filters;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ReturnVehicle;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.UseCases.ReturnVehicle
{
    public class ReturnVehiclePresenter : IReturnVehiclePresenter, IReturnVehicleOutputPort
    {
        public IActionResult ActionResult
        {
            get; private set;
        }

        public void ExceptionHandle(string message)
        {
            ActionResult = new InternalServerErrorObjectResult(message);
        }

        public void StandardHandle(ReturnVehicleOutput output)
        {
            if (output == null)
            {
                throw new ArgumentNullException(nameof(output));
            }

            ActionResult = new OkObjectResult(new ReturnVehicleResponse(output.Message));
        }
    }
}
