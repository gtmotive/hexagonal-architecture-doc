using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Interfaces;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ReturnVehicle
{
    /// <summary>
    /// Represents a use case responsible for returning a rented vehicle.
    /// </summary>
    public class ReturnVehicleUseCase : IReturnVehicleUseCase
    {
        private readonly IRentalRepository _rentalRepository;
        private readonly IReturnVehicleOutputPort _outputPort;
        private readonly IVehicleRepository _vehicleRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReturnVehicleUseCase"/> class.
        /// </summary>
        /// <param name="rentalRepository">The repository for managing rental data.</param>
        /// <param name="outputPort">The output port for handling the results of the vehicle return operation.</param>
        /// <param name="vehicleRepository">The repository for managing vehicle data.</param>
        public ReturnVehicleUseCase(IRentalRepository rentalRepository, IReturnVehicleOutputPort outputPort, IVehicleRepository vehicleRepository)
        {
            _rentalRepository = rentalRepository ?? throw new ArgumentNullException(nameof(rentalRepository));
            _outputPort = outputPort ?? throw new ArgumentNullException(nameof(outputPort));
            _vehicleRepository = vehicleRepository ?? throw new ArgumentNullException(nameof(vehicleRepository));
        }

        /// <summary>
        /// Executes the use case to return a rented vehicle.
        /// </summary>
        /// <param name="input">The input data specifying the rental to be completed.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task Execute(ReturnVehicleInput input)
        {
            try
            {
                if (input == null)
                {
                    throw new ArgumentNullException(nameof(input));
                }

                var exist = await _rentalRepository.GetRentalById(input.RentalId);
                if (exist == null)
                {
                    _outputPort.ExceptionHandle($"There is no rental with ID:{input.RentalId}");
                    return;
                }

                await _rentalRepository.CompleteRental(input.RentalId);
                await _vehicleRepository.ModifyVehicleRental(exist.VehicleId, false);
                _outputPort.StandardHandle(new ReturnVehicleOutput("Completed return vehicle."));
            }
            catch (Exception ex)
            {
                _outputPort.ExceptionHandle(ex.Message);
            }
        }
    }
}
