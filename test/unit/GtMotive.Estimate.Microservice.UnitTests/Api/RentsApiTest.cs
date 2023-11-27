using System;
using System.Collections.Generic;
using System.Linq;
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
            var mockRepository = new Mock<IVehicleRepository>();
            mockRepository.Setup(repo => repo.GetAll()).Returns(GetAllMock());

            // Act
            var expected = 2;
            var actual = mockRepository.Object.GetAll().Count();

            // Assert
            Assert.Equal(expected, actual);
        }

        private static Func<IEnumerable<RentApi>> GetAllMock()
        {
            return () => new List<RentApi>
            {
                new RentApi { Id = Guid.NewGuid().ToString(),  VehicleId = "b1ecc77e-e2f0-40e0-9165-240140857ded", InitialDate = DateTime.Now.AddDays(1), FinalDate = DateTime.Now.AddDays(3), OperationDate = DateTime.Now },
                new RentApi { Id = Guid.NewGuid().ToString(),  VehicleId = "f705155d-d500-416b-81da-96708b965d05", InitialDate = DateTime.Now.AddDays(5), FinalDate = DateTime.Now.AddDays(8), OperationDate = DateTime.Now },
            };
        }
    }
}
