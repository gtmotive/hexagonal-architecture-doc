using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.Services;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Infrastructure.InMemoryVehicle;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace GtMotive.Estimate.Microservice.FunctionalTests
{
    public class VehicleServiceIntegrationTests
    {
        [Fact]
        public async Task AddVehicleAsyncSavesToDatabase()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            // Usar using para asegurar la limpieza de la base de datos en memoria después de la prueba
            using var context = new AppDbContext(options);
            var vehicleService = new VehicleService(new InMemoryVehicleRepository(context), new VehicleValidationService());

            // Act
            await vehicleService.AddVehicleAsync(new Vehicle("0806FWM", "Fiat", "Punto", 2023));

            // Assert
            Assert.Equal(1, await context.Vehicles.CountAsync());
        }
    }
}
