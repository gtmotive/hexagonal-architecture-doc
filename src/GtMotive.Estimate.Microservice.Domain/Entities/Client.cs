using System.Collections.ObjectModel;

namespace GtMotive.Estimate.Microservice.Domain.Entities
{
    /// <summary>
    /// Represents the domain model of a Client.
    /// </summary>
    public class Client
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Client"/> class.
        /// </summary>
        /// <param name="name">Client name.</param>
        /// <param name="email">CLient Email.</param>
        /// <param name="phone">Client phone.</param>
        public Client(string name, string email, string phone)
        {
            Name = name;
            Email = email;
            Phone = phone;
        }

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
