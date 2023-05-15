using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Mime;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.UseCases.CreateRental;
using GtMotive.Estimate.Microservice.Api.UseCases.DeleteRental;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GtMotive.Estimate.Microservice.Api.Controllers
{
    [ApiController]
    [ApiExplorerSettings(GroupName = "Rentals")]
    [Route("[controller]")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    public class RentalsController : AppController
    {
        private readonly ILogger<FleetsController> _logger;
        private readonly IMediator _mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="RentalsController"/> class.
        /// Fleet Controller Constructor.
        /// </summary>
        /// <param name="logger">Logger.</param>
        /// <param name="mediator">Mediator.</param>
        /// <exception cref="ArgumentNullException">Argument null Exception.</exception>
        public RentalsController(
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
        public async Task<IActionResult> CreateAsync([FromBody][Required] CreateRentalRequest request)
        {
            _logger.LogInformation(
                 "----- Sending command: {RequestName} :  ({@Request})",
                 nameof(CreateRentalRequest),
                 request);

            var presenter = await _mediator.Send(request);
            return presenter.ActionResult;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var request = new DeleteRentalRequest(id);

            _logger.LogInformation(
                 "----- Sending command: {RequestName} :  ({@Request})",
                 nameof(DeleteRentalRequest),
                 request);

            var presenter = await _mediator.Send(request);
            return presenter.ActionResult;
        }
    }
}
