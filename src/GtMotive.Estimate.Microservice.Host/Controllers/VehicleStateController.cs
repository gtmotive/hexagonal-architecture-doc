using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.Features.Vehicles.Queries.GetAllVehiclesStates;
using GtMotive.Estimate.Microservice.ApplicationCore.Features.VehicleStates.Queries.GetAllVehiclesStates;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Host.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class VehicleStateController : ControllerBase
    {
        /// <summary>
        /// Mediator (MediatR DI).
        /// </summary>
        private readonly IMediator _mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="VehicleStateController"/> class.
        /// </summary>
        /// <param name="mediator">IMediator.</param>
        public VehicleStateController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get all vehicle states.
        /// </summary>
        /// <returns>string test.</returns>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(IEnumerable<VehicleStatesResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<VehicleStatesResponse>>> GetAsync()
        {
            var query = new GetAllVehiclesStatesQuery();
            return Ok(await _mediator.Send(query));
        }
    }
}
