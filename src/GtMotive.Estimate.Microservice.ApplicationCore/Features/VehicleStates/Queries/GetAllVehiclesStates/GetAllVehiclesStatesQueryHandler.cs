using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GtMotive.Estimate.Microservice.ApplicationCore.Contracts.Repositories;
using GtMotive.Estimate.Microservice.ApplicationCore.Features.VehicleStates.Queries.GetAllVehiclesStates;
using GtMotive.Estimate.Microservice.Domain.Entities;
using MediatR;

namespace GtMotive.Estimate.Microservice.ApplicationCore.Features.Vehicles.Queries.GetAllVehiclesStates
{
    /// <summary>
    /// GetAllVehiclesStatesQuery.
    /// </summary>
    public class GetAllVehiclesStatesQueryHandler : IRequestHandler<GetAllVehiclesStatesQuery, List<VehicleStatesResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllVehiclesStatesQueryHandler"/> class.
        /// </summary>
        /// <param name="mapper">IMapper.</param>
        /// <param name="unitOfWork">IUnitOfWork.</param>
        public GetAllVehiclesStatesQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// GetAllVehiclesStatesQueryHandler Handle.
        /// </summary>
        /// <param name="request">GetAllVehiclesStatesQuery.</param>
        /// <param name="cancellationToken">CancellationToken.</param>
        /// <returns>List Vehicle States.</returns>
        public async Task<List<VehicleStatesResponse>> Handle(GetAllVehiclesStatesQuery request, CancellationToken cancellationToken)
        {
            var data = await _unitOfWork.Repository<VehicleState>().GetAllAsync();
            return _mapper.Map<List<VehicleStatesResponse>>(data);
        }
    }
}
