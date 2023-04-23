using System.Collections.Generic;
using GtMotive.Estimate.Microservice.ApplicationCore.Features.Vehicles.Common;
using MediatR;

namespace GtMotive.Estimate.Microservice.ApplicationCore.Features.Vehicles.Queries.GetAllVehicles
{
    /// <summary>
    /// GetAllVehiclesQuery.
    /// </summary>
    public class GetAllVehiclesQuery : IRequest<List<VehicleResponse>>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllVehiclesQuery"/> class.
        /// </summary>
        public GetAllVehiclesQuery()
        {
        }
    }
}
