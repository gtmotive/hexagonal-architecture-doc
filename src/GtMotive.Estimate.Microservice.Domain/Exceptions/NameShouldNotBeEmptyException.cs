using System;
using System.Diagnostics.CodeAnalysis;

namespace GtMotive.Estimate.Microservice.Domain.Exceptions
{
    /// <summary>
    /// NameShouldNotBeEmptyException class.
    /// </summary>
    [ExcludeFromCodeCoverage]
    [Serializable]
    public class NameShouldNotBeEmptyException : DomainException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NameShouldNotBeEmptyException"/> class.
        /// NameShouldNotBeEmptyException constructor.
        /// </summary>
        /// <param name="message">Message.</param>
        public NameShouldNotBeEmptyException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NameShouldNotBeEmptyException"/> class.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="innerException">Inner Exception.</param>
        public NameShouldNotBeEmptyException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NameShouldNotBeEmptyException"/> class.
        /// </summary>
        public NameShouldNotBeEmptyException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NameShouldNotBeEmptyException"/> class.
        /// </summary>
        /// <param name="serializationInfo">Serializtion Info.</param>
        /// <param name="streamingContext">Streaming Context.</param>
        protected NameShouldNotBeEmptyException(System.Runtime.Serialization.SerializationInfo serializationInfo, System.Runtime.Serialization.StreamingContext streamingContext)
            : base(serializationInfo, streamingContext)
        {
        }
    }
}
