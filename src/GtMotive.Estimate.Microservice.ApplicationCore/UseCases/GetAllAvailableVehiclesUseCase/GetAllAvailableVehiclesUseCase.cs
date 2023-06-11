using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Repositories;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.GetAllAvailableVehiclesUseCase
{
    /// <summary>
    /// Get all available vehicles use case.
    /// </summary>
    public class GetAllAvailableVehiclesUseCase : IGetAllAvailableVehiclesUseCase
    {
        private readonly IGetAllAvailableVehiclesOutputPort _outputPort;
        private readonly IVehicleRepository _vehicleRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllAvailableVehiclesUseCase"/> class.
        /// </summary>
        /// <param name="vehicleRepository">VehicleRepository.</param>
        /// <param name="outputPort">OutputPort.</param>
        public GetAllAvailableVehiclesUseCase(IVehicleRepository vehicleRepository, IGetAllAvailableVehiclesOutputPort outputPort)
        {
            _vehicleRepository = vehicleRepository;
            _outputPort = outputPort;
        }

        /// <summary>
        /// Executes the Use Case.
        /// </summary>
#pragma warning disable SA1615
        public async Task Execute()
#pragma warning restore SA1615
        {
            var vehicles = await _vehicleRepository.GetAllAvailableVehicles();

            _outputPort.StandardHandle(new GetAllAvailableVehiclesOutput(vehicles));
        }
    }
}
