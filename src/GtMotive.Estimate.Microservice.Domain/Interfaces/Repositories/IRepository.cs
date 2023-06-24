using GtMotive.Estimate.Microservice.Domain.Interfaces.Cruds;

namespace GtMotive.Estimate.Microservice.Domain.Interfaces.Repositories
{
    /// <summary>
    /// Containts the signature for the crud repository methods.
    /// </summary>
    /// <typeparam name="TEntidy">Respository's Entity.</typeparam>
    /// <typeparam name="TEntityId">Respository's Entity Identidy.</typeparam>
    public interface IRepository<TEntidy, TEntityId>
        : IAddable<TEntidy>, IEditable<TEntidy>, IDeletable<TEntidy>, IListable<TEntidy, TEntityId>
    {
    }
}
