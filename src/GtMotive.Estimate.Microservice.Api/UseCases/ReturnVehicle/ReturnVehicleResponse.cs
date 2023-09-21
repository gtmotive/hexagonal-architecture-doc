namespace GtMotive.Estimate.Microservice.Api.UseCases.ReturnVehicle
{
    public class ReturnVehicleResponse
    {
        public ReturnVehicleResponse(string msg)
        {
            Message = msg;
        }

        public string Message { get; private set; }
    }
}
