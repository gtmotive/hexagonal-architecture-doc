using System;

namespace GtMotive.Estimate.Microservice.Domain.ValueObjects
{
    /// <summary>
    /// Represents a vehicle's make as a value object.
    /// </summary>
    public sealed class Make : IEquatable<Make>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Make"/> class.
        /// </summary>
        /// <param name="value">The make value.</param>
        public Make(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Make cannot be empty.", nameof(value));
            }

            Value = value;
        }

        private Make()
        {
        }

        /// <summary>
        /// Gets the make value.
        /// </summary>
        public string Value { get; private set; }

        /// <inheritdoc/>
        public bool Equals(Make other) => other != null && Value == other.Value;

        /// <inheritdoc/>
        public override bool Equals(object obj) => Equals(obj as Make);

        /// <inheritdoc/>
        public override int GetHashCode() => Value.GetHashCode(StringComparison.InvariantCulture);

        /// <inheritdoc/>
        public override string ToString() => Value;
    }
}
