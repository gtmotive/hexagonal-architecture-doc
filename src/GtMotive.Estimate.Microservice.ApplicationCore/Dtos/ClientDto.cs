namespace GtMotive.Estimate.Microservice.ApplicationCore.Dtos
{
    /// <summary>
    /// Client DTO.
    /// </summary>
    public class ClientDto
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClientDto"/> class.
        /// </summary>
        /// <param name="name">Client name.</param>
        /// <param name="email">CLient Email.</param>
        /// <param name="phone">Client phone.</param>
        public ClientDto(string name, string email, string phone)
        {
            Name = name;
            Email = email;
            Phone = phone;
        }

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
    }
}
