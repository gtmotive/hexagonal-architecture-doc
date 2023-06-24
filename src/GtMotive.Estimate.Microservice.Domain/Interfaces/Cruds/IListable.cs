using System.Collections.ObjectModel;

namespace GtMotive.Estimate.Microservice.Domain.Interfaces.Cruds
{
    /// <summary>
    /// Containts the signature for list methods.
    /// </summary>
    /// <typeparam name="TEntity">TEntity to make listable.</typeparam>
    /// <typeparam name="TEntityId">TEntity Identify to make listable.</typeparam>
    public interface IListable<TEntity, TEntityId>
    {
        /// <summary>
        /// asdasdasd.
        /// </summary>
        /// <returns>List of TEntities.</returns>
        Collection<TEntity> List();

        /// <summary>
        /// Select one TEntity by id.
        /// </summary>
        /// <param name="id">Entity id to select.</param>
        /// <returns>TEntity selected.</returns>
        TEntity SelectById(TEntityId id);
    }
}
