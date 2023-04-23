using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using GtMotive.Estimate.Microservice.Domain.Common;

namespace GtMotive.Estimate.Microservice.Domain.Entities
{
    /// <summary>
    /// Vehicle class.
    /// </summary>
    public class Vehicle : BaseDomainModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Vehicle"/> class.
        /// </summary>
        public Vehicle()
        {
            Reservations = new HashSet<Reservation>();
        }

        /// <summary>
        /// Gets or sets RegistrationNumber.
        /// </summary>
        [MaxLength(50)]
        [Required]
        public string RegistrationNumber { get; set; }

        /// <summary>
        /// Gets or sets ManufacturingDate.
        /// </summary>
        [Required]
        public DateTime ManufacturingDate { get; set; }

        /// <summary>
        /// Gets or sets VehicleState Id.
        /// </summary>
        [Required]
        [DefaultValue(1)]
        public int VehicleStateId { get; set; }

        /// <summary>
        /// Gets or sets VehicleState related object.
        /// </summary>
        public virtual VehicleState VehicleState { get; set; }

        /// <summary>
        /// Gets or inits Reservations.
        /// </summary>
        public virtual ICollection<Reservation> Reservations { get; init; }
    }
}
