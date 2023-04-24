using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.Features.Vehicles.Commands.CreateVehicle;
using GtMotive.Estimate.Microservice.ApplicationCore.Features.Vehicles.Common;
using GtMotive.Estimate.Microservice.ApplicationCore.Features.Vehicles.Queries.GetAllVehicles;
using GtMotive.Estimate.Microservice.ApplicationCore.Features.Vehicles.Queries.GetVehicleById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Host.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class VehicleController : ControllerBase
    {
        /// <summary>
        /// Mediator (MediatR DI).
        /// </summary>
        private readonly IMediator _mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="VehicleController"/> class.
        /// </summary>
        /// <param name="mediator">IMediator.</param>
        public VehicleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get all available and not expired vehicles.
        /// </summary>
        /// <returns>List VehicleResponse.</returns>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(IEnumerable<VehicleResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<VehicleResponse>>> GetAsync()
        {
            var query = new GetAllVehiclesQuery();
            return Ok(await _mediator.Send(query));
        }

        /// <summary>
        /// Get vehicle information by id.
        /// </summary>
        /// <param name="id">Vehicle id.</param>
        /// <returns>VehicleResponse.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VehicleResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<VehicleResponse>> GetByIdAsync([Required] int id)
        {
            var query = new GetVehicleByIdQuery() { Id = id };
            var data = await _mediator.Send(query);
            return data != null ? (ActionResult<VehicleResponse>)Ok(data) : (ActionResult<VehicleResponse>)NotFound();
        }

        /// <summary>
        /// Create new vehicle.
        /// </summary>
        /// <param name="command">Vehicle request.</param>
        /// <returns>VehicleResponse.</returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<VehicleResponse>> CreateVehicleAsync([Required] CreateVehicleCommand command)
        {
            var response = await _mediator.Send(command);
            return response != null ? (ActionResult<VehicleResponse>)Ok(response) : (ActionResult<VehicleResponse>)BadRequest();
        }
    }
}
