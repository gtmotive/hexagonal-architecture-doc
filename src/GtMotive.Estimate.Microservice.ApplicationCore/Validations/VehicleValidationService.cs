using System;
using GtMotive.Estimate.Microservice.ApplicationCore.Interfaces;

namespace GtMotive.Estimate.Microservice.ApplicationCore.Services
{
    /// <summary>
    /// Service responsible for validating if a vehicle meets the age restriction.
    /// </summary>
    public class VehicleValidationService : IVehicleValidationService
    {
        /// <summary>
        /// Method that checks if the vehicle's manufacture year is within 5 years.
        /// </summary>
        /// <param name="manufactureYear">The manufacture year of the vehicle.</param>
        /// <returns>True if the vehicle meets the age restriction, false otherwise.</returns>
        public bool IsVehicleManufacturedWithin5Years(int manufactureYear)
        {
            var currentYear = DateTime.Now.Year;

            var yearsDifference = currentYear - manufactureYear;

            return yearsDifference <= 5;
        }
    }
}
