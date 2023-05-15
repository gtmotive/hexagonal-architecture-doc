using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.GetAllAvailableVehicles
{
    public class GetAllAvailableVehiclesRequest : IRequest<IWebApiPresenter>
    {
        public GetAllAvailableVehiclesRequest(int fleedId)
        {
            FleedId = fleedId;
        }

        /// <summary>
        /// Gets fleet Id.
        /// </summary>
        public int FleedId { get; private set; }
    }
}
