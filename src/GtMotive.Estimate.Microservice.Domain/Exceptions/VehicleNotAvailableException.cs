using System;
using System.Diagnostics.CodeAnalysis;

namespace GtMotive.Estimate.Microservice.Domain.Exceptions
{
    /// <summary>
    /// Vehicle not available exception.
    /// </summary>
    [Serializable]
    [SuppressMessage("Design", "CA1032:Implementar constructores de excepción estándar", Justification = "DomainException is a base class for all domain exceptions.")]
    [SuppressMessage("Usage", "CA2229:Implementar constructores de serialización", Justification = "DomainException is a base class for all domain exceptions.")]
    [SuppressMessage("Major Code Smell", "S3925:\"ISerializable\" should be implemented correctly", Justification = "DomainException is a base class for all domain exceptions.")]
    public class VehicleNotAvailableException : DomainException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VehicleNotAvailableException"/> class.
        /// </summary>
        public VehicleNotAvailableException()
            : base($"Vehicle is not available.")
        {
        }
    }
}
