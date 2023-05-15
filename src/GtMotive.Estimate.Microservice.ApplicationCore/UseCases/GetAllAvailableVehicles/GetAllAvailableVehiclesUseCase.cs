using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Aggregates.Fleet;
using GtMotive.Estimate.Microservice.Domain.Exceptions;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.GetAllAvailableVehicles
{
    /// <summary>
    /// GetAllAvailableVehicle Case.
    /// </summary>
    public class GetAllAvailableVehiclesUseCase : IGetAllAvailableVehiclesUseCase
    {
        private readonly IFleetRepository _fleetRepository;
        private readonly IGetAllAvailableVehiclesOutputPort _outputPort;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllAvailableVehiclesUseCase"/> class.
        /// </summary>
        /// <param name="fleetRepository">fleetRepository.</param>
        /// <param name="outputPort">OutputPort.</param>
        public GetAllAvailableVehiclesUseCase(
            IFleetRepository fleetRepository,
            IGetAllAvailableVehiclesOutputPort outputPort)
        {
            _fleetRepository = fleetRepository ?? throw new ArgumentNullException(nameof(fleetRepository));
            _outputPort = outputPort ?? throw new ArgumentNullException(nameof(outputPort));
        }

        /// <summary>
        /// Executes the use case.
        /// </summary>
        /// <param name="input">Input.</param>
        /// <returns>Task.</returns>
        public async Task Execute(GetAllAvailableVehiclesInput input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            try
            {
                var fleet = await _fleetRepository.GetByIdAsync(input.FleedId);
                if (fleet == null)
                {
                    throw new NotFoundEntityException($"Fleet with identifier {input.FleedId} could not be found.");
                }

                var vehicles = await _fleetRepository.GetAvailableVehiclesAsync(input.FleedId);

                BuildOutput(vehicles);
            }
            catch (NotFoundEntityException notFoundEx)
            {
                _outputPort.NotFoundHandle(notFoundEx.Message);
            }
        }

        private void BuildOutput(IEnumerable<Vehicle> vehicles)
        {
            var output = new GetAllAvailableVehiclesOutput(vehicles);
            _outputPort.StandardHandle(output);
        }
    }
}
