namespace GtMotive.Estimate.Microservice.ApplicationCore.Interfaces
{
    /// <summary>
    /// Service responsible for validating if a vehicle meets the age restriction.
    /// </summary>
    public interface IVehicleValidationService
    {
        /// <summary>
        /// Checks if a vehicle meets the age restriction.
        /// </summary>
        /// <param name="manufactureYear">The manufacture year of the vehicle.</param>
        /// <returns>True if the vehicle meets the age restriction, false otherwise.</returns>
        bool IsVehicleManufacturedWithin5Years(int manufactureYear);
    }
}
