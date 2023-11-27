using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using GtMotive.Estimate.Microservice.Api.Interfaces;
using GtMotive.Estimate.Microservice.Api.Mappers;
using GtMotive.Estimate.Microservice.Api.Models;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Infrastructure.FileSystem;

namespace GtMotive.Estimate.Microservice.Api.Repository
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly IMapper mapper;
        private readonly FileSystemServices fileSystemServices;

        public VehicleRepository(FileSystemServices fileSystemService)
        {
            mapper = MapperVehicleConfig.Initialize();
            fileSystemServices = fileSystemService;
        }

        public bool Create(VehicleApi vehicleApi)
        {
            var vehicle = mapper.Map<Vehicle>(vehicleApi);
            vehicle.SetId();
            return fileSystemServices.CreateVehicle(vehicle);
        }

        public IEnumerable<VehicleApi> GetAll()
        {
            var vehicleApis = new List<VehicleApi>();
            foreach (var item in fileSystemServices.GetCollectionVehicles())
            {
                var vehicleDto = ConvertClassToDto(item);
                vehicleApis.Add(vehicleDto);
            }

            return vehicleApis;
        }

        public IEnumerable<VehicleApi> GetAvailables()
        {
            var vehicleApis = GetAll().Where(c => c.IsValidDate);
            return vehicleApis;
        }

        public VehicleApi GetById(string id)
        {
            VehicleApi vehicleApi = null;
            var vehicle = fileSystemServices.GetCollectionVehicles().FirstOrDefault(c => c.Id == id);
            if (vehicle != null)
            {
                vehicleApi = ConvertClassToDto(vehicle);
            }

            return vehicleApi;
        }

        private VehicleApi ConvertClassToDto(Vehicle vehicle)
        {
            return mapper.Map<VehicleApi>(vehicle);
        }
    }
}
