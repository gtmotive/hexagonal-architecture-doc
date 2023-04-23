using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GtMotive.Estimate.Microservice.ApplicationCore.Contracts.Repositories;
using GtMotive.Estimate.Microservice.ApplicationCore.Features.Reservation.Queries.GetAllReservations;
using MediatR;

namespace GtMotive.Estimate.Microservice.ApplicationCore.Features.Vehicles.Queries.GetAllReservations
{
    /// <summary>
    /// GetAllReservationsQueryHandler.
    /// </summary>
    public class GetAllReservationsQueryHandler : IRequestHandler<GetAllReservationsQuery, List<ReservationResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllReservationsQueryHandler"/> class.
        /// </summary>
        /// <param name="mapper">IMapper.</param>
        /// <param name="unitOfWork">IUnitOfWork.</param>
        public GetAllReservationsQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// GetAllReservationsQuery Handle.
        /// </summary>
        /// <param name="request">GetAllReservationsQuery.</param>
        /// <param name="cancellationToken">CancellationToken.</param>
        /// <returns>List Vehicle.</returns>
        public async Task<List<ReservationResponse>> Handle(GetAllReservationsQuery request, CancellationToken cancellationToken)
        {
            var data = await _unitOfWork.ReservationRepository.GetAllReservationsInfoAsync();
            return _mapper.Map<List<ReservationResponse>>(data);
        }
    }
}
