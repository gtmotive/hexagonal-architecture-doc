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
                   .ForMember(dest => dest.FinalDate, opt => opt.MapFrom(src => src.FinalDate))
                   .ForMember(dest => dest.InitialDate, opt => opt.MapFrom(src => src.InitialDate))
                   .ForMember(dest => dest.OperationDate, opt => opt.MapFrom(src => src.OperationDate));

                cfg.CreateMap<RentApi, Rent>()
                   .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                   .ForMember(dest => dest.FinalDate, opt => opt.MapFrom(src => src.FinalDate))
                   .ForMember(dest => dest.InitialDate, opt => opt.MapFrom(src => src.InitialDate))
                   .ForMember(dest => dest.OperationDate, opt => opt.MapFrom(src => src.OperationDate));
            });

            var mapper = new Mapper(config);
            return mapper;
        }
    }
}
