using System;
using GtMotive.Estimate.Microservice.ApplicationCore.Dtos;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases;
using GtMotive.Estimate.Microservice.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace GtMotive.Estimate.Microservice.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentingController : ControllerBase
    {
        private readonly IRentalService _rentalService;
        private readonly IVehicleService _vehicleService;

        public RentingController(IRentalService rentalService, IVehicleService vehicleService)
        {
            _rentalService = rentalService;
            _vehicleService = vehicleService;
        }

        [HttpPost("CrearVehiculo")]
        public IActionResult CreateVehicle([FromBody] VehicleDto vehicleDto)
        {
            try
            {
                if (vehicleDto == null)
                {
                    throw new ArgumentException("No se recibieron datos de un vehiculo");
                }

                _vehicleService.Add(new Vehicle(vehicleDto.VehicleId, vehicleDto.Brand, vehicleDto.ManufacturingDate));
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("ListarVehiculos")]
        public IActionResult GetAvailableVehicles()
        {
            try
            {
                var vehicles = _vehicleService.List();
                return Ok(vehicles);
            }
            catch (BadHttpRequestException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Alquilar")]
        public IActionResult RentVehicle([FromBody] RentalDto rentalDto)
        {
            try
            {
                if (rentalDto == null)
                {
                    throw new BadHttpRequestException("No se ha recibido el cuerpo de la petición.");
                }

                // Verificar que se proporcionen vehicleId y clientId
                if (rentalDto.VehicleId == 0 || rentalDto.ClientId == 0)
                {
                    throw new BadHttpRequestException("vehicleId y clientId son campos requeridos.");
                }

                // Crear el objeto Rental a partir de los datos proporcionados e invocar al servicio
                _rentalService.Add(new Rental(rentalDto.VehicleId, rentalDto.ClientId, rentalDto.StartDate, rentalDto.EndDate));

                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (BadHttpRequestException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Devolver")]
        public IActionResult ReturnVehicle([FromBody] RentalDto rentalDto)
        {
            try
            {
                if (rentalDto == null)
                {
                    throw new BadHttpRequestException("No se ha recibido el cuerpo de la petición.");
                }

                // Verificar que se proporcionen vehicleId y clientId
                if (rentalDto.VehicleId == 0 || rentalDto.ClientId == 0)
                {
                    throw new BadHttpRequestException("vehicleId y clientId son campos requeridos.");
                }

                // Crear el objeto Rental a partir de los datos proporcionados e invocar al servicio
                _rentalService.Delete(new Rental(rentalDto.VehicleId, rentalDto.ClientId, rentalDto.StartDate, rentalDto.EndDate));

                return Ok("Vehicle returned successfully.");
            }
            catch (BadHttpRequestException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
