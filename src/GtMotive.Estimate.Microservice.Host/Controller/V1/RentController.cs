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
    public class RentController : ControllerBase
    {
        private readonly IRentRepository rentRepository;
        private readonly IMapper mapper;

        public RentController(IRentRepository rentRepository)
        {
            this.rentRepository = rentRepository;
            mapper = MapperHostRentConfig.Initialize();
        }

        [HttpPost("Create")]
        public IActionResult Create([FromBody] RequestRentDto rentDto)
        {
            try
            {
                if (rentDto == null)
                {
                    return BadRequest("La solicitud no puede ser nula.");
                }

                var rentApi = mapper.Map<RentApi>(rentDto);
                return rentRepository.Create(rentApi) ? Ok() : BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<RentApi>> GetAll()
        {
            var rents = rentRepository.GetAll();
            var responseRentDto = mapper.Map<IEnumerable<ResponseRentDto>>(rents);
            return Ok(responseRentDto);
        }

        [HttpGet("Get/{id}")]
        public ActionResult<RentApi> Get([FromRoute] string id)
        {
            var rentApi = rentRepository.GetById(id);
            var responseRentDto = mapper.Map<ResponseRentDto>(rentApi);
            return Ok(responseRentDto);
        }
    }
}

