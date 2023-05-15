using System;
using System.Diagnostics.CodeAnalysis;

namespace GtMotive.Estimate.Microservice.Domain.Exceptions
{
    /// <summary>
    /// NameShouldNotBeEmptyException class.
    /// </summary>
    [ExcludeFromCodeCoverage]
    [Serializable]
    public class VehicleNotAllowedInFleetException : DomainException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VehicleNotAllowedInFleetException"/> class.
        /// NameShouldNotBeEmptyException constructor.
        /// </summary>
        /// <param name="message">Message.</param>
        public VehicleNotAllowedInFleetException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VehicleNotAllowedInFleetException"/> class.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="innerException">Inner Exception.</param>
        public VehicleNotAllowedInFleetException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VehicleNotAllowedInFleetException"/> class.
        /// </summary>
        public VehicleNotAllowedInFleetException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VehicleNotAllowedInFleetException"/> class.
        /// </summary>
        /// <param name="serializationInfo">Serializtion Info.</param>
        /// <param name="streamingContext">Streaming Context.</param>
        protected VehicleNotAllowedInFleetException(System.Runtime.Serialization.SerializationInfo serializationInfo, System.Runtime.Serialization.StreamingContext streamingContext)
            : base(serializationInfo, streamingContext)
        {
        }
    }
}
