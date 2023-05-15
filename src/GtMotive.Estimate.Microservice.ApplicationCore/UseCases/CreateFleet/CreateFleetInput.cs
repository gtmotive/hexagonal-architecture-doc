namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateFleet
{
    /// <summary>
    /// Create Fleet Input.
    /// </summary>
    public class CreateFleetInput : IUseCaseInput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateFleetInput"/> class.
        /// </summary>
        /// <param name="name">Name.</param>
        public CreateFleetInput(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        public string Name { get; private set; }
    }
}
