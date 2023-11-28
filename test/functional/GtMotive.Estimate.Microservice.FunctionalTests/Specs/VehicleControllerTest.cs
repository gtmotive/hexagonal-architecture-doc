using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using GtMotive.Estimate.Microservice.Api.Interfaces;
using GtMotive.Estimate.Microservice.Api.Repository;
using GtMotive.Estimate.Microservice.Domain.Entities;
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
        private readonly IVehicleBusiness vehicleRepository;

        public VehicleControllerTest()
        {
            var configuration = new ConfigurationBuilder()
                       .SetBasePath(Directory.GetCurrentDirectory())
                       .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                       .Build();

            // Configurar servicios
            var serviceProvider = new ServiceCollection()
                .Configure<FileSystemSettings>(configuration.GetSection("FileSystemSettings"))
                .BuildServiceProvider();

            // Obtener configuraciones
            var fileSystemServices = serviceProvider.GetRequiredService<IOptions<FileSystemSettings>>();

            vehicleRepository = new VehicleBusiness(new VehicleSystemServices(fileSystemServices));
        }

        [Fact]
        public void CreateReturnsOkResult()
        {
            // Arrange
            var controller = new VehicleController(vehicleRepository);
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
            var actual = Assert.IsType<OkResult>(result).StatusCode;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetAllReturnsOkResultWithListOfVehicles()
        {
            // Arrange
            var controller = new VehicleController(vehicleRepository);

            // Act
            var result = controller.GetAll();
            var vehicles = Assert.IsAssignableFrom<IEnumerable<Vehicle>>(result.Value);

            // Assert
            var expected = 1;
            var actual = vehicles.Count();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetAvailablesReturnsOkResultWithListOfVehicles()
        {
            // Arrange
            var controller = new VehicleController(vehicleRepository);

            // Act
            var result = controller.GetAvailables();
            var vehicles = Assert.IsAssignableFrom<IEnumerable<Vehicle>>(result.Value);

            // Assert
            var expected = 0;
            var actual = vehicles.Count();
            Assert.Equal(expected, actual);
        }
    }
}
