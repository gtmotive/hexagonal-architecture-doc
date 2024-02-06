using System;
using System.Globalization;

namespace GtMotive.Estimate.Microservice.Domain.ValueObjects
{
    /// <summary>
    /// Represents the year a vehicle was manufactured.
    /// </summary>
    public sealed class ManufactureYear : IEquatable<ManufactureYear>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ManufactureYear"/> class.
        /// </summary>
        /// <param name="value">The year the vehicle was manufactured.</param>
        public ManufactureYear(int value)
        {
            if (value < 1900 || value > DateTime.UtcNow.Year)
            {
                throw new ArgumentException("Invalid manufacture year. Must be greater than 1900", nameof(value));
            }

            Value = value;
        }

        private ManufactureYear()
        {
        }

        /// <summary>
        /// Gets the manufacture year value.
        /// </summary>
        public int Value { get; private set; }

        /// <inheritdoc/>
        public bool Equals(ManufactureYear other) => other != null && Value == other.Value;

        /// <inheritdoc/>
        public override bool Equals(object obj) => Equals(obj as ManufactureYear);

        /// <inheritdoc/>
        public override int GetHashCode() => Value.GetHashCode();

        /// <inheritdoc/>
        public override string ToString() => Value.ToString(CultureInfo.InvariantCulture);
    }
}
