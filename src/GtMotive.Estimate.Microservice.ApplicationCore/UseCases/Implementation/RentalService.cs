﻿using System;
using System.Collections.ObjectModel;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.Interfaces.Repositories;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Implementation
{
    /// <summary>
    /// Rental service implementation.
    /// </summary>
    public class RentalService : IRentalService
    {
        private readonly IRepository<Rental, Guid> _repoRental;

        /// <summary>
        /// Initializes a new instance of the <see cref="RentalService"/> class.
        /// </summary>
        /// <param name="repoRental">Rental Repository.</param>
        public RentalService(IRepository<Rental, Guid> repoRental)
        {
            _repoRental = repoRental;
        }

        /// <summary>
        /// Rent a vehicle.
        /// </summary>
        /// <param name="entity">Rental.</param>
        /// <returns>Rental created.</returns>
        public Rental Add(Rental entity)
        {
            return _repoRental.Add(entity);
        }

        /// <summary>
        /// Return a vehicle.
        /// </summary>
        /// <param name="entity">vehicle to return.</param>
        public void Delete(Rental entity)
        {
            _repoRental.Delete(entity);
        }

        /// <summary>
        /// Query the list of rentals.
        /// </summary>
        /// <returns>List of vehicles.</returns>
        public Collection<Rental> List()
        {
            return _repoRental.List();
        }

        /// <summary>
        /// Query the a rental by id.
        /// </summary>
        /// <param name="id">vehicle Identify.</param>
        /// <returns>Vehicle selected.</returns>
        public Rental SelectById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}