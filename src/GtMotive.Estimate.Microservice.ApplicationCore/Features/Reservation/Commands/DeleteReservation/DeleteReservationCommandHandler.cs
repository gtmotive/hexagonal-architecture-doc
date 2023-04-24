using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.Contracts.Repositories;
using GtMotive.Estimate.Microservice.ApplicationCore.Enums;
using GtMotive.Estimate.Microservice.Domain.Entities;
using MediatR;

namespace GtMotive.Estimate.Microservice.ApplicationCore.Features.Reservation.Commands.DeleteReservation
{
    /// <summary>
    /// DeleteReservationCommandHandler.
    /// </summary>
    public class DeleteReservationCommandHandler : IRequestHandler<DeleteReservationCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteReservationCommandHandler"/> class.
        /// </summary>
        /// <param name="unitOfWork">IUnitOfWork.</param>
        public DeleteReservationCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Handle.
        /// </summary>
        /// <param name="request">DeleteReservationCommand.</param>
        /// <param name="cancellationToken">CancellationToken.</param>
        /// <returns>bool.</returns>
        public async Task<bool> Handle(DeleteReservationCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                return false;
            }

            var reservationEntity = await _unitOfWork.ReservationRepository.GetByIdAsync(request.Id);
            if (reservationEntity == null)
            {
                return false;
            }

            var vehicleEntity = await _unitOfWork.VehicleRepository.GetVehicleInfoByIdAsync(reservationEntity.VehicleId);
            vehicleEntity.VehicleStateId = (int)VehicleStateValues.Available;
            await _unitOfWork.Repository<Vehicle>().UpdateAsync(vehicleEntity);

            await _unitOfWork.Repository<Domain.Entities.Reservation>().DeleteAsync(reservationEntity);

            await _unitOfWork.Complete();
            return true;
        }
    }
}
