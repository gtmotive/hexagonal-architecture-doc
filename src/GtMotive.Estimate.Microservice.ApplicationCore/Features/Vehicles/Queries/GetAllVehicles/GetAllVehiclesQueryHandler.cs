using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GtMotive.Estimate.Microservice.ApplicationCore.Contracts.Repositories;
using GtMotive.Estimate.Microservice.ApplicationCore.Features.Vehicles.Common;
using MediatR;

namespace GtMotive.Estimate.Microservice.ApplicationCore.Features.Vehicles.Queries.GetAllVehicles
{
    /// <summary>
    /// GetAllVehiclesQuery.
    /// </summary>
    public class GetAllVehiclesQueryHandler : IRequestHandler<GetAllVehiclesQuery, List<VehicleResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllVehiclesQueryHandler"/> class.
        /// </summary>
        /// <param name="mapper">IMapper.</param>
        /// <param name="unitOfWork">IUnitOfWork.</param>
        public GetAllVehiclesQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// GetAllVehiclesQueryHandler Handle.
        /// </summary>
        /// <param name="request">GetAllVehiclesQuery.</param>
        /// <param name="cancellationToken">CancellationToken.</param>
        /// <returns>List Vehicle.</returns>
        public async Task<List<VehicleResponse>> Handle(GetAllVehiclesQuery request, CancellationToken cancellationToken)
        {
            var data = await _unitOfWork.VehicleRepository.GetVehiclesInfoAsync();
            return _mapper.Map<List<VehicleResponse>>(data);
        }
    }
}
