namespace GtMotive.Estimate.Microservice.Domain.Interfaces.Cruds
{
    /// <summary>
    /// Containts the signature for deletable methods.
    /// </summary>
    /// <typeparam name="TEntity">TEntity to make deletable.</typeparam>
    public interface IDeletable<in TEntity>
    {
        /// <summary>
        /// Signature to delete one entity by id.
        /// </summary>
        /// <param name="entity">TEntity to delete.</param>
        void Delete(TEntity entity);
    }
}
