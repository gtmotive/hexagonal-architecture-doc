using System;
using GtMotive.Estimate.Microservice.Api.Application.DeleteRental;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.DeleteRental;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.UseCases.DeleteRental
{
    public class DeleteRentalPresenter
        : IDeleteRentalPresenter, IDeleteRentalOutputPort
    {
        public IActionResult ActionResult
        {
            get;
            private set;
        }

        public void NotFoundHandle(string message) => ActionResult = new NotFoundObjectResult(message);

        public void StandardHandle(DeleteRentalOutput response)
        {
            if (response == null)
            {
                throw new ArgumentNullException(nameof(response));
            }

            var viewModel = new DeleteRentalResponse(response.VehicleId, response.IsAvailable);
            ActionResult = new OkObjectResult(viewModel);
        }
    }
}
