using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.Features.Vehicles.Common
{
    /// <summary>
    /// VehicleResponse class.
    /// </summary>
    public class VehicleResponse
    {
        /// <summary>
        /// Gets or sets Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets RegistrationNumber.
        /// </summary>
        public string RegistrationNumber { get; set; }

        /// <summary>
        /// Gets or sets ManufacturingDate.
        /// </summary>
        public DateTime ManufacturingDate { get; set; }

        /// <summary>
        /// Gets or sets Vehicle state id.
        /// </summary>
        public int VehicleStateId { get; set; }

        /// <summary>
        /// Gets or sets Vehicle state.
        /// </summary>
        public string VehicleStateName { get; set; }
    }
}
