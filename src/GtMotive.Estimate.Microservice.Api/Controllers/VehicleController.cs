using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.UseCases.CreateVehicle;
using GtMotive.Estimate.Microservice.Api.UseCases.GetAllAvailableVehicles;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.Controllers
{
    [ApiController]
    [Route("api/")]
    public class VehicleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VehicleController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost("CreateVehicle")]
        public async Task<IActionResult> CreateVehicle([FromBody] CreateVehicleRequest request)
        {
            var result = await _mediator.Send(request);
            return result.ActionResult;
        }

        [HttpGet("GetAllAvailableVehicles")]
        public async Task<IActionResult> GetAllAvailableVehicles(Guid idFleet)
        {
            var request = new GetAllAvailableVehiclesRequest(idFleet);
            var result = await _mediator.Send(request);
            return result.ActionResult;
        }
    }
}
