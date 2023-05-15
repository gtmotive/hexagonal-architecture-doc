using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.DeleteRental
{
    public class DeleteRentalRequest : IRequest<IWebApiPresenter>
    {
        public DeleteRentalRequest(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
