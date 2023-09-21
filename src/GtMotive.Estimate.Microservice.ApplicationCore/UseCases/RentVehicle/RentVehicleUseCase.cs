using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.Interfaces;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.RentVehicle
{
    /// <summary>
    /// Represents a use case responsible for renting a vehicle.
    /// </summary>
    public class RentVehicleUseCase : IRentVehicleUseCase
    {
        private readonly IRentalRepository _rentalRepository;
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IRentVehicleOutputPort _rentVehicleOutputPort;

        /// <summary>
        /// Initializes a new instance of the <see cref="RentVehicleUseCase"/> class.
        /// </summary>
        /// <param name="rentalRepository">The repository for managing rental data.</param>
        /// <param name="vehicleRepository">The repository for managing vehicle data.</param>
        /// <param name="rentOutputPort">The output port for handling the results of the vehicle rental operation.</param>
        public RentVehicleUseCase(IRentalRepository rentalRepository, IVehicleRepository vehicleRepository, IRentVehicleOutputPort rentOutputPort)
        {
            _rentalRepository = rentalRepository ?? throw new ArgumentNullException(nameof(rentalRepository));
            _vehicleRepository = vehicleRepository ?? throw new ArgumentNullException(nameof(vehicleRepository));
            _rentVehicleOutputPort = rentOutputPort ?? throw new ArgumentNullException(nameof(rentOutputPort));
        }

        /// <summary>
        /// Executes the use case to rent a vehicle.
        /// </summary>
        /// <param name="input">The input data specifying the details of the vehicle rental.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task Execute(RentVehicleInput input)
        {
            try
            {
                if (input == null)
                {
                    throw new ArgumentNullException(nameof(input));
                }

                if (input.ClientIdCard == null)
                {
                    _rentVehicleOutputPort.ExceptionHandle("ClientId invalid");
                    return;
                }

                var vehicle = await _vehicleRepository.GetVehicleById(input.VehicleId);
                if (vehicle == null)
                {
                    _rentVehicleOutputPort.NotFoundHandle("The vehicle to rent doesn't exist");
                    return;
                }

                var fiveYearsAgo = DateTime.Now.AddYears(-5);
                if (vehicle.ManufacturingDate < fiveYearsAgo)
                {
                    _rentVehicleOutputPort.NotFoundHandle("The vehicle to be rented is out of the fleet");
                    return;
                }

                if (vehicle.IsRental)
                {
                    _rentVehicleOutputPort.NotFoundHandle("The vehicle to be rented is already rented");
                    return;
                }

                var hasActiveRental = await _rentalRepository.HasActiveRental(input.ClientIdCard);
                if (hasActiveRental)
                {
                    _rentVehicleOutputPort.NotFoundHandle("Client has an active rental");
                    return;
                }

                var rental = new Rental(Guid.NewGuid(), input.VehicleId, input.StartTime, input.EndTime, input.ClientIdCard);
                var response = await _rentalRepository.AddRental(rental);
                if (response == null)
                {
                    _rentVehicleOutputPort.ExceptionHandle("Error in rental response");
                    return;
                }

                await _vehicleRepository.ModifyVehicleRental(vehicle.Id, true);
                var output = new RentVehicleOutput(response.Id, response.VehicleId, response.StartTime, response.EndTime, response.ClientIdCard);
                _rentVehicleOutputPort.StandardHandle(output);
            }
            catch (Exception ex)
            {
                _rentVehicleOutputPort.ExceptionHandle(ex.Message);
            }
        }
    }
}
