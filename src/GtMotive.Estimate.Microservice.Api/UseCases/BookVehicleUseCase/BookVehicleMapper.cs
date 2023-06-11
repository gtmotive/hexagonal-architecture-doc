using System;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.BookVehicleUseCase;

namespace GtMotive.Estimate.Microservice.Api.UseCases.BookVehicleUseCase
{
    public static class BookVehicleMapper
    {
        public static BookVehicleResponse Map(BookVehicleOutput src)
        {
            return src is null
                ? throw new ArgumentNullException(nameof(src))
                : new BookVehicleResponse(src.Message);
        }
    }
}
