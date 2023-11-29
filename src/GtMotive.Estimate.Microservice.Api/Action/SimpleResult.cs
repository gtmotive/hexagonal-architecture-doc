using System;

namespace GtMotive.Estimate.Microservice.Api.Action
{
    public class SimpleResult
    {
        public bool IsSuccess { get; protected set; }

        public bool IsError => !IsSuccess;

        public string ErrorMessage { get; protected set; }

        public void Ok()
        {
            IsSuccess = true;
        }

        public void Error(string errorMessage)
        {
            IsSuccess = false;
            ErrorMessage = errorMessage;
        }

        public void Error(Exception ex)
        {
            IsSuccess = false;
            ErrorMessage = ex.Message;
        }
    }
}
