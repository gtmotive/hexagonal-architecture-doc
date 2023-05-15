using System;
using GtMotive.Estimate.Microservice.Api.Application.CreateFleet;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateFleet;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.UseCases.CreateFleet
{
    public class CreateFleetPresenter
        : ICreateFleetPresenter, ICreateFleetOutputPort
    {
        public IActionResult ActionResult
        {
            get;
            private set;
        }

        public void StandardHandle(CreateFleetOutput response)
        {
            if (response == null)
            {
                throw new ArgumentNullException(nameof(response));
            }

            var viewModel = new CreateFleetResponse(response.Id, response.Name);
            ActionResult = new CreatedAtRouteResult(new { viewModel.Id }, viewModel);
        }
    }
}
