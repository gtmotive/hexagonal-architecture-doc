using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Aggregates.Fleet;
using GtMotive.Estimate.Microservice.Domain.Aggregates.Rental;
using GtMotive.Estimate.Microservice.Domain.Exceptions;
using GtMotive.Estimate.Microservice.Domain.Interfaces;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.DeleteRental
{
    /// <summary>
    /// Create Fleet Use Case.
    /// </summary>
    public class DeleteRentalUseCase : IDeleteRentalUseCase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFleetRepository _fleetRepository;
        private readonly IRentalRepository _rentalRepository;
        private readonly IDeleteRentalOutputPort _outputPort;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteRentalUseCase"/> class.
        /// </summary>
        /// <param name="unitOfWork">UnitofWork.</param>
        /// <param name="fleetRepository">fleetRepository.</param>
        /// <param name="rentalRepository">rentalRepository.</param>
        /// <param name="outputPort">OutputPort.</param>
        public DeleteRentalUseCase(
            IUnitOfWork unitOfWork,
            IFleetRepository fleetRepository,
            IRentalRepository rentalRepository,
            IDeleteRentalOutputPort outputPort)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _fleetRepository = fleetRepository ?? throw new ArgumentNullException(nameof(fleetRepository));
            _rentalRepository = rentalRepository ?? throw new ArgumentNullException(nameof(rentalRepository));
            _outputPort = outputPort ?? throw new ArgumentNullException(nameof(outputPort));
        }

        /// <summary>
        /// Executes the use case.
        /// </summary>
        /// <param name="input">Input.</param>
        /// <returns>Task.</returns>
        public async Task Execute(DeleteRentalInput input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            try
            {
                var rental = await _rentalRepository.GetByIdAsync(input.Id);
                if (rental == null)
                {
                    throw new NotFoundEntityException($"Rental with identifier {input.Id} could not be found.");
                }

                var vehicle = await _fleetRepository.GetVehicleAsync(rental.VehicleId);
                var fleet = await _fleetRepository.GetByIdAsync(vehicle.FleetId);

                vehicle.SetAsAvailable();
                fleet.AddVehicle(vehicle);

                _fleetRepository.Update(fleet);
                _rentalRepository.Remove(rental);

                await _unitOfWork.SaveAsync();

                BuildOutput(vehicle);
            }
            catch (NotFoundEntityException notFoundEx)
            {
                _outputPort.NotFoundHandle(notFoundEx.Message);
            }
        }

        private void BuildOutput(Vehicle vehicle)
        {
            var output = new DeleteRentalOutput(vehicle.Id, vehicle.IsAvailable);
            _outputPort.StandardHandle(output);
        }
    }
}
