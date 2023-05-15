using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.CreateVehicle
{
    public class CreateVehicleRequest : IRequest<IWebApiPresenter>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateVehicleRequest"/> class.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="modelYear">ModelYear.</param>
        public CreateVehicleRequest(string name, int modelYear)
        {
            Name = name;
            ModelYear = modelYear;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateVehicleRequest"/> class.
        /// </summary>
        /// <param name="fleetId">fleetId.</param>
        /// <param name="name">Name.</param>
        /// <param name="modelYear">ModelYear.</param>
        internal CreateVehicleRequest(int fleetId, string name, int modelYear)
        {
            FleetId = fleetId;
            Name = name;
            ModelYear = modelYear;
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the model Year.
        /// </summary>
        public int ModelYear { get; private set; }

        /// <summary>
        /// Gets the Fleet Identifier.
        /// </summary>
        internal int FleetId { get; private set; }
    }
}
