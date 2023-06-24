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
        public IActionResult CreateVehicle([FromBody] Vehicle vehicle)
        {
            try
            {
                _vehicleService.Add(vehicle);
                return Ok();
            }
            catch (BadHttpRequestException ex)
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
        public IActionResult RentVehicle([FromBody] Rental rental)
        {
            try
            {
                var rentedVehicle = _rentalService.Add(rental);
                return Ok(rentedVehicle);
            }
            catch (BadHttpRequestException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Devolver")]
        public IActionResult ReturnVehicle([FromBody] Rental rental)
        {
            try
            {
                _rentalService.Delete(rental);
                return Ok("Vehicle returned successfully.");
            }
            catch (BadHttpRequestException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
