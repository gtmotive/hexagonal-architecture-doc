using System.Collections.Generic;
using GtMotive.Estimate.Microservice.Domain.Common;

namespace GtMotive.Estimate.Microservice.Domain.Entities
{
    /// <summary>
    /// VehicleState class.
    /// </summary>
    public class VehicleState : BaseDomainModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VehicleState"/> class.
        /// </summary>
        public VehicleState()
        {
            Vehicles = new HashSet<Vehicle>();
        }

        /// <summary>
        /// Gets or sets Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or inits Vehicles.
        /// </summary>
        public virtual ICollection<Vehicle> Vehicles { get; init; }
    }
}
