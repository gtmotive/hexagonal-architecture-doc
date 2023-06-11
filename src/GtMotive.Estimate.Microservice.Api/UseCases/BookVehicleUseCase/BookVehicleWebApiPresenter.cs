using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.BookVehicleUseCase;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.UseCases.BookVehicleUseCase
{
    public class BookVehicleWebApiPresenter : IBookVehicleWebApiPresenter
    {
        public IActionResult ActionResult { get; private set; }

        public void StandardHandle(BookVehicleOutput response)
        {
            ActionResult = new OkObjectResult(BookVehicleMapper.Map(response));
        }

        public void NotFoundHandle(string message)
        {
            ActionResult = new NotFoundObjectResult(message);
        }

        public void BadRequest(string message)
        {
            ActionResult = new BadRequestObjectResult(message);
        }
    }
}
