using System;
using System.Diagnostics.CodeAnalysis;

namespace GtMotive.Estimate.Microservice.Domain.Exceptions
{
    /// <summary>
    /// EnumerationException class.
    /// </summary>
    [ExcludeFromCodeCoverage]
    [Serializable]
    public class NotFoundEntityException : DomainException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NotFoundEntityException"/> class.
        /// NameShouldNotBeEmptyException constructor.
        /// </summary>
        /// <param name="message">Message.</param>
        public NotFoundEntityException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NotFoundEntityException"/> class.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="innerException">Inner Exception.</param>
        public NotFoundEntityException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NotFoundEntityException"/> class.
        /// </summary>
        public NotFoundEntityException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NotFoundEntityException"/> class.
        /// </summary>
        /// <param name="serializationInfo">Serializtion Info.</param>
        /// <param name="streamingContext">Streaming Context.</param>
        protected NotFoundEntityException(System.Runtime.Serialization.SerializationInfo serializationInfo, System.Runtime.Serialization.StreamingContext streamingContext)
            : base(serializationInfo, streamingContext)
        {
        }
    }
}
