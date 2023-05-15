namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateVehicle
{
    /// <summary>
    /// Create Fleet Input.
    /// </summary>
    public class CreateVehicleInput : IUseCaseInput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateVehicleInput"/> class.
        /// </summary>
        /// <param name="fleetId">fleetId.</param>
        /// <param name="name">Name.</param>
        /// <param name="modelYear">ModelYear.</param>
        public CreateVehicleInput(int fleetId, string name, int modelYear)
        {
            FleetId = fleetId;
            Name = name;
            ModelYear = modelYear;
        }

        /// <summary>
        /// Gets the Fleet Identifier.
        /// </summary>
        public int FleetId { get; private set; }

        /// <summary>
        /// Gets the name.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the model Year.
        /// </summary>
        public int ModelYear { get; private set; }
    }
}
