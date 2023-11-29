using System;
using System.Collections.Generic;
using AutoMapper;
using GtMotive.Estimate.Microservice.Api.Interfaces;
using GtMotive.Estimate.Microservice.Api.Models;
using GtMotive.Estimate.Microservice.Host.Mappers;
using GtMotive.Estimate.Microservice.Host.Models.Rent;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Host.Controller.V1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class RentController : ControllerBase
    {
        private readonly IRentBusiness rentRepository;
        private readonly IMapper mapper;

        public RentController(IRentBusiness rentRepository)
        {
            this.rentRepository = rentRepository;
            mapper = MapperHostRentConfig.Initialize();
        }

        [HttpPost("Create")]
        public IActionResult Create([FromBody] RequestRentDto requestRentDto)
        {
            try
            {
                if (requestRentDto == null)
                {
                    return BadRequest("La solicitud no puede ser nula.");
                }

                var rentApi = mapper.Map<RentApi>(requestRentDto);
                var result = rentRepository.Create(rentApi);
                return result.IsSuccess ? Ok(rentApi) : BadRequest(result.ErrorMessage);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpPost("Devolution")]
        public IActionResult Devolution([FromBody] RequestIdRentDto requestIdRentDto)
        {
            try
            {
                if (requestIdRentDto == null)
                {
                    return BadRequest("La solicitud no puede ser nula.");
                }

                var result = rentRepository.Devolution(requestIdRentDto.Id);
                if (result.IsError)
                {
                    return BadRequest(result.ErrorMessage);
                }
                else
                {
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<RentApi>> GetAll()
        {
            try
            {
                var result = rentRepository.GetAll();
                var responseRentDto = mapper.Map<IEnumerable<ResponseRentDto>>(result.Data);
                return Ok(responseRentDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpGet("Get/{id}")]
        public ActionResult<RentApi> Get([FromRoute] string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    return BadRequest("La solicitud no puede ser nula.");
                }

                var result = rentRepository.GetById(id);
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

