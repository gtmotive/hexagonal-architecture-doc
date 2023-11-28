using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using GtMotive.Estimate.Microservice.Api.Action;
using GtMotive.Estimate.Microservice.Api.Interfaces;
using GtMotive.Estimate.Microservice.Api.Mappers;
using GtMotive.Estimate.Microservice.Api.Models;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Infrastructure.Interfaces;

namespace GtMotive.Estimate.Microservice.Api.Repository
{
    public class RentBusiness : IRentBusiness
    {
        private readonly IMapper mapper;
        private readonly IRentSystemServices rentSystemServices;

        public RentBusiness(IRentSystemServices fileSystemService)
        {
            mapper = MapperRentConfig.Initialize();
            rentSystemServices = fileSystemService;
        }

        public Result<RentApi> Create(RentApi rentDto)
        {
            var result = new Result<RentApi>();

            var resultVehicle = GetByIdVehicle(rentDto?.VehicleId);
            if (resultVehicle == null)
            {
                result = CreateElement(rentDto);
            }
            else
            {
                if (resultVehicle.IsReturned)
                {
                    // El usuario tiene otro vehiculo?
                    if (UserHasAnotherReserve(rentDto?.UserId))
                    {
                        result.Error($"El usuario {rentDto?.UserId} ya tiene una reserva con vehículo id {resultVehicle.Id}");
                        return result;
                    }
                    else
                    {
                        result = CreateElement(rentDto);
                    }
                }
                else
                {
                    result.Error($"El vehículo {rentDto?.VehicleId} no esta disponible para el alquiler");
                }
            }

            result.Error($"El vehículo con id {rentDto?.Id} no está disponible");
            return result;
        }

        public SimpleResult Devolution(string id)
        {
            var result = new SimpleResult();

            var resultRentApi = GetByIdElement(id);
            if (resultRentApi == null)
            {
                result.Error("No se ha podido registrar la devolución.");
            }
            else
            {
                if (resultRentApi.IsReturned)
                {
                    result.Error("El vehículo ya tiene una devolución realizada.");
                }
                else
                {
                    resultRentApi.DevolutionDate = System.DateTime.Now;
                    var rent = mapper.Map<Rent>(resultRentApi);

                    if (rentSystemServices.CreateRent(rent))
                    {
                        result.Ok();
                    }
                    else
                    {
                        result.Error("No se ha podido registrar la devolución.");
                    }
                }
            }

            return result;
        }

        public Result<IEnumerable<RentApi>> GetAll()
        {
            var result = new Result<IEnumerable<RentApi>>();
            var rentApis = GetAllList();

            result.Ok(rentApis);
            return result;
        }

        public Result<RentApi> GetById(string id)
        {
            var result = new Result<RentApi>();
            var rent = GetByIdElement(id);
            if (rent == null)
            {
                result.Error($"No hay reservas para el vehículo con id : {id}");
            }
            else
            {
                var resultRentApi = mapper.Map<RentApi>(rent);
                result.Ok(resultRentApi);
            }

            return result;
        }

        private Result<RentApi> CreateElement(RentApi rentApi)
        {
            var result = new Result<RentApi>();
            rentApi.SetId();
            rentApi.SetInitialDate();
            var rent = mapper.Map<Rent>(rentApi);
            if (rentSystemServices.CreateRent(rent))
            {
                var rentApiOk = mapper.Map<RentApi>(rent);
                result.Ok(rentApiOk);
            }
            else
            {
                result.Error("No es posible rentar el vehículo");
            }

            return result;
        }

        private List<RentApi> GetAllList()
        {
            var rentApis = new List<RentApi>();
            foreach (var item in rentSystemServices.GetCollectionRents())
            {
                var rentDto = mapper.Map<RentApi>(item);
                rentApis.Add(rentDto);
            }

            return rentApis;
        }

        private RentApi GetByIdElement(string id)
        {
            var rent = rentSystemServices.GetCollectionRents().FirstOrDefault(c => c.Id == id);
            var rentApi = mapper.Map<RentApi>(rent);
            return rentApi;
        }

        private RentApi GetByIdVehicle(string vehicleId)
        {
            var rent = rentSystemServices.GetCollectionRents().FirstOrDefault(c => c.VehicleId == vehicleId);
            var rentApi = mapper.Map<RentApi>(rent);
            return rentApi;
        }

        private bool UserHasAnotherReserve(string userId)
        {
            var result = true;

            var resultGetAll = GetAll();
            if (resultGetAll.IsSuccess)
            {
                result = resultGetAll.Data.Any(c => !c.IsReturned && c.UserId == userId);
            }

            return result;
        }
    }
}
