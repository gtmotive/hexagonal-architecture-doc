using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace GtMotive.Estimate.Microservice.InfrastructureTests.Infrastructure
{
    public class VehiclesControllerTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public VehiclesControllerTests(WebApplicationFactory<Startup> factory)
        {
            if (factory == null)
            {
                throw new ArgumentNullException(nameof(factory));
            }

            _client = factory.CreateClient();
        }

        [Fact]
        public async Task PostVehicleReturnsBadRequestWhenModelIsInvalid()
        {
            // Arrange
            var vehicle = new StringContent("{}", System.Text.Encoding.UTF8, "application/json");

            var url = "/api/Vehicles";
            var uri = new Uri(url, UriKind.Relative);

            // Act
            var response = await _client.PostAsync(uri, vehicle);

            // Assert
            Assert.Equal(System.Net.HttpStatusCode.BadRequest, response.StatusCode);

            vehicle.Dispose();
        }
    }
}
