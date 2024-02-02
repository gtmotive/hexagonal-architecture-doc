using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.Services;
using GtMotive.Estimate.Microservice.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehiclesController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;

        public VehiclesController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [HttpPost("addVehicletoFleet")]
        [ProducesResponseType(typeof(Vehicle), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Vehicle>> AddVehicleToFleet(Vehicle vehicle)
        {
            try
            {
                var addedVehicle = await _vehicleService.AddVehicleAsync(vehicle);
                return Ok(addedVehicle);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("getAllAvailableVehicles")]
        [ProducesResponseType(typeof(Vehicle), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Vehicle>>> GetAllAvailableVehicles()
        {
            var vehicles = await _vehicleService.GetAllAvailableVehiclesAsync();
            return Ok(vehicles);
        }
    }
}
