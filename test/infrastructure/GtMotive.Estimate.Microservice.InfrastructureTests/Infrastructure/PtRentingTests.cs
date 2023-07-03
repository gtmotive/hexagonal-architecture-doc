using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.Dtos;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Host.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Newtonsoft.Json;
using Xunit;

namespace GtMotive.Estimate.Microservice.InfrastructureTests.Infrastructure
{
    public class PtRentingTests
    {
        [Fact]
        public async Task PtRentingTestAsync()
        {
            using var httpClient = new HttpClient();

            var response = await httpClient.GetAsync(new Uri("https://localhost:51199/api/Renting/ListarVehiculos"));

            // Assert
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            var vehiculos = JsonConvert.DeserializeObject<List<Vehicle>>(responseBody);

            // Asegurar que se haya devuelto una lista de vehículos no vacía
            Assert.NotEmpty(vehiculos);
        }

        [Fact]
        public void CreateVehicleTest()
        {
            var rentServiceMock = new Mock<IRentalService>();
            var vehicleServiceMock = new Mock<IVehicleService>();

            var controller = new RentingController(rentServiceMock.Object, vehicleServiceMock.Object);

            var response = controller.CreateVehicle(new VehicleDto(5, "Ford Focus", new DateTime(2012, 10, 15)));

            Assert.IsType<BadRequestObjectResult>(response);
        }
    }
}
