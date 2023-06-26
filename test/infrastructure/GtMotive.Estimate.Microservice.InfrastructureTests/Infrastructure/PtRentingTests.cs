using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Entities;
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
    }
}
