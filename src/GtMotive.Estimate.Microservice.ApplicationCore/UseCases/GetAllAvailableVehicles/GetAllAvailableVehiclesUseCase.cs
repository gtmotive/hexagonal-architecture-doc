using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Interfaces;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.GetAllAvailableVehicles
{
    /// <summary>
    /// Represents a use case responsible for retrieving all available vehicles in a specific fleet.
    /// </summary>
    public class GetAllAvailableVehiclesUseCase : IGetAllAvailableVehiclesUseCase
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IGetAvailableVehiclesOutputPort _outputPortGetAvailableVehicles;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllAvailableVehiclesUseCase"/> class.
        /// </summary>
        /// <param name="vehicleRepository">The repository for managing vehicle data.</param>
        /// <param name="outputPortGetAvailableVehicles">The output port for handling the results of retrieving available vehicles.</param>
        public GetAllAvailableVehiclesUseCase(IVehicleRepository vehicleRepository, IGetAvailableVehiclesOutputPort outputPortGetAvailableVehicles)
        {
            _vehicleRepository = vehicleRepository ?? throw new ArgumentNullException(nameof(vehicleRepository));
            _outputPortGetAvailableVehicles = outputPortGetAvailableVehicles ?? throw new ArgumentNullException(nameof(outputPortGetAvailableVehicles));
        }

        /// <summary>
        /// Executes the use case to retrieve all available vehicles in a specific fleet.
        /// </summary>
        /// <param name="input">The input data specifying the fleet for which available vehicles will be retrieved.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task Execute(GetAllAvailableVehiclesInput input)
        {
            try
            {
                if (input == null || input.IdFleet == Guid.Empty)
                {
                    throw new ArgumentNullException(nameof(input));
                }

                var availableVehicles = await _vehicleRepository.GetAllAvailableVehicles(input.IdFleet);

                var output = new GetAvailableVehiclesOutput(availableVehicles);

                _outputPortGetAvailableVehicles.StandardHandle(output);
            }
            catch (Exception ex)
            {
                _outputPortGetAvailableVehicles.ExceptionHandle(ex.Message);
            }
        }
    }
}
