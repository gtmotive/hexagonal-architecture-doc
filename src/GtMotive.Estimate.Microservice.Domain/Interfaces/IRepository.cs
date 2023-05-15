namespace GtMotive.Estimate.Microservice.Domain.Interfaces
{
    /// <summary>
    /// Interface for custom repositories.
    /// </summary>
    /// <typeparam name="T">Type.</typeparam>
    public interface IRepository<T> : IRepositoryBase<T>
        where T : class, IAggregateRoot
    {
    }
}
