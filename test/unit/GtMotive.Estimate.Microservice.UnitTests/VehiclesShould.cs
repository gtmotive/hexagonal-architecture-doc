using System;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Implementation;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Interfaces.Repositories;
using GtMotive.Estimate.Microservice.Domain.Entities;
using Moq;
using Xunit;

namespace GtMotive.Estimate.Microservice.UnitTests
{
    public class VehiclesShould
    {
        [Fact]
        public void NotBeOld()
        {
            // Arrange
            var vehicleRepositoryMock = new Mock<IVehicleRepository>();
            var vehicleService = new VehicleService(vehicleRepositoryMock.Object);

            var oldVehicle = new Vehicle("Marca nueva", new DateTime(2010, 10, 1));

            Assert.Throws<ArgumentException>(() => vehicleService.Add(oldVehicle));
        }
    }
}
