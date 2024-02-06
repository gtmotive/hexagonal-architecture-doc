using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GtMotive.Estimate.Microservice.InfrastructureTests.Infrastructure
{
    [Collection(TestCollections.TestServer)]
    public class VehiclesApiTests : InfrastructureTestBase
    {
        public VehiclesApiTests(GenericInfrastructureTestServerFixture fixture)
            : base(fixture)
        {
        }

        [Fact]
        public async Task PostVehicleShouldReturnSuccessStatusCode()
        {
            var requestContent = new StringContent(/*lang=json,strict*/ "{\"licensePlate\":\"123ABC\",\"make\":\"TestMake\",\"model\":\"TestModel\",\"manufactureYear\":2023}", Encoding.UTF8, "application/json");

            var url = "/api/Vehicles/addVehicletoFleet";
            var uri = new Uri(url, UriKind.Relative);
            var response = await Fixture.Server.CreateClient().PostAsync(uri, requestContent);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            requestContent.Dispose();
        }
    }
}
