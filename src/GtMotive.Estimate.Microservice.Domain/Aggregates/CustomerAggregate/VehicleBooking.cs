using System;

namespace GtMotive.Estimate.Microservice.Domain.Aggregates.CustomerAggregate
{
    /// <summary>
    /// Booking entity.
    /// </summary>
    public class VehicleBooking : Entity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VehicleBooking"/> class.
        /// </summary>
        /// <param name="bookingDate">Booking date.</param>
        /// <param name="returnDate">Return date.</param>
        /// <param name="vehicleId">Vehicle identifier.</param>
        public VehicleBooking(DateOnly bookingDate, DateOnly returnDate, Guid vehicleId)
        {
            BookingDate = bookingDate;
            ReturnDate = returnDate;
            VehicleId = vehicleId;
            IsActive = true;
            Id = Guid.NewGuid();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VehicleBooking"/> class.
        /// MongoDb deserialization constructor.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <param name="bookingDate">BookingDate.</param>
        /// <param name="returnDate">ReturnDate.</param>
        /// <param name="vehicleId">VehicleId.</param>
        /// <param name="isActive">IsActive.</param>
        public VehicleBooking(Guid id, DateOnly bookingDate, DateOnly returnDate, Guid vehicleId, bool isActive)
        {
            Id = id;
            BookingDate = bookingDate;
            ReturnDate = returnDate;
            VehicleId = vehicleId;
            IsActive = isActive;
        }

        /// <summary>
        /// Gets the booking identifier.
        /// </summary>
        public Guid Id { get; private init; }

        /// <summary>
        /// Gets the booking date.
        /// </summary>
        public DateOnly BookingDate { get; private init; }

        /// <summary>
        /// Gets the return date.
        /// </summary>
        public DateOnly ReturnDate { get; private init; }

        /// <summary>
        /// Gets the vehicle identifier.
        /// </summary>
        public Guid VehicleId { get; private init; }

        /// <summary>
        /// Gets a value indicating whether the booking is active. A reservation is active if the vehicle has not been returned.
        /// </summary>
        public bool IsActive { get; private set; }

        /// <summary>
        /// Disable booking. Call this method when the vehicle is returned.
        /// </summary>
        public void Disable()
        {
            IsActive = false;
        }
    }
}
