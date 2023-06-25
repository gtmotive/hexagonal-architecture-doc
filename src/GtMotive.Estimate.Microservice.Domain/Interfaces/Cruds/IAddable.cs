namespace GtMotive.Estimate.Microservice.Domain.Interfaces.Cruds
{
    /// <summary>
    /// Containts the signature for addable methods.
    /// </summary>
    /// <typeparam name="TEntity">Entity to make addable.</typeparam>
    public interface IAddable<in TEntity>
    {
        /// <summary>
        /// Signature to add one entity.
        /// </summary>
        /// <param name="entity">Entity to add.</param>
        void Add(TEntity entity);
    }
}
