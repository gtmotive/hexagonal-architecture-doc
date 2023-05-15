using System;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateVehicle;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.UseCases.CreateVehicle
{
    public class CreateVehiclePresenter
        : ICreateVehiclePresenter, ICreateVehicleOutputPort
    {
        public IActionResult ActionResult
        {
            get;
            private set;
        }

        public void BadRequestHandle(string message) => ActionResult = new BadRequestObjectResult(message);

        public void NotFoundHandle(string message) => ActionResult = new NotFoundObjectResult(message);

        public void StandardHandle(CreateVehicleOutput response)
        {
            if (response == null)
            {
                throw new ArgumentNullException(nameof(response));
            }

            var viewModel = new CreateVehicleResponse(response.Id, response.Name, response.ModelYear);
            ActionResult = new CreatedAtRouteResult(new { viewModel.Id }, viewModel);
        }
    }
}
