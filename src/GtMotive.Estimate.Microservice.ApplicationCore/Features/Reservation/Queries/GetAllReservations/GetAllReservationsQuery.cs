using System.Collections.Generic;
using GtMotive.Estimate.Microservice.ApplicationCore.Features.Reservation.Queries.GetAllReservations;
using MediatR;

namespace GtMotive.Estimate.Microservice.ApplicationCore.Features.Vehicles.Queries.GetAllReservations
{
    /// <summary>
    /// GetAllReservationsQuery.
    /// </summary>
    public class GetAllReservationsQuery : IRequest<List<ReservationResponse>>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllReservationsQuery"/> class.
        /// </summary>
        public GetAllReservationsQuery()
        {
        }
    }
}
