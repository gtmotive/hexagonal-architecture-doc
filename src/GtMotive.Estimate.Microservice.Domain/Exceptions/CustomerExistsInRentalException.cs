using System;
using System.Diagnostics.CodeAnalysis;

namespace GtMotive.Estimate.Microservice.Domain.Exceptions
{
    /// <summary>
    /// NameShouldNotBeEmptyException class.
    /// </summary>
    [ExcludeFromCodeCoverage]
    [Serializable]
    public class CustomerExistsInRentalException : DomainException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerExistsInRentalException"/> class.
        /// NameShouldNotBeEmptyException constructor.
        /// </summary>
        /// <param name="message">Message.</param>
        public CustomerExistsInRentalException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerExistsInRentalException"/> class.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="innerException">Inner Exception.</param>
        public CustomerExistsInRentalException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerExistsInRentalException"/> class.
        /// </summary>
        public CustomerExistsInRentalException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerExistsInRentalException"/> class.
        /// </summary>
        /// <param name="serializationInfo">Serializtion Info.</param>
        /// <param name="streamingContext">Streaming Context.</param>
        protected CustomerExistsInRentalException(System.Runtime.Serialization.SerializationInfo serializationInfo, System.Runtime.Serialization.StreamingContext streamingContext)
            : base(serializationInfo, streamingContext)
        {
        }
    }
}
