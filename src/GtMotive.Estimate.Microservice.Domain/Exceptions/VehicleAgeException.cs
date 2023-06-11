using System;
using System.Diagnostics.CodeAnalysis;

namespace GtMotive.Estimate.Microservice.Domain.Exceptions
{
    /// <summary>
    /// Exception for vehicle age. Vehicle can't be older than 5 years.
    /// </summary>
    [Serializable]
    [SuppressMessage("Design", "CA1032:Implementar constructores de excepción estándar", Justification = "DomainException is a base class for all domain exceptions.")]
    [SuppressMessage("Usage", "CA2229:Implementar constructores de serialización", Justification = "DomainException is a base class for all domain exceptions.")]
    [SuppressMessage("Major Code Smell", "S3925:\"ISerializable\" should be implemented correctly", Justification = "DomainException is a base class for all domain exceptions.")]
    public class VehicleAgeException : DomainException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VehicleAgeException"/> class.
        /// </summary>
        /// <param name="manufacturingDate">Manufacturing date.</param>
        public VehicleAgeException(DateOnly manufacturingDate)
            : base($"Vehicle can't be older than 5 years. Manufacturing date: {manufacturingDate:d}.")
        {
            ManufacturingDate = manufacturingDate;
        }

        /// <summary>
        /// Gets the manufacturing date.
        /// </summary>
        public DateOnly ManufacturingDate { get; }
    }
}
