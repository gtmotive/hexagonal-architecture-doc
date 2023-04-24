using System;
using MediatR;

namespace GtMotive.Estimate.Microservice.ApplicationCore.Features.Vehicles.Commands.CreateVehicle
{
    /// <summary>
    /// CreateVehicleCommand.
    /// </summary>
    public class CreateVehicleCommand : IRequest<int?>
    {
        /// <summary>
        /// Gets or sets RegistrationNumber.
        /// </summary>
        public string RegistrationNumber { get; set; }

        /// <summary>
        /// Gets or sets ManufacturingDate.
        /// </summary>
        public DateTime ManufacturingDate { get; set; }
    }
}
