using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.Interfaces;
using GtMotive.Estimate.Microservice.ApplicationCore.Repositories;
using GtMotive.Estimate.Microservice.ApplicationCore.Services;
using GtMotive.Estimate.Microservice.Domain.Aggregates;
using GtMotive.Estimate.Microservice.Domain.ValueObjects;
using Moq;
using Xunit;

namespace GtMotive.Estimate.Microservice.UnitTests.ApplicationCore
{
    public class VehicleServiceTests
    {
        [Fact]
        public async Task AddVehicleAsyncVehicleIsNewShouldAddVehicle()
        {
            var vehicleRepositoryMock = new Mock<IVehicleRepository>();
            var vehicleValidationServiceMock = new Mock<IVehicleValidationService>();

            vehicleValidationServiceMock
                .Setup(v => v.IsVehicleManufacturedWithin5Years(It.IsAny<int>()))
                .Returns(true);
            var vehicleService = new VehicleService(vehicleRepositoryMock.Object, vehicleValidationServiceMock.Object);
            var licensePlate = new LicensePlate("4546GNL");
            var make = new Make("VW");
            var model = new Model("Golf");
            var manufactureYear = new ManufactureYear(2023);
            var newVehicle = new Vehicle(licensePlate, make, model, manufactureYear);

            await vehicleService.AddVehicleAsync(newVehicle);

            vehicleRepositoryMock.Verify(v => v.AddAsync(It.IsAny<Vehicle>()), Times.Once);
        }
    }
}
