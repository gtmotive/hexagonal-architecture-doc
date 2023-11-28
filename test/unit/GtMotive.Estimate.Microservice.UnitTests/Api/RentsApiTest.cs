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
    public class RentsApiTest
    {
        [Fact]
        public void GetAllReturnsOkResultWithListOfRents()
        {
            // Arrange
            var mockRepository = new Mock<IRentBusiness>();
            mockRepository.Setup(repo => repo.GetAll()).Returns(GetAllMock());

            // Act
            var expected = 2;
            var actual = mockRepository.Object.GetAll().Data.Count();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DevolutionReturnsOk()
        {
            // Arrange
            var mockRepository = new Mock<IRentBusiness>();
            mockRepository.Setup(repo => repo.GetAll()).Returns(GetAllMock());

            // Act
            var expected = true;
            var actual = mockRepository.Object.Devolution("2").IsSuccess;

            // Assert
            Assert.Equal(expected, actual);
        }

        private static Result<IEnumerable<RentApi>> GetAllMock()
        {
            var resultRentApi = new Result<IEnumerable<RentApi>>();

            var listRentApi = new List<RentApi>()
            {
                new RentApi { Id = "1", VehicleId = "1",  UserId = "Juan", InitialDate = new DateTime(2023, 1, 1) },
                new RentApi { Id = "2", VehicleId = "2",  UserId = "Ana", InitialDate = new DateTime(2023, 1, 2), DevolutionDate = new DateTime(2023, 2, 1) },
                new RentApi { Id = "3", VehicleId = "2",  UserId = "Cristian", InitialDate = new DateTime(2023, 1, 1) }
            };

            resultRentApi.Ok(listRentApi);
            return resultRentApi;
        }
    }
}
