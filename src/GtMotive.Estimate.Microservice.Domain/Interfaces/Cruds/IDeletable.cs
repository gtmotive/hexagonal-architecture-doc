namespace GtMotive.Estimate.Microservice.Domain.Interfaces.Cruds
{
    /// <summary>
    /// Containts the signature for deletable methods.
    /// </summary>
    /// <typeparam name="TEntityId">TEntity Identify to make deletable.</typeparam>
    public interface IDeletable<in TEntityId>
    {
        /// <summary>
        /// Signature to delete one entity by id.
        /// </summary>
        /// <param name="id">TEntity Identify to delete.</param>
        void Delete(TEntityId id);
    }
}
