using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.Interfaces;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateVehicle
{
    /// <summary>
    /// Represents a use case responsible for creating a vehicle.
    /// </summary>
    public class CreateVehicleUseCase : ICreateVehicleUseCase
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly ICreateVehicleOutputPort _createVehicleOutputPort;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateVehicleUseCase"/> class.
        /// </summary>
        /// <param name="vehicleRepository">The repository for managing vehicle data.</param>
        /// <param name="createVehicleOutputPort">The output port for handling the results of vehicle creation.</param>
        public CreateVehicleUseCase(IVehicleRepository vehicleRepository, ICreateVehicleOutputPort createVehicleOutputPort)
        {
            _vehicleRepository = vehicleRepository ?? throw new ArgumentNullException(nameof(vehicleRepository));
            _createVehicleOutputPort = createVehicleOutputPort ?? throw new ArgumentNullException(nameof(createVehicleOutputPort));
        }

        /// <summary>
        /// Executes the vehicle creation use case.
        /// </summary>
        /// <param name="input">The input data for creating a vehicle.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task Execute(CreateVehicleInput input)
        {
            try
            {
                if (input == null)
                {
                    throw new ArgumentNullException(nameof(input));
                }

                var fiveYearsAgo = DateTime.UtcNow.AddYears(-5);
                if (input.ManufacturingDate < fiveYearsAgo)
                {
                    _createVehicleOutputPort.ExceptionHandle("The Vehicle is more than 5 years old, not suitable for the fleet.");
                    return;
                }

                var vehicle = new Vehicle(Guid.NewGuid(), input.Fleet, input.Brand, input.Model, input.ManufacturingDate, input.IsRental);
                var response = await _vehicleRepository.AddVehicle(vehicle);
                var output = new CreateVehicleOutput(response.Id, response.Fleet, response.Brand, response.Model, response.ManufacturingDate, response.IsRental);
                _createVehicleOutputPort.StandardHandle(output);
            }
            catch (Exception ex)
            {
                _createVehicleOutputPort.ExceptionHandle(ex.Message);
            }
        }
    }
}
