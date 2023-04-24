using System;
using System.ComponentModel.DataAnnotations;
using GtMotive.Estimate.Microservice.Domain.Common;
using GtMotive.Estimate.Microservice.Domain.Entities.Auth;

namespace GtMotive.Estimate.Microservice.Domain.Entities
{
    /// <summary>
    /// Vehicle class.
    /// </summary>
    public class Reservation : BaseDomainModel
    {
        /// <summary>
        /// Gets or sets date from.
        /// </summary>
        public DateTime DateFrom { get; set; }

        /// <summary>
        /// Gets or sets date to.
        /// </summary>
        public DateTime DateTo { get; set; }

        /// <summary>
        /// Gets or sets Vehicle Id.
        /// </summary>
        [Required]
        public int VehicleId { get; set; }

        /// <summary>
        /// Gets or sets User Id.
        /// </summary>
        [Required]
        public Guid UserId { get; set; }

        /// <summary>
        /// Gets or sets Vehicle related object.
        /// </summary>
        public virtual Vehicle Vehicle { get; set; }

        /// <summary>
        /// Gets or sets User related object.
        /// </summary>
        public virtual User User { get; set; }
    }
}
