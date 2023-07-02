using System;

namespace GtMotive.Estimate.Microservice.Domain.Entities
{
    /// <summary>
    /// Vehicle Manufacturing date class.
    /// </summary>
    public class VehicleManufacturingDate
    {
        private DateTime val;

        /// <summary>
        /// Initializes a new instance of the <see cref="VehicleManufacturingDate"/> class.
        /// Constructor.
        /// </summary>
        /// <param name="manufacturingDate">Manufacturing date.</param>
        public VehicleManufacturingDate(DateTime manufacturingDate)
        {
            EnsureDate(manufacturingDate);

            val = manufacturingDate;
        }

        /// <summary>
        /// Gets or sets value.
        /// </summary>
        public DateTime Value
        {
            get => val;
            set
            {
                EnsureDate(value);
                val = value;
            }
        }

        /// <summary>
        /// Ensure manufacturing date.
        /// </summary>
        /// <param name="manufacturingDate">Manufacturing date.</param>
        /// <exception cref="ArgumentException">manufacturing date limitation.</exception>
        private static void EnsureDate(DateTime manufacturingDate)
        {
            var diff = DateTime.Now - manufacturingDate;
            if (diff.TotalDays > 5 * 365)
            {
                throw new ArgumentException("No se admiten vehiculos con más 5 años desde su fabricación");
            }
        }
    }
}
