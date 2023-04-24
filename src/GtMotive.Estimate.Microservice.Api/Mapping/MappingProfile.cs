using AutoMapper;
using GtMotive.Estimate.Microservice.ApplicationCore.Features.Reservation.Commands.CreateReservation;
using GtMotive.Estimate.Microservice.ApplicationCore.Features.Reservation.Queries.GetAllReservations;
using GtMotive.Estimate.Microservice.ApplicationCore.Features.Vehicles.Commands.CreateVehicle;
using GtMotive.Estimate.Microservice.ApplicationCore.Features.Vehicles.Common;
using GtMotive.Estimate.Microservice.ApplicationCore.Features.VehicleStates.Queries.GetAllVehiclesStates;
using GtMotive.Estimate.Microservice.ApplicationCore.Identity.Models;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.Entities.Auth;

namespace GtMotive.Estimate.Microservice.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Vehicle, VehicleResponse>();
            CreateMap<CreateVehicleCommand, Vehicle>();

            CreateMap<VehicleState, VehicleStatesResponse>();

            CreateMap<CreateReservationCommand, Reservation>();
            CreateMap<Reservation, ReservationResponse>();

            CreateMap<UserSignUpResource, User>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email));
        }
    }
}
