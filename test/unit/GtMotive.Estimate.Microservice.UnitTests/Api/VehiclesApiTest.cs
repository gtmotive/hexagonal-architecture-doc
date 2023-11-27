using System;
using System.Collections.Generic;
using System.Linq;
using GtMotive.Estimate.Microservice.Api.Interfaces;
using GtMotive.Estimate.Microservice.Api.Models;
using Moq;
using Xunit;

namespace GtMotive.Estimate.Microservice.UnitTests.Api
{
    public class VehiclesApiTest
    {
        [Fact]
        public void GetAllReturnsOkResultWithListOfVehicles()
        {
            // Arrange
            var mockRepository = new Mock<IVehicleRepository>();
            mockRepository.Setup(repo => repo.GetAll()).Returns(GetAllMock());

            // Act
            var expected = 2;
            var actual = mockRepository.Object.GetAll().Count();

            // Assert
            Assert.Equal(expected, actual);
        }

        private static Func<IEnumerable<VehicleApi>> GetAllMock()
        {
            return () => new List<VehicleApi>
            {
                new VehicleApi { Model = "Ferrari", Color = "Red", ManufactureDate = DateTime.Now.AddYears(-2), PurchaseDate = DateTime.Now.AddYears(-6) },
                new VehicleApi { Model = "Seat", Color = "Blue", ManufactureDate = DateTime.Now.AddYears(-2), PurchaseDate = DateTime.Now }
            };
        }
    }
}
