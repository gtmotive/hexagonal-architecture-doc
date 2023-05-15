namespace GtMotive.Estimate.Microservice.Domain.SeedWork
{
    /// <summary>
    /// Enumeration base class.
    /// </summary>
    public abstract class Enumeration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Enumeration"/> class.
        /// Default Constructor.
        /// </summary>
        /// <param name="id">IDentifier.</param>
        /// <param name="name">Name.</param>
        protected Enumeration(int id, string name)
        {
            (Id, Name) = (id, name);
        }

        /// <summary>
        /// Gets the Identifier.
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// Gets the name.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// ToString method.
        /// </summary>
        /// <returns>Tha name.</returns>
        public override string ToString() => Name;
    }
}
