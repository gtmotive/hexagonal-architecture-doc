using GtMotive.Estimate.Microservice.Domain.Exceptions;
using GtMotive.Estimate.Microservice.Domain.SeedWork;

namespace GtMotive.Estimate.Microservice.Domain.ValueObjects
{
    /// <summary>
    /// Name value object.
    /// </summary>
    public class Name : ValueObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Name"/> class.
        /// </summary>
        /// <param name="text">Text.</param>
        public Name(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                throw new NameShouldNotBeEmptyException($"The {nameof(text)} field is required.");
            }

            Text = text;
        }

        /// <summary>
        /// Gets the text value for the name.
        /// </summary>
        /// <returns>The text.</returns>
        public string Text { get; private set; }
    }
}
