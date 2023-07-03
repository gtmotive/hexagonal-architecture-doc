namespace GtMotive.Estimate.Microservice.Domain.Interfaces.Cruds
{
    /// <summary>
    /// Containts the signature for editable methods.
    /// </summary>
    /// <typeparam name="TEntity">Entity to make addable.</typeparam>
    public interface IEditable<in TEntity>
    {
        /// <summary>
        /// Signature to edit one entity.
        /// </summary>
        /// <param name="entity">Entity to edit.</param>
        void Edit(TEntity entity);
    }
}
