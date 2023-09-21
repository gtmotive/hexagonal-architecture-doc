using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.UseCases.RentVehicle;
using GtMotive.Estimate.Microservice.Api.UseCases.ReturnVehicle;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.Controllers
{
    [ApiController]
    [Route("api/")]
    public class RentingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RentingController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost("RentVehicle")]
        public async Task<IActionResult> RentVehicle([FromBody] RentVehicleRequest request)
        {
            var result = await _mediator.Send(request);
            return result.ActionResult;
        }

        [HttpPut("ReturnVehicle/{rentalId}")]
        public async Task<IActionResult> ReturnVehicle(Guid rentalId)
        {
            var request = new ReturnVehicleRequest(rentalId);
            var result = await _mediator.Send(request);
            return result.ActionResult;
        }
    }
}
