using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.DTOs;
using GtMotive.Estimate.Microservice.ApplicationCore.Services;
using GtMotive.Estimate.Microservice.Domain.Aggregates;
using GtMotive.Estimate.Microservice.Domain.ValueObjects;
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
        public async Task<ActionResult<VehicleListDto>> AddVehicleToFleet(VehicleAddDto vehicleDto)
        {
            if (vehicleDto == null)
            {
                return BadRequest("Vehicle data is required.");
            }

            try
            {
                var vehicle = new Vehicle(
                    new LicensePlate(vehicleDto.LicensePlate),
                    new Make(vehicleDto.Make),
                    new Model(vehicleDto.Model),
                    new ManufactureYear(vehicleDto.ManufactureYear));

                var addedVehicle = await _vehicleService.AddVehicleAsync(vehicle);

                var resultDto = new VehicleListDto
                {
                    VehicleId = addedVehicle.VehicleId,
                    LicensePlate = addedVehicle.LicensePlate.Value,
                    Make = addedVehicle.Make.Value,
                    Model = addedVehicle.Model.Value,
                    ManufactureYear = addedVehicle.ManufactureYear.Value,
                    IsAvailable = addedVehicle.IsAvailable
                };

                return Ok(resultDto);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("getAllAvailableVehicles")]
        [ProducesResponseType(typeof(Vehicle), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<VehicleListDto>>> GetAllAvailableVehicles()
        {
            var vehicles = await _vehicleService.GetAllAvailableVehiclesAsync();

            var vehicleDtos = vehicles.Select(v => new VehicleListDto
            {
                VehicleId = v.VehicleId,
                LicensePlate = v.LicensePlate.Value,
                Make = v.Make.Value,
                Model = v.Model.Value,
                ManufactureYear = v.ManufactureYear.Value,
                IsAvailable = v.IsAvailable
            }).ToList();

            return Ok(vehicleDtos);
        }
    }
}
