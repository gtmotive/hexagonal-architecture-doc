using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.UseCases.GetAllAvailableVehiclesUseCase;
using GtMotive.Estimate.Microservice.Domain.Aggregates.VehicleAggregate;
using GtMotive.Estimate.Microservice.Domain.Repositories;
using GtMotive.Estimate.Microservice.InfrastructureTests.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Moq;
using Xunit;

namespace GtMotive.Estimate.Microservice.InfrastructureTests.Specs
{
    public class VehiclesAvailableEndpointTests : InfrastructureTestBase
    {
        private readonly Uri _endpoint = new("Vehicles/Available", UriKind.Relative);
        private readonly HttpClient _client;

        public VehiclesAvailableEndpointTests()
        {
            _client = Server.CreateClient();
        }

        [Fact]
        public async Task SutReturnsVehicles()
        {
            // Act
            var httpResponse = await _client.GetAsync(_endpoint);

            // Assert
            Assert.Equal(HttpStatusCode.OK, httpResponse.StatusCode);

            var response = await httpResponse.Content
                .ReadFromJsonAsync<GetAllAvailableVehiclesResponse>();

            Assert.NotNull(response);
            Assert.NotEmpty(response.Vehicles);
        }

        protected override void ConfigureTestServices(IServiceCollection services)
        {
            var vehicleRepositoryMock = new Mock<IVehicleRepository>();

            vehicleRepositoryMock.Setup(repo => repo.GetAllAvailableVehicles())
                .ReturnsAsync(new List<Vehicle>
                {
                    new(new Model("Tesla", "Model S"), DateOnly.FromDateTime(DateTime.UtcNow))
                });

            services.Replace(new ServiceDescriptor(typeof(IVehicleRepository), vehicleRepositoryMock.Object));
        }
    }
}
