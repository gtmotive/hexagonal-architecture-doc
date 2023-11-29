using AutoMapper;
using GtMotive.Estimate.Microservice.Api.Models;
using GtMotive.Estimate.Microservice.Domain.Entities;

namespace GtMotive.Estimate.Microservice.Api.Mappers
{
    public static class MapperRentConfig
    {
        public static Mapper Initialize()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Rent, RentApi>()
                           .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                           .ForMember(dest => dest.DevolutionDate, opt => opt.MapFrom(src => src.DevolutionDate))
                           .ForMember(dest => dest.InitialDate, opt => opt.MapFrom(src => src.InitialDate))
                           .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                           .ForMember(dest => dest.VehicleId, opt => opt.MapFrom(src => src.VehicleId));

                cfg.CreateMap<RentApi, Rent>()
                           .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                           .ForMember(dest => dest.DevolutionDate, opt => opt.MapFrom(src => src.DevolutionDate))
                           .ForMember(dest => dest.InitialDate, opt => opt.MapFrom(src => src.InitialDate))
                           .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                           .ForMember(dest => dest.VehicleId, opt => opt.MapFrom(src => src.VehicleId));
            });

            var mapper = new Mapper(config);
            return mapper;
        }
    }
}
