namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.BookVehicleUseCase
{
    /// <summary>
    /// Interface to define the Book Vehicle Output Port.
    /// </summary>
    public interface IBookVehicleOutputPort : IOutputPortStandard<BookVehicleOutput>, IOutputPortNotFound, IOutputPortBadRequest
    {
    }
}
