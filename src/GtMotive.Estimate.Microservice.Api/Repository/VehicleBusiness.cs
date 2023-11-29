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
    public class VehicleBusiness : IVehicleBusiness
    {
        private readonly IMapper mapper;
        private readonly IVehicleSystemServices fileSystemServices;

        public VehicleBusiness(IVehicleSystemServices fileSystemService)
        {
            mapper = MapperVehicleConfig.Initialize();
            fileSystemServices = fileSystemService;
        }

        public Result<VehicleApi> Create(VehicleApi vehicleApi)
        {
            var result = new Result<VehicleApi>();
            if (vehicleApi.IsValidDate)
            {
                vehicleApi.SetId();
                var vehicle = mapper.Map<Vehicle>(vehicleApi);
                if (fileSystemServices.CreateVehicle(vehicle))
                {
                    var vehicleApiOk = mapper.Map<VehicleApi>(vehicleApi);
                    result.Ok(vehicleApiOk);
                }
            }
            else
            {
                result.Error($"El vehículo debe tener una antiguedad menor a {VehicleApi.VALIDATIONYEARS} años");
            }

            return result;
        }

        public Result<IEnumerable<VehicleApi>> GetAll()
        {
            var result = new Result<IEnumerable<VehicleApi>>();
            var vehicleApis = GetAllList();
            result.Ok(vehicleApis);
            return result;
        }

        public IEnumerable<VehicleApi> GetAvailables()
        {
            var vehicleApis = GetAllList().Where(c => c.IsValidDate);
            return vehicleApis;
        }

        public Result<VehicleApi> GetById(string id)
        {
            var result = new Result<VehicleApi>();
            var vehicle = fileSystemServices.GetCollectionVehicles().FirstOrDefault(c => c.Id == id);
            if (vehicle != null)
            {
                var resultVehicleApi = mapper.Map<VehicleApi>(vehicle);
                result.Ok(resultVehicleApi);
            }

            return result;
        }

        private List<VehicleApi> GetAllList()
        {
            var vehicleApis = new List<VehicleApi>();
            foreach (var item in fileSystemServices.GetCollectionVehicles())
            {
                var vehicleApiDto = mapper.Map<VehicleApi>(item);
                vehicleApis.Add(vehicleApiDto);
            }

            return vehicleApis;
        }
    }
}
