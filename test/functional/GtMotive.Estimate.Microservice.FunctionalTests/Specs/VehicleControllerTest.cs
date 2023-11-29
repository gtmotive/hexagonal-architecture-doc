using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using GtMotive.Estimate.Microservice.Api.Interfaces;
using GtMotive.Estimate.Microservice.Api.Repository;
using GtMotive.Estimate.Microservice.Host.Controller.V1;
using GtMotive.Estimate.Microservice.Host.Models.Vehicle;
using GtMotive.Estimate.Microservice.Infrastructure.FileSystem;
using GtMotive.Estimate.Microservice.Infrastructure.FileSystem.Settings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Xunit;

namespace GtMotive.Estimate.Microservice.FunctionalTests.Specs
{
    public class VehicleControllerTest
    {
        private readonly IVehicleBusiness vehicleBusiness;

        public VehicleControllerTest()
        {
            var configuration = new ConfigurationBuilder()
                       .SetBasePath(Directory.GetCurrentDirectory())
                       .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                       .Build();

            var serviceProvider = new ServiceCollection()
                .Configure<FileSystemSettings>(configuration.GetSection("FileSystemSettings"))
                .BuildServiceProvider();

            var fileSystemServices = serviceProvider.GetRequiredService<IOptions<FileSystemSettings>>();

            vehicleBusiness = new VehicleBusiness(new VehicleSystemServices(fileSystemServices));
        }

        [Fact]
        public void CreateReturnsOkResultValidManufactureDate()
        {
            // Arrange
            var controller = new VehicleController(vehicleBusiness);
            var requestVehicleDto = new RequestVehicleDto
            {
                Color = "Red",
                Model = "BMW",
                ManufactureDate = DateTime.Now.AddYears(-3),
                PurchaseDate = DateTime.Now
            };

            // Act
            var result = controller.Create(requestVehicleDto);

            // Assert
            var expected = (int)HttpStatusCode.OK;
            var actual = Assert.IsType<OkObjectResult>(result).StatusCode;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CreateReturnsKoResultInvValidManufactureDate()
        {
            // Arrange
            var controller = new VehicleController(vehicleBusiness);
            var requestVehicleDto = new RequestVehicleDto
            {
                Color = "Red",
                Model = "BMW",
                ManufactureDate = DateTime.Now.AddYears(-6),
                PurchaseDate = DateTime.Now
            };

            // Act
            var result = controller.Create(requestVehicleDto);

            // Assert
            var expected = (int)HttpStatusCode.BadRequest;
            var actual = Assert.IsType<BadRequestObjectResult>(result).StatusCode;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetAllReturnsOkResultWithListOfVehicles()
        {
            // Arrange
            var controller = new VehicleController(vehicleBusiness);

            // Act
            var result = controller.GetAll();
            var okObjectResult = Assert.IsType<OkObjectResult>(result.Result);
            var listVehicleDto = (IEnumerable<ResponseVehicleDto>)okObjectResult.Value;

            // Assert
            var expected = true;
            var actual = listVehicleDto.Any();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetAvailablesReturnsOkResultWithListOfVehicles()
        {
            // Arrange
            var controller = new VehicleController(vehicleBusiness);

            // Act
            var result = controller.GetAvailables();
            var okObjectResult = Assert.IsType<OkObjectResult>(result.Result);
            var listVehicleDto = (IEnumerable<ResponseVehicleDto>)okObjectResult.Value;

            // Assert
            var expected = true;
            var actual = listVehicleDto.Any();

            Assert.Equal(expected, actual);
        }
    }
}
