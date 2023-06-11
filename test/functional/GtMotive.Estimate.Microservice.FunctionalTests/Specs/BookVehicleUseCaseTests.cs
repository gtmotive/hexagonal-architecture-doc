using System;
using System.Threading.Tasks;
using FluentAssertions;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.BookVehicleUseCase;
using GtMotive.Estimate.Microservice.Domain.Aggregates.CustomerAggregate;
using GtMotive.Estimate.Microservice.Domain.Aggregates.VehicleAggregate;
using GtMotive.Estimate.Microservice.Domain.Repositories;
using GtMotive.Estimate.Microservice.FunctionalTests.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Moq;
using Xunit;

namespace GtMotive.Estimate.Microservice.FunctionalTests.Specs
{
    [Collection(TestCollections.Functional)]
    public class BookVehicleUseCaseTests : FunctionalTestBase
    {
        private ICustomerRepository _customerRepository;
        private IVehicleRepository _vehicleRepository;
        private IBookVehicleUseCase _bookVehicleUseCase;
        private Mock<IBookVehicleOutputPort> _outputPort;

        public override async Task InitializeAsync()
        {
            await base.InitializeAsync();

            _customerRepository = GetService<ICustomerRepository>();
            _vehicleRepository = GetService<IVehicleRepository>();
            _bookVehicleUseCase = GetService<IBookVehicleUseCase>();

            await _customerRepository.DeleteAll();
            await _vehicleRepository.DeleteAll();
        }

        [Fact]
        public async Task BookVehicleSuccess()
        {
            var customer = new Customer("Antonio");
            var vehicle = new Vehicle(new Model("Brand", "Model"), DateOnly.FromDateTime(DateTime.UtcNow));

            await _customerRepository.SaveAsync(customer);
            await _vehicleRepository.SaveAsync(vehicle);

            await _bookVehicleUseCase.Execute(new BookVehicleInput(customer.Id, vehicle.Id, DateOnly.FromDateTime(DateTime.UtcNow.AddDays(5))));

            var updatedCustomer = await _customerRepository.GetAsync(customer.Id);

            // Assert booking
            var booking = updatedCustomer.Bookings[0];
            booking.Should().NotBeNull();
            booking.BookingDate.Should().Be(DateOnly.FromDateTime(DateTime.UtcNow));
            booking.ReturnDate.Should().Be(DateOnly.FromDateTime(DateTime.UtcNow.AddDays(5)));
            booking.IsActive.Should().BeTrue();
            booking.VehicleId.Should().Be(vehicle.Id);

            // Assert output
            _outputPort.Verify(x => x.StandardHandle(It.Is<BookVehicleOutput>(output => output.Message == "Booking confirmed.")), Times.Once);
        }

        protected override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);

            _outputPort = new Mock<IBookVehicleOutputPort>();
            services.Replace(new ServiceDescriptor(typeof(IBookVehicleOutputPort), _outputPort.Object));
        }
    }
}
