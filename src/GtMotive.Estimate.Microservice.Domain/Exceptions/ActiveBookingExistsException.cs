using System;
using System.Diagnostics.CodeAnalysis;

namespace GtMotive.Estimate.Microservice.Domain.Exceptions
{
    /// <summary>
    /// Exception for active booking exists. A customer can't have more than one active booking.
    /// </summary>
    [Serializable]
    [SuppressMessage("Design", "CA1032:Implementar constructores de excepción estándar", Justification = "DomainException is a base class for all domain exceptions.")]
    [SuppressMessage("Usage", "CA2229:Implementar constructores de serialización", Justification = "DomainException is a base class for all domain exceptions.")]
    [SuppressMessage("Major Code Smell", "S3925:\"ISerializable\" should be implemented correctly", Justification = "DomainException is a base class for all domain exceptions.")]
    public class ActiveBookingExistsException : DomainException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ActiveBookingExistsException"/> class.
        /// </summary>
        public ActiveBookingExistsException()
            : base("Active booking already exists.")
        {
        }
    }
}
