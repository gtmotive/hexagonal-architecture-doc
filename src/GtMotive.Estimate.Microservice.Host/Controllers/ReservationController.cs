using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.Features.Reservation.Commands.CreateReservation;
using GtMotive.Estimate.Microservice.ApplicationCore.Features.Reservation.Commands.DeleteReservation;
using GtMotive.Estimate.Microservice.ApplicationCore.Features.Reservation.Queries.GetAllReservations;
using GtMotive.Estimate.Microservice.ApplicationCore.Features.Vehicles.Queries.GetAllReservations;
using GtMotive.Estimate.Microservice.Domain.Entities.Auth;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Host.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationController : ControllerBase
    {
        /// <summary>
        /// Mediator (MediatR DI).
        /// </summary>
        private readonly IMediator _mediator;

        /// <summary>
        /// Auth user manager.
        /// </summary>
        private readonly UserManager<User> _userManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReservationController"/> class.
        /// </summary>
        /// <param name="mediator">IMediator.</param>
        /// <param name="userManager">UserManager.</param>
        public ReservationController(IMediator mediator, UserManager<User> userManager)
        {
            _mediator = mediator;
            _userManager = userManager;
        }

        /// <summary>
        /// Get all vehicle reservations.
        /// </summary>
        /// <returns>List ReservationResponse.</returns>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(IEnumerable<ReservationResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ReservationResponse>>> GetAsync()
        {
            var query = new GetAllReservationsQuery();
            return Ok(await _mediator.Send(query));
        }

        /// <summary>
        /// Create new vehicle reservation using authenticated user.
        /// </summary>
        /// <param name="command">Vehicle Reservation request.</param>
        /// <returns>Id (int).</returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<int>> CreateReservationAsync([Required] CreateReservationCommand command)
        {
            var userInfo = await _userManager.FindByEmailAsync(User.Identity.Name);
            if (userInfo == null || command == null)
            {
                return BadRequest();
            }

            command.UserId = userInfo.Id;
            var response = await _mediator.Send(command);
            return response != null ? (ActionResult<int>)Ok(response) : (ActionResult<int>)BadRequest();
        }

        /// <summary>
        /// Delete vehicle reservation.
        /// </summary>
        /// <param name="id">Delete Vehicle Reservation Id.</param>
        /// <returns>bool.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<int>> DeleteReservationAsync([Required] int id)
        {
            DeleteReservationCommand command = new() { Id = id };
            var response = await _mediator.Send(command);
            return response ? (ActionResult<int>)Ok(response) : (ActionResult<int>)BadRequest();
        }
    }
}
