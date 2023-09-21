using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.UseCases.GetAllAvailableVehicles;
using Xunit;

namespace GtMotive.Estimate.Microservice.InfrastructureTests.Infrastructure
{
    public class GetAllAvailableVehiclesTest : InfrastructureTestBase
    {
        public GetAllAvailableVehiclesTest(GenericInfrastructureTestServerFixture fixture)
            : base(fixture)
        {
        }

        [Fact]
        public async Task GetAllAvailableVehiclesShouldReturnOK()
        {
            var idFleet = Guid.Parse("d5f7e1dd-6d63-4f8e-9e64-83a7eb2a1f12");
            Uri uri = new($"/api/GetAllAvailableVehicles?idFleet={idFleet}");
            var response = await Fixture.Server.CreateClient().GetAsync(uri);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            var vehicleList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<GetAllAvailableVehiclesResponse>>(responseContent);
            Assert.NotNull(vehicleList);
        }
    }
}
