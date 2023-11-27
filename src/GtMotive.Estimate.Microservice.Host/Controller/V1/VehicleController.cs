using System;
using System.Collections.Generic;
using AutoMapper;
using GtMotive.Estimate.Microservice.Api.Interfaces;
using GtMotive.Estimate.Microservice.Api.Models;
using GtMotive.Estimate.Microservice.Host.Mappers;
using GtMotive.Estimate.Microservice.Host.Models;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Host.Controller.V1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleRepository vehicleRepository;
        private readonly IMapper mapper;

        public VehicleController(IVehicleRepository vehicleRepository)
        {
            this.vehicleRepository = vehicleRepository;
            mapper = MapperHostVehicleConfig.Initialize();
        }

        [HttpPost("Create")]
        public IActionResult Create([FromBody] RequestVehicleDto vehicleDto)
        {
            try
            {
                if (vehicleDto == null)
                {
                    return BadRequest("La solicitud no puede ser nula.");
                }

                var vehicleApi = mapper.Map<VehicleApi>(vehicleDto);
                return vehicleRepository.Create(vehicleApi) ? Ok() : BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<RequestVehicleDto>> GetAll()
        {
            var vehicles = vehicleRepository.GetAll();
            var responseVehicleDto = mapper.Map<IEnumerable<ResponseVehicleDto>>(vehicles);
            return Ok(responseVehicleDto);
        }

        [HttpGet("GetAvailables")]
        public ActionResult<IEnumerable<RequestVehicleDto>> GetAvailables()
        {
            var vehicles = vehicleRepository.GetAvailables();
            var responseVehicleDto = mapper.Map<IEnumerable<ResponseVehicleDto>>(vehicles);
            return Ok(responseVehicleDto);
        }

        [HttpGet("Get/{id}")]
        public ActionResult<ResponseVehicleDto> Get([FromRoute] string id)
        {
            var vehicleApi = vehicleRepository.GetById(id);
            var responseVehicleDto = mapper.Map<ResponseVehicleDto>(vehicleApi);
            return Ok(responseVehicleDto);
        }
    }
}
