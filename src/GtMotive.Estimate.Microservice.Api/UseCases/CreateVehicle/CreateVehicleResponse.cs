namespace GtMotive.Estimate.Microservice.Api.UseCases.CreateVehicle
{
    public class CreateVehicleResponse
    {
        public CreateVehicleResponse(int id, string name, int modelYear)
        {
            Id = id;
            Name = name;
            ModelYear = modelYear;
        }

        public int Id { get; private set; }

        public string Name { get; private set; }

        /// <summary>
        /// Gets the model Year.
        /// </summary>
        public int ModelYear { get; private set; }
    }
}
