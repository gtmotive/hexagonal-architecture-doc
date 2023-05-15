namespace GtMotive.Estimate.Microservice.Domain.SeedWork
{
    /// <summary>
    /// Entity base class for domain objects.
    /// </summary>
    public abstract class Entity
    {
        /// <summary>
        /// Gets or sets unique Identifier property.
        /// </summary>
        public virtual int Id { get; protected set; }
    }
}
