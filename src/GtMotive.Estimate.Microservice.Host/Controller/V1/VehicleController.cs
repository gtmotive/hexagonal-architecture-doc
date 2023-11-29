using System;
using System.Collections.Generic;
using AutoMapper;
using GtMotive.Estimate.Microservice.Api.Interfaces;
using GtMotive.Estimate.Microservice.Api.Models;
using GtMotive.Estimate.Microservice.Host.Mappers;
using GtMotive.Estimate.Microservice.Host.Models.Vehicle;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Host.Controller.V1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleBusiness vehicleRepository;
        private readonly IMapper mapper;

        public VehicleController(IVehicleBusiness vehicleRepository)
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
                var result = vehicleRepository.Create(vehicleApi);
                return result.IsSuccess ? Ok(vehicleApi) : BadRequest(result.ErrorMessage);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpGet("GetAvailables")]
        public ActionResult<IEnumerable<RequestVehicleDto>> GetAvailables()
        {
            try
            {
                var vehicles = vehicleRepository.GetAvailables();
                var responseVehicleDto = mapper.Map<IEnumerable<ResponseVehicleDto>>(vehicles);
                return Ok(responseVehicleDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<VehicleApi>> GetAll()
        {
            try
            {
                var result = vehicleRepository.GetAll();
                var responseVehicleDto = mapper.Map<IEnumerable<ResponseVehicleDto>>(result.Data);
                return Ok(responseVehicleDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpGet("Get/{id}")]
        public ActionResult<ResponseVehicleDto> Get([FromRoute] string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    return BadRequest("La solicitud no puede ser nula.");
                }

                var result = vehicleRepository.GetById(id);
                if (result.IsError)
                {
                    return BadRequest(result.ErrorMessage);
                }
                else
                {
                    return Ok(result.Data);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }
    }
}
