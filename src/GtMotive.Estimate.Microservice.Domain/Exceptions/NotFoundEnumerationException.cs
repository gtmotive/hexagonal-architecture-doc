using System;
using System.Diagnostics.CodeAnalysis;

namespace GtMotive.Estimate.Microservice.Domain.Exceptions
{
    /// <summary>
    /// EnumerationException class.
    /// </summary>
    [ExcludeFromCodeCoverage]
    [Serializable]
    public class NotFoundEnumerationException : DomainException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NotFoundEnumerationException"/> class.
        /// NameShouldNotBeEmptyException constructor.
        /// </summary>
        /// <param name="message">Message.</param>
        public NotFoundEnumerationException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NotFoundEnumerationException"/> class.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="innerException">Inner Exception.</param>
        public NotFoundEnumerationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NotFoundEnumerationException"/> class.
        /// </summary>
        public NotFoundEnumerationException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NotFoundEnumerationException"/> class.
        /// </summary>
        /// <param name="serializationInfo">Serializtion Info.</param>
        /// <param name="streamingContext">Streaming Context.</param>
        protected NotFoundEnumerationException(System.Runtime.Serialization.SerializationInfo serializationInfo, System.Runtime.Serialization.StreamingContext streamingContext)
            : base(serializationInfo, streamingContext)
        {
        }
    }
}
