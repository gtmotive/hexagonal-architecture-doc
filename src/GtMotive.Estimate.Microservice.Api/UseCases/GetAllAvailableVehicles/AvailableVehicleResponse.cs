namespace GtMotive.Estimate.Microservice.Api.UseCases.GetAllAvailableVehicles
{
    public class AvailableVehicleResponse
    {
        public AvailableVehicleResponse(int id, string name, int modelYear)
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
