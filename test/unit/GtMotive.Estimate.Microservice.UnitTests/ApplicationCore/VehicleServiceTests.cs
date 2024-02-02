using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.Interfaces;
using GtMotive.Estimate.Microservice.ApplicationCore.Repositories;
using GtMotive.Estimate.Microservice.ApplicationCore.Services;
using GtMotive.Estimate.Microservice.Domain.Entities;
using Moq;
using Xunit;

namespace GtMotive.Estimate.Microservice.UnitTests.ApplicationCore
{
    public class VehicleServiceTests
    {
        [Fact]
        public async Task AddVehicleAsyncVehicleIsNewShouldAddVehicle()
        {
            // Arrange
            var vehicleRepositoryMock = new Mock<IVehicleRepository>();
            var vehicleValidationServiceMock = new Mock<IVehicleValidationService>();
            var vehicleService = new VehicleService(vehicleRepositoryMock.Object, vehicleValidationServiceMock.Object);
            var newVehicle = new Vehicle("4546GNL", "VW", "Golf", 2023);

            // Act
            await vehicleService.AddVehicleAsync(newVehicle);

            // Assert
            vehicleRepositoryMock.Verify(v => v.AddAsync(It.IsAny<Vehicle>()), Times.Once);
        }
    }
}
