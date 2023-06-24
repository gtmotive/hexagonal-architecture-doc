using System.Collections.ObjectModel;

namespace GtMotive.Estimate.Microservice.Domain.Entities
{
    /// <summary>
    /// Represents the domain model of a Client.
    /// </summary>
    public class Client
    {
        /// <summary>
        /// Gets or Sets client Identify.
        /// </summary>
        public int ClientId { get; set; }

        /// <summary>
        /// Gets or Sets client name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets client email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or Sets client phone.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Gets client rentals.
        /// </summary>
        public Collection<Rental> Rentals { get; private set; }
    }
}
