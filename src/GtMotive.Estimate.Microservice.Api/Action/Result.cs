namespace GtMotive.Estimate.Microservice.Api.Action
{
    public class Result<T> : SimpleResult
    {
        public T Data { get; set; }

        public void Ok(T data)
        {
            IsSuccess = true;
            Data = data;
        }
    }
}
