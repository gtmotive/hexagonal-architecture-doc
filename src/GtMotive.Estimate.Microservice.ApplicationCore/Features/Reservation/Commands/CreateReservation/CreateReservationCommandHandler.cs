using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GtMotive.Estimate.Microservice.ApplicationCore.Contracts.Repositories;
using GtMotive.Estimate.Microservice.ApplicationCore.Enums;
using GtMotive.Estimate.Microservice.Domain.Entities;
using MediatR;

namespace GtMotive.Estimate.Microservice.ApplicationCore.Features.Reservation.Commands.CreateReservation
{
    /// <summary>
    /// CreateReservationCommandHandler.
    /// </summary>
    public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand, int?>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateReservationCommandHandler"/> class.
        /// </summary>
        /// <param name="mapper">IMapper.</param>
        /// <param name="unitOfWork">IUnitOfWork.</param>
        public CreateReservationCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Handle.
        /// </summary>
        /// <param name="request">CreateReservationCommand.</param>
        /// <param name="cancellationToken">CancellationToken.</param>
        /// <returns>new reservation id or null.</returns>
        public async Task<int?> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                return null;
            }

            var vehicleEntity = await _unitOfWork.VehicleRepository.GetVehicleInfoByIdAsync(request.VehicleId);
            var reservations = await _unitOfWork.ReservationRepository.GetReservationsByUserIdAsync(request.UserId);

            if (reservations.Any() || vehicleEntity == null || vehicleEntity.VehicleStateId != (int)VehicleStateValues.Available)
            {
                return null;
            }

            var reservationEntity = _mapper.Map<Domain.Entities.Reservation>(request);
            await _unitOfWork.Repository<Domain.Entities.Reservation>().AddAsync(reservationEntity);

            vehicleEntity.VehicleStateId = (int)VehicleStateValues.Rented;
            await _unitOfWork.Repository<Vehicle>().UpdateAsync(vehicleEntity);

            await _unitOfWork.Complete();
            return reservationEntity.Id;
        }
    }
}
