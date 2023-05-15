namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateFleet
{
    /// <summary>
    /// CreateFleetOutput.
    /// </summary>
    public class CreateFleetOutput : IUseCaseOutput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateFleetOutput"/> class.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <param name="name">Name.</param>
        public CreateFleetOutput(int id, string name)
        {
            Id = id;
            Name = name;
        }

        /// <summary>
        /// Gets the id.
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// Gets the name.
        /// </summary>
        public string Name { get; private set; }
    }
}
