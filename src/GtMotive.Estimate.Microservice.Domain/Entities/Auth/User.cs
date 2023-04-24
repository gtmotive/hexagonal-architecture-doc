using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace GtMotive.Estimate.Microservice.Domain.Entities.Auth
{
    /// <summary>
    /// User.
    /// </summary>
    public class User : IdentityUser<Guid>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        public User()
        {
            Reservations = new HashSet<Reservation>();
        }

        /// <summary>
        /// Gets or sets Firstname.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets LastName.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or inits Reservations.
        /// </summary>
        public virtual ICollection<Reservation> Reservations { get; init; }
    }
}
