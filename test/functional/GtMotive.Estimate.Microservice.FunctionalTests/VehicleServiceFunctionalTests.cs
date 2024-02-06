using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.Repositories;
using GtMotive.Estimate.Microservice.ApplicationCore.Services;
using GtMotive.Estimate.Microservice.Domain.Aggregates;
using GtMotive.Estimate.Microservice.Domain.ValueObjects;
using GtMotive.Estimate.Microservice.FunctionalTests.Infrastructure;
using Xunit;

namespace GtMotive.Estimate.Microservice.FunctionalTests
{
    public class VehicleServiceFunctionalTests : FunctionalTestBase
    {
        public VehicleServiceFunctionalTests(CompositionRootTestFixture fixture)
            : base(fixture)
        {
        }

        [Fact]
        public async Task AddVehicleAsyncSavesToDatabase()
        {
            await Fixture.UsingRepository<IVehicleRepository>(async repository =>
            {
                var vehicleService = new VehicleService(repository, new VehicleValidationService());
                var licensePlate = new LicensePlate("0806FWM");
                var make = new Make("Fiat");
                var model = new Model("Punto");
                var manufactureYear = new ManufactureYear(2023);

                await vehicleService.AddVehicleAsync(new Vehicle(licensePlate, make, model, manufactureYear));

                Assert.Equal(1, await repository.CountAsync());
            });
        }
    }
}
