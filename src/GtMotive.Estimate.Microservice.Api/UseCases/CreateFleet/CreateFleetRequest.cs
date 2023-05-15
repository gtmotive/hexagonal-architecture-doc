using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.CreateFleet
{
    public class CreateFleetRequest : IRequest<IWebApiPresenter>
    {
        public CreateFleetRequest(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }
}
