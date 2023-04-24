using GtMotive.Estimate.Microservice.ApplicationCore.Features.Vehicles.Common;
using MediatR;

namespace GtMotive.Estimate.Microservice.ApplicationCore.Features.Vehicles.Queries.GetVehicleById
{
    /// <summary>
    /// GetAllVehiclesQuery.
    /// </summary>
    public class GetVehicleByIdQuery : IRequest<VehicleResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetVehicleByIdQuery"/> class.
        /// </summary>
        public GetVehicleByIdQuery()
        {
        }

        /// <summary>
        /// Gets or sets id.
        /// </summary>
        public int Id { get; set; }
    }
}
