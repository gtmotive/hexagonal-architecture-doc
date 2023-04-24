using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GtMotive.Estimate.Microservice.ApplicationCore.Contracts.Repositories;
using GtMotive.Estimate.Microservice.ApplicationCore.Enums;
using GtMotive.Estimate.Microservice.Domain.Entities;
using MediatR;

namespace GtMotive.Estimate.Microservice.ApplicationCore.Features.Vehicles.Commands.CreateVehicle
{
    /// <summary>
    /// CreateVehicleCommandHandler.
    /// </summary>
    public class CreateVehicleCommandHandler : IRequestHandler<CreateVehicleCommand, int?>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateVehicleCommandHandler"/> class.
        /// </summary>
        /// <param name="mapper">IMapper.</param>
        /// <param name="unitOfWork">IUnitOfWork.</param>
        public CreateVehicleCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Handle.
        /// </summary>
        /// <param name="request">CreateVehicleCommand.</param>
        /// <param name="cancellationToken">CancellationToken.</param>
        /// <returns>new vehicle id or null.</returns>
        public async Task<int?> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                return null;
            }

            var vehicleEntity = _mapper.Map<Vehicle>(request);
            vehicleEntity.VehicleStateId = (int)VehicleStateValues.Available;
            await _unitOfWork.VehicleRepository.AddAsync(vehicleEntity);
            await _unitOfWork.Complete();
            return vehicleEntity.Id;
        }
    }
}
