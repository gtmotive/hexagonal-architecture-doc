using System;
using System.Linq;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.GetAllAvailableVehicles;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.UseCases.GetAllAvailableVehicles
{
    public class GetAllAvailableVehiclesPresenter
        : IGetAllAvailableVehiclesPresenter, IGetAllAvailableVehiclesOutputPort
    {
        public IActionResult ActionResult
        {
            get;
            private set;
        }

        public void NotFoundHandle(string message) => ActionResult = new NotFoundObjectResult(message);

        public void StandardHandle(GetAllAvailableVehiclesOutput response)
        {
            if (response == null)
            {
                throw new ArgumentNullException(nameof(response));
            }

            var viewModel = response.Items?.Select(item => new AvailableVehicleResponse(item.Id, item.Name.Text, item.ModelYear));
            ActionResult = new OkObjectResult(viewModel);
        }
    }
}
