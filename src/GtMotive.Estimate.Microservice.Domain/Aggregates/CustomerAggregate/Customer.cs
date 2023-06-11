using System;
using System.Collections.Generic;
using System.Linq;
using GtMotive.Estimate.Microservice.Domain.Exceptions;
using GtMotive.Estimate.Microservice.Domain.Interfaces;

namespace GtMotive.Estimate.Microservice.Domain.Aggregates.CustomerAggregate
{
    /// <summary>
    /// Customer aggregate root.
    /// </summary>
    public class Customer : Entity, IAggregateRoot
    {
        private readonly List<VehicleBooking> _bookings = new();

        /// <summary>
        /// Initializes a new instance of the <see cref="Customer"/> class.
        /// MongoDb deserialization constructor.
        /// </summary>
        /// <param name="name">Customer full name.</param>
        public Customer(string name)
        {
            Name = name;

            Id = Guid.NewGuid();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Customer"/> class.
        /// MongoDb deserialization constructor.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <param name="name">Name.</param>
        /// <param name="bookings">Bookings.</param>
        public Customer(Guid id, string name, IEnumerable<VehicleBooking> bookings)
        {
            Id = id;
            Name = name;
            _bookings = bookings.ToList();
        }

        /// <summary>
        /// Gets the customer identifier.
        /// </summary>
        public Guid Id { get; private init; }

        /// <summary>
        /// Gets the customer name.
        /// </summary>
        public string Name { get; private init; }

        /// <summary>
        /// Gets the bookings.
        /// </summary>
        public IReadOnlyList<VehicleBooking> Bookings => _bookings.AsReadOnly();

        /// <summary>
        /// Booking a vehicle.
        /// </summary>
        /// <param name="vehicleId">Vehicle identifier.</param>
        /// <param name="returnDate">Return date.</param>
        /// <exception cref="ActiveBookingExistsException">ActiveBookingExistsException.</exception>
        public void BookVehicle(Guid vehicleId, DateOnly returnDate)
        {
            // Validate there are no active bookings
            if (_bookings.Any(b => b.IsActive))
            {
                throw new ActiveBookingExistsException();
            }

            var booking = new VehicleBooking(DateOnly.FromDateTime(DateTime.UtcNow), returnDate, vehicleId);

            _bookings.Add(booking);
        }
    }
}
