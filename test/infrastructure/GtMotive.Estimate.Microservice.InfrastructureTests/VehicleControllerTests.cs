using System;
using System.Threading.Tasks;
using FluentAssertions;
using GtMotive.Estimate.Microservice.ApplicationCore.Features.Vehicles.Commands.CreateVehicle;
using GtMotive.Estimate.Microservice.Host.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace GtMotive.Estimate.Microservice.InfrastructureTests
{
    public class VehicleControllerTests
    {
        /// <summary>
        /// vehicleController Mock.
        /// </summary>
        private readonly VehicleController _vehicleControllerMock;

        /// <summary>
        /// Initializes a new instance of the <see cref="VehicleControllerTests"/> class.
        /// </summary>
        public VehicleControllerTests()
        {
            var mediator = new Mock<IMediator>();
            _vehicleControllerMock = new VehicleController(mediator.Object);
        }

        /// <summary>
        /// CreateVehicleAsyncReturnsBadRequest.
        /// </summary>
        /// <returns>fact.</returns>
        [Fact]
        public async Task CreateVehicleAsyncReturnsBadRequest()
        {
            var command = new CreateVehicleCommand()
            {
                ManufacturingDate = DateTime.Now,
                RegistrationNumber = null
            };

            var result = await _vehicleControllerMock.CreateVehicleAsync(command);
            result.Result.Should().BeOfType<BadRequestResult>();
        }
    }
}
