using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Aggregates.Fleet;
using GtMotive.Estimate.Microservice.Domain.Interfaces;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateFleet
{
    /// <summary>
    /// Create Fleet Use Case.
    /// </summary>
    public class CreateFleetUseCase : ICreateFleetUseCase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFleetRepository _fleetRepository;
        private readonly ICreateFleetOutputPort _outputPort;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateFleetUseCase"/> class.
        /// </summary>
        /// <param name="unitOfWork">UnitofWork.</param>
        /// <param name="fleetRepository">FleetRepository.</param>
        /// <param name="outputPort">OutputPort.</param>
        public CreateFleetUseCase(
            IUnitOfWork unitOfWork,
            IFleetRepository fleetRepository,
            ICreateFleetOutputPort outputPort)
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
        public async Task Execute(CreateFleetInput input)
        {
            Fleet fleet = new(input?.Name);
            _fleetRepository.Add(fleet);

            await _unitOfWork.SaveAsync();

            BuildOutput(fleet);
        }

        private void BuildOutput(Fleet fleet)
        {
            var output = new CreateFleetOutput(fleet.Id, fleet.Name.Text);
            _outputPort.StandardHandle(output);
        }
    }
}
