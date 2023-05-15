namespace GtMotive.Estimate.Microservice.Api.UseCases.CreateFleet
{
    public class CreateFleetResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateFleetResponse"/> class.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <param name="name">Name.</param>
        public CreateFleetResponse(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; private set; }

        public string Name { get; private set; }
    }
}
