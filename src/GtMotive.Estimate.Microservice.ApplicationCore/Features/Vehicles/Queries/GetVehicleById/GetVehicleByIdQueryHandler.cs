using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GtMotive.Estimate.Microservice.ApplicationCore.Contracts.Repositories;
using GtMotive.Estimate.Microservice.ApplicationCore.Features.Vehicles.Common;
using MediatR;

namespace GtMotive.Estimate.Microservice.ApplicationCore.Features.Vehicles.Queries.GetVehicleById
{
    /// <summary>
    /// GetAllVehiclesQuery.
    /// </summary>
    public class GetVehicleByIdQueryHandler : IRequestHandler<GetVehicleByIdQuery, VehicleResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetVehicleByIdQueryHandler"/> class.
        /// </summary>
        /// <param name="mapper">IMapper.</param>
        /// <param name="unitOfWork">IUnitOfWork.</param>
        public GetVehicleByIdQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// GetVehicleByIdQueryHandler Handle.
        /// </summary>
        /// <param name="request">GetVehicleByIdQuery.</param>
        /// <param name="cancellationToken">CancellationToken.</param>
        /// <returns>List Vehicle.</returns>
        public async Task<VehicleResponse> Handle(GetVehicleByIdQuery request, CancellationToken cancellationToken)
        {
            if (request != null)
            {
                var data = await _unitOfWork.VehicleRepository.GetVehicleInfoByIdAsync(request.Id);
                return _mapper.Map<VehicleResponse>(data);
            }

            return null;
        }
    }
}
