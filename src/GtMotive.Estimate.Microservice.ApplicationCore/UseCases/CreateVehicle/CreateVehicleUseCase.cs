using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Aggregates.Fleet;
using GtMotive.Estimate.Microservice.Domain.Exceptions;
using GtMotive.Estimate.Microservice.Domain.Interfaces;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateVehicle
{
    /// <summary>
    /// Create Fleet Use Case.
    /// </summary>
    public class CreateVehicleUseCase : ICreateVehicleUseCase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFleetRepository _fleetRepository;
        private readonly ICreateVehicleOutputPort _outputPort;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateVehicleUseCase"/> class.
        /// </summary>
        /// <param name="unitOfWork">UnitofWork.</param>
        /// <param name="fleetRepository">fleetRepository.</param>
        /// <param name="outputPort">OutputPort.</param>
        public CreateVehicleUseCase(
            IUnitOfWork unitOfWork,
            IFleetRepository fleetRepository,
            ICreateVehicleOutputPort outputPort)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _fleetRepository = fleetRepository ?? throw new ArgumentNullException(nameof(fleetRepository));
            _outputPort = outputPort ?? throw new ArgumentNullException(nameof(outputPort));
        }

        /// <summary>
        /// Executes the use case.
        /// </summary>
        /// <param name="input">Input.</param>
        /// <returns>Task.</returns>
        public async Task Execute(CreateVehicleInput input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            try
            {
                var fleet = await _fleetRepository.GetByIdAsync(input.FleetId);
                if (fleet == null)
                {
                    throw new NotFoundEntityException($"Fleet with identifier {input.FleetId} could not be found.");
                }

                var notAllowedInFleet = (DateTime.Today.Year - Math.Abs(input.ModelYear)) > 5;
                if (notAllowedInFleet)
                {
                    throw new VehicleNotAllowedInFleetException($"Vehicle manufactered in {input.ModelYear} could not be added in the fleet");
                }

                var vehicle = new Vehicle(input.ModelYear, input.Name);
                vehicle.SetAsAvailable();

                fleet.AddVehicle(vehicle);

                _fleetRepository.Update(fleet);
                await _unitOfWork.SaveAsync();

                BuildOutput(vehicle);
            }
            catch (NotFoundEntityException notFoundEx)
            {
                _outputPort.NotFoundHandle(notFoundEx.Message);
            }
            catch (VehicleNotAllowedInFleetException notFoundEx)
            {
                _outputPort.BadRequestHandle(notFoundEx.Message);
            }
        }

        private void BuildOutput(Vehicle vehicle)
        {
            var output = new CreateVehicleOutput(vehicle.Id, vehicle.Name.Text, vehicle.ModelYear);
            _outputPort.StandardHandle(output);
        }
    }
}
