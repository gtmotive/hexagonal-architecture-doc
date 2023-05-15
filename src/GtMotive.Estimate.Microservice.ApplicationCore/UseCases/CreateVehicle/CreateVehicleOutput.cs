namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateVehicle
{
    /// <summary>
    /// CreateFleetOutput.
    /// </summary>
    public class CreateVehicleOutput : IUseCaseOutput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateVehicleOutput"/> class.
        /// </summary>
        /// <param name="id">ID.</param>
        /// <param name="name">Name.</param>
        /// <param name="modelYear">ModelYear.</param>
        public CreateVehicleOutput(int id, string name, int modelYear)
        {
            Id = id;
            Name = name;
            ModelYear = modelYear;
        }

        /// <summary>
        /// Gets the id.
        /// </summary>
        public int Id { get; private set; }

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
