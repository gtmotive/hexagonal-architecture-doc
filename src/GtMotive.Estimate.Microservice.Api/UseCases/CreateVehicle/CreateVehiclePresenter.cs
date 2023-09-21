using System;
using GtMotive.Estimate.Microservice.Api.Filters;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateVehicle;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.UseCases.CreateVehicle
{
    public class CreateVehiclePresenter : ICreateVehiclePresenter, ICreateVehicleOutputPort
    {
        public IActionResult ActionResult
        {
            get; private set;
        }

        public void ExceptionHandle(string message)
        {
            ActionResult = new InternalServerErrorObjectResult(message);
        }

        public void StandardHandle(CreateVehicleOutput output)
        {
            if (output == null)
            {
                throw new ArgumentNullException(nameof(output));
            }

            var response = new CreateVehicleResponse(output.Id, output.Fleet, output.Brand, output.Model, output.ManufacturingDate, output.IsRental);

            ActionResult = new OkObjectResult(response);
        }
    }
}
