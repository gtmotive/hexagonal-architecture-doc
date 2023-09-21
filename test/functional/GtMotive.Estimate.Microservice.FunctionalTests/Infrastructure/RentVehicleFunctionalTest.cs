using System;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.UseCases;
using GtMotive.Estimate.Microservice.Api.UseCases.RentVehicle;
using Xunit;

namespace GtMotive.Estimate.Microservice.FunctionalTests.Infrastructure
{
    public class RentVehicleFunctionalTest : FunctionalTestBase
    {
        public RentVehicleFunctionalTest(CompositionRootTestFixture fixture)
            : base(fixture)
        {
        }

        [Fact]
        public async Task RentVehicleSuccess()
        {
            var vehicleId = Guid.Parse("52ab6d63-5fc8-4d6e-b110-1df6937552e3");
            var startTime = DateTime.UtcNow;
            var endTime = startTime.AddHours(3);
            var clientIdCard = "12345";

            await Fixture.UsingHandlerForRequestResponse<RentVehicleRequest, IWebApiPresenter>(async handler =>
            {
                // Arrange
                var request = new RentVehicleRequest(vehicleId, startTime, endTime, clientIdCard);

                // Act
                var response = await handler.Handle(request, CancellationToken.None);

                // Assert
                Assert.NotNull(response);
            });
        }
    }
}
