using System.Collections.Generic;
using GtMotive.Estimate.Microservice.ApplicationCore.Features.VehicleStates.Queries.GetAllVehiclesStates;
using MediatR;

namespace GtMotive.Estimate.Microservice.ApplicationCore.Features.Vehicles.Queries.GetAllVehiclesStates
{
    /// <summary>
    /// GetAllVehiclesStatesQuery.
    /// </summary>
    public class GetAllVehiclesStatesQuery : IRequest<List<VehicleStatesResponse>>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllVehiclesStatesQuery"/> class.
        /// </summary>
        public GetAllVehiclesStatesQuery()
        {
        }
    }
}
