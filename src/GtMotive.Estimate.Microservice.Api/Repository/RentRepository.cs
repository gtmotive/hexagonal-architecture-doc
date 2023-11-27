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
    public class RentRepository : IRentRepository
    {
        private readonly IMapper mapper;

        public RentRepository(FileSystemServices fileSystemService)
        {
            mapper = MapperRentConfig.Initialize();
            FileSystemServices = fileSystemService;
        }

        public FileSystemServices FileSystemServices { get; set; }

        public bool Create(RentApi rentDto)
        {
            var rent = mapper.Map<Rent>(rentDto);
            rent.SetId();
            return FileSystemServices.CreateRent(rent);
        }

        public IEnumerable<RentApi> GetAll()
        {
            var rentDtos = new List<RentApi>();
            foreach (var item in FileSystemServices.GetCollectionRents())
            {
                var rentDto = ConvertClassToDto(item);
                rentDtos.Add(rentDto);
            }

            return rentDtos;
        }

        public RentApi GetById(string id)
        {
            RentApi rentDto = null;
            var rent = FileSystemServices.GetCollectionRents().FirstOrDefault(c => c.Id == id);
            if (rent != null)
            {
                rentDto = ConvertClassToDto(rent);
            }

            return rentDto;
        }

        private RentApi ConvertClassToDto(Rent rent)
        {
            return mapper.Map<RentApi>(rent);
        }
    }
}
