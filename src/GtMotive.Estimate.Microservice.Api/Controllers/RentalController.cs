using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.Services;
using GtMotive.Estimate.Microservice.Domain.Aggregates;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RentalController : ControllerBase
    {
        private readonly IRentalService _rentalService;

        public RentalController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        [HttpPost("rentVehicle")]
        [ProducesResponseType(typeof(Rental), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RentVehicle(Rental rental)
        {
            try
            {
                var createdRental = await _rentalService.CreateRentalAsync(rental);
                return Ok(createdRental);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("returnRentalVehicle/{rentalId}")]
        [ProducesResponseType(typeof(Rental), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ReturnRentalVehicle(Guid rentalId)
        {
            try
            {
                var rental = await _rentalService.ReturnRentalVehicleAsync(rentalId);
                return rental == null ? NotFound() : Ok(rental);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("getActiveRentals")]
        [ProducesResponseType(typeof(Rental), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Rental>>> GetActiveRentals()
        {
            var rentals = await _rentalService.GetActiveRentals();
            return Ok(rentals);
        }
    }
}
