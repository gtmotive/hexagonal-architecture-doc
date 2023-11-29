using AutoMapper;
using GtMotive.Estimate.Microservice.Api.Models;
using GtMotive.Estimate.Microservice.Domain.Entities;

namespace GtMotive.Estimate.Microservice.Api.Mappers
{
    public static class MapperVehicleConfig
    {
        public static Mapper Initialize()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Vehicle, VehicleApi>()
                   .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                   .ForMember(dest => dest.Model, opt => opt.MapFrom(src => src.Model))
                   .ForMember(dest => dest.Color, opt => opt.MapFrom(src => src.Color))
                   .ForMember(dest => dest.ManufactureDate, opt => opt.MapFrom(src => src.ManufactureDate))
                   .ForMember(dest => dest.PurchaseDate, opt => opt.MapFrom(src => src.PurchaseDate));

                cfg.CreateMap<VehicleApi, Vehicle>()
                   .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                   .ForMember(dest => dest.Model, opt => opt.MapFrom(src => src.Model))
                   .ForMember(dest => dest.Color, opt => opt.MapFrom(src => src.Color))
                   .ForMember(dest => dest.ManufactureDate, opt => opt.MapFrom(src => src.ManufactureDate))
                   .ForMember(dest => dest.PurchaseDate, opt => opt.MapFrom(src => src.PurchaseDate));
            });

            var mapper = new Mapper(config);
            return mapper;
        }
    }
}
