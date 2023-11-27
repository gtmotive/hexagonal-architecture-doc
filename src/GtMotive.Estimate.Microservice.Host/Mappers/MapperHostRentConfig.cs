using AutoMapper;
using GtMotive.Estimate.Microservice.Api.Models;
using GtMotive.Estimate.Microservice.Host.Models;

namespace GtMotive.Estimate.Microservice.Host.Mappers
{
    public static class MapperHostRentConfig
    {
        public static Mapper Initialize()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RequestRentDto, RentApi>()
                   .ForMember(dest => dest.VehicleId, opt => opt.MapFrom(src => src.VehicleId))
                   .ForMember(dest => dest.FinalDate, opt => opt.MapFrom(src => src.FinalDate))
                   .ForMember(dest => dest.InitialDate, opt => opt.MapFrom(src => src.InitialDate))
                   .ForMember(dest => dest.OperationDate, opt => opt.MapFrom(src => src.OperationDate));

                cfg.CreateMap<RentApi, ResponseRentDto>()
                   .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                   .ForMember(dest => dest.VehicleId, opt => opt.MapFrom(src => src.VehicleId))
                   .ForMember(dest => dest.FinalDate, opt => opt.MapFrom(src => src.FinalDate))
                   .ForMember(dest => dest.InitialDate, opt => opt.MapFrom(src => src.InitialDate))
                   .ForMember(dest => dest.OperationDate, opt => opt.MapFrom(src => src.OperationDate));
            });

            var mapper = new Mapper(config);
            return mapper;
        }
    }
}
