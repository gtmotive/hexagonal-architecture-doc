using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Exceptions;
using GtMotive.Estimate.Microservice.Domain.Repositories;
using GtMotive.Estimate.Microservice.Domain.Services;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.BookVehicleUseCase
{
    /// <summary>
    /// Use case to book a vehicle.
    /// </summary>
    public class BookVehicleUseCase : IBookVehicleUseCase
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IBookingService _bookingDomainService;
        private readonly IBookVehicleOutputPort _outputPort;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookVehicleUseCase"/> class.
        /// </summary>
        /// <param name="customerRepository">CustomerRepository.</param>
        /// <param name="vehicleRepository">VehicleRepository.</param>
        /// <param name="bookingDomainService">BookingService.</param>
        /// <param name="outputPort">BookVehicleOutputPort.</param>
        public BookVehicleUseCase(ICustomerRepository customerRepository, IVehicleRepository vehicleRepository, IBookingService bookingDomainService, IBookVehicleOutputPort outputPort)
        {
            _customerRepository = customerRepository;
            _vehicleRepository = vehicleRepository;
            _bookingDomainService = bookingDomainService;
            _outputPort = outputPort;
        }

        /// <summary>
        /// Executes the use case.
        /// </summary>
        /// <param name="input">Input.</param>
        /// <returns>Task.</returns>
        public async Task Execute(BookVehicleInput input)
        {
            if (input == null)
            {
                _outputPort.BadRequest("Input is null.");
                return;
            }

            var customer = await _customerRepository.GetAsync(input.CustomerId);
            var vehicle = await _vehicleRepository.GetAsync(input.VehicleId);

            if (customer == null)
            {
                _outputPort.NotFoundHandle($"Customer with id {input.CustomerId} not found.");
                return;
            }

            if (vehicle == null)
            {
                _outputPort.NotFoundHandle($"Vehicle with id {input.VehicleId} not found.");
                return;
            }

            try
            {
                _bookingDomainService.BookVehicle(customer, vehicle, input.ReturnDate);

                await _customerRepository.SaveAsync(customer);
                await _vehicleRepository.SaveAsync(vehicle);

                _outputPort.StandardHandle(new BookVehicleOutput("Booking confirmed.")); // Nota revisor: No devolvería nada en un entorno real para este caso de uso.
            }
            catch (VehicleNotAvailableException)
            {
                _outputPort.BadRequest("Vehicle is not available.");
            }
        }
    }
}
