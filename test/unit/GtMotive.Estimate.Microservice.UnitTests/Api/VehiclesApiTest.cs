using System;
using System.Collections.Generic;
using System.Linq;
using GtMotive.Estimate.Microservice.Api.Action;
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
            var mockRepository = new Mock<IVehicleBusiness>();
            mockRepository.Setup(repo => repo.GetAll()).Returns(GetAllMock());

            // Act
            var expected = 2;
            var actual = mockRepository.Object.GetAll().Data.Count();

            // Assert
            Assert.Equal(expected, actual);
        }

        private static Result<IEnumerable<VehicleApi>> GetAllMock()
        {
            var resultVehicleApi = new Result<IEnumerable<VehicleApi>>();

            var listVehicleApi = new List<VehicleApi>()
                {
                     new VehicleApi { Model = "Ferrari", Color = "Red", ManufactureDate = DateTime.Now.AddYears(-2), PurchaseDate = DateTime.Now.AddYears(-6) },
                     new VehicleApi { Model = "Seat", Color = "Blue", ManufactureDate = DateTime.Now.AddYears(-2), PurchaseDate = DateTime.Now }
                };

            resultVehicleApi.Ok(listVehicleApi);
            return resultVehicleApi;
        }
    }
}
