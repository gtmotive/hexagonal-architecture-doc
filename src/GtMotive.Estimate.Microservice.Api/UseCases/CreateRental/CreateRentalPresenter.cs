using System;
using GtMotive.Estimate.Microservice.Api.Application.CreateRental;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateRental;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.UseCases.CreateRental
{
    public class CreateRentalPresenter
        : ICreateRentalPresenter, ICreateRentalOutputPort
    {
        public IActionResult ActionResult
        {
            get;
            private set;
        }

        public void NotFoundHandle(string message) => ActionResult = new NotFoundObjectResult(message);

        public void BadRequestHandle(string message) => ActionResult = new BadRequestObjectResult(message);

        public void StandardHandle(CreateRentalOutput response)
        {
            if (response == null)
            {
                throw new ArgumentNullException(nameof(response));
            }

            var viewModel = new CreateRentalResponse(response.Id, response.Date);
            ActionResult = new CreatedAtRouteResult(new { viewModel.Id }, viewModel);
        }
    }
}
