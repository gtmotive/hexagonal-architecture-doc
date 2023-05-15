using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Mime;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.UseCases.CreateVehicle;
using GtMotive.Estimate.Microservice.Api.UseCases.GetAllAvailableVehicles;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GtMotive.Estimate.Microservice.Api.Controllers
{
    [ApiController]
    [ApiExplorerSettings(GroupName = "Fleets")]
    [Route("fleets/{idFleet}/vehicles")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    public class VehiclesController : AppController
    {
        private readonly ILogger<FleetsController> _logger;
        private readonly IMediator _mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="VehiclesController"/> class.
        /// Vehicles Controller Constructor.
        /// </summary>
        /// <param name="logger">Logger.</param>
        /// <param name="mediator">Mediator.</param>
        /// <exception cref="ArgumentNullException">Argument null Exception.</exception>
        public VehiclesController(
            ILogger<FleetsController> logger,
            IMediator mediator)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateAsync(int idFleet, [FromBody][Required] CreateVehicleRequest request)
        {
            request = new CreateVehicleRequest(idFleet, request.Name, request.ModelYear);

            _logger.LogInformation(
                 "----- Sending Request: {RequestName} :  ({@Request})",
                 nameof(CreateVehicleRequest),
                 request);

            var presenter = await _mediator.Send(request);
            return presenter.ActionResult;
        }

        [HttpGet("availables")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllAvailableVehiclesAsync(int idFleet)
        {
            var request = new GetAllAvailableVehiclesRequest(idFleet);

            _logger.LogInformation(
                 "----- Sending Request: {RequestName} :  ({@Request})",
                 nameof(GetAllAvailableVehiclesRequest),
                 request);

            var presenter = await _mediator.Send(request);
            return presenter.ActionResult;
        }
    }
}
