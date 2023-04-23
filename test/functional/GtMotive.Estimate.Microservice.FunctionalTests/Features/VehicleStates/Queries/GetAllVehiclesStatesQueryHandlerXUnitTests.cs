using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GtMotive.Estimate.Microservice.Api.Mapping;
using GtMotive.Estimate.Microservice.ApplicationCore.Features.Vehicles.Queries.GetAllVehiclesStates;
using GtMotive.Estimate.Microservice.ApplicationCore.Features.VehicleStates.Queries.GetAllVehiclesStates;
using GtMotive.Estimate.Microservice.FunctionalTests.Mocks;
using GtMotive.Estimate.Microservice.Infrastructure.Repositories;
using Moq;
using Shouldly;
using Xunit;

namespace GtMotive.Estimate.Microservice.FunctionalTests.Features.VehicleStates.Queries
{
    public class GetAllVehiclesStatesQueryHandlerXUnitTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;

        public GetAllVehiclesStatesQueryHandlerXUnitTests()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();

            MockVehicleStateRepository.AddDataRepository(_unitOfWork.Object.ApiDbContext);
        }

        /// <summary>
        /// GetVehicleStateListTestReturnsList.
        /// </summary>
        /// <returns>Fact.</returns>
        [Fact]
        public async Task GetVehicleStateListTestReturnsList()
        {
            var handler = new GetAllVehiclesStatesQueryHandler(_mapper, _unitOfWork.Object);
            var request = new GetAllVehiclesStatesQuery();

            var result = await handler.Handle(request, CancellationToken.None);

            result.ShouldBeOfType<List<VehicleStatesResponse>>();
            result.Count.ShouldBeGreaterThanOrEqualTo(1);
        }
    }
}
