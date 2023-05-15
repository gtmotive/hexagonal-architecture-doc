using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.CreateRental
{
    public class CreateRentalRequest : IRequest<IWebApiPresenter>
    {
        public CreateRentalRequest(int vehicleId, int customerId)
        {
            VehicleId = vehicleId;
            CustomerId = customerId;
        }

        public int VehicleId { get; private set; }

        public int CustomerId { get; private set; }
    }
}
