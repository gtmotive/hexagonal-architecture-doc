using System;
using GtMotive.Estimate.Microservice.Domain.Aggregates.VehicleAggregate;
using GtMotive.Estimate.Microservice.Domain.Exceptions;
using Xunit;

namespace GtMotive.Estimate.Microservice.UnitTests.Domain
{
    public class VehicleUnitTests
    {
        [Fact]
        public void ShouldThrowVehicleAgeExceptionForOlderVehicles()
        {
            // Arrange
            var model = new Model("Brand", "Model");
            var manufacturingDate = DateOnly.FromDateTime(DateTime.Now.AddYears(-6));

            // Assert
            Assert.Throws<VehicleAgeException>(() => new Vehicle(model, manufacturingDate));
        }

        [Fact]
        public void ShouldCreateVehicleForNewerVehicles()
        {
            // Arrange
            var model = new Model("Brand", "Model");
            var manufacturingDate = DateOnly.FromDateTime(DateTime.Now.AddYears(-4));

            // Act
            var vehicle = new Vehicle(model, manufacturingDate);

            // Assert
            Assert.NotNull(vehicle);
            Assert.Equal(manufacturingDate, vehicle.ManufacturingDate);
            Assert.Equal(model, vehicle.Model);
            Assert.True(vehicle.IsAvailable);
        }
    }
}
