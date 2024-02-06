using System;

namespace GtMotive.Estimate.Microservice.Domain.ValueObjects
{
    /// <summary>
    /// Represents a vehicle's license plate as a value object.
    /// </summary>
    public sealed class LicensePlate : IEquatable<LicensePlate>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LicensePlate"/> class.
        /// </summary>
        /// <param name="value">The license plate value.</param>
        public LicensePlate(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("License plate cannot be empty.", nameof(value));
            }

            Value = value;
        }

        private LicensePlate()
        {
        }

        /// <summary>
        /// Gets the license plate value.
        /// </summary>
        public string Value { get; private set; }

        /// <inheritdoc/>
        public bool Equals(LicensePlate other) => other != null && Value == other.Value;

        /// <inheritdoc/>
        public override bool Equals(object obj) => Equals(obj as LicensePlate);

        /// <inheritdoc/>
        public override int GetHashCode() => Value.GetHashCode(StringComparison.InvariantCulture);

        /// <inheritdoc/>
        public override string ToString() => Value;
    }
}
