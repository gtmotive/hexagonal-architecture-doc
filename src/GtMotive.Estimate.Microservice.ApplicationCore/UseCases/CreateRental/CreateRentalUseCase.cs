using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Aggregates.Fleet;
using GtMotive.Estimate.Microservice.Domain.Aggregates.Rental;
using GtMotive.Estimate.Microservice.Domain.Exceptions;
using GtMotive.Estimate.Microservice.Domain.Interfaces;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateRental
{
    /// <summary>
    /// Create Fleet Use Case.
    /// </summary>
    public class CreateRentalUseCase : ICreateRentalUseCase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFleetRepository _fleetRepository;
        private readonly IRentalRepository _rentalRepository;
        private readonly ICreateRentalOutputPort _outputPort;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateRentalUseCase"/> class.
        /// </summary>
        /// <param name="unitOfWork">UnitofWork.</param>
        /// <param name="fleetRepository">fleetRepository.</param>
        /// <param name="rentalRepository">rentalRepository.</param>
        /// <param name="outputPort">OutputPort.</param>
        public CreateRentalUseCase(
            IUnitOfWork unitOfWork,
            IFleetRepository fleetRepository,
            IRentalRepository rentalRepository,
            ICreateRentalOutputPort outputPort)
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
        public async Task Execute(CreateRentalInput input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            try
            {
                var vehicle = await _fleetRepository.GetVehicleAsync(input.VehicleId);
                if (vehicle == null)
                {
                    throw new NotFoundEntityException($"Vehicle with identifier {input.VehicleId} could not be found.");
                }

                if (!vehicle.IsAvailable)
                {
                    throw new VehicleShouldBeAvailableException($"Vehicle with identifier {input.VehicleId} is not longer available");
                }

                if (await _rentalRepository.AnyCustomerIdAsync(input.CustomerId))
                {
                    throw new CustomerExistsInRentalException($"Customer with identifier {input.CustomerId} has already a vehicle in rental");
                }

                var fleet = await _fleetRepository.GetByIdAsync(vehicle.FleetId);
                vehicle.SetAsUnAvailable();
                fleet.AddVehicle(vehicle);

                var rental = new Rental(input.VehicleId, input.CustomerId, DateTime.UtcNow);

                _fleetRepository.Update(fleet);
                _rentalRepository.Add(rental);

                await _unitOfWork.SaveAsync();

                BuildOutput(rental);
            }
            catch (NotFoundEntityException notFoundEx)
            {
                _outputPort.NotFoundHandle(notFoundEx.Message);
            }
            catch (Exception ex) when (ex is VehicleShouldBeAvailableException or CustomerExistsInRentalException)
            {
                _outputPort.BadRequestHandle(ex.Message);
            }
        }

        private void BuildOutput(Rental rental)
        {
            var output = new CreateRentalOutput(rental.Id, rental.Date);
            _outputPort.StandardHandle(output);
        }
    }
}
