using System;
using System.Collections.ObjectModel;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Interfaces.Repositories;
using GtMotive.Estimate.Microservice.Domain.Entities;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Implementation
{
    /// <summary>
    /// Vehicle service implementation.
    /// </summary>
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _repoVehicle;

        /// <summary>
        /// Initializes a new instance of the <see cref="VehicleService"/> class.
        /// </summary>
        /// <param name="repoVehicle">vehicle Repository.</param>
        public VehicleService(IVehicleRepository repoVehicle)
        {
            _repoVehicle = repoVehicle;
        }

        /// <summary>
        /// Create vehicle.
        /// </summary>
        /// <param name="entity">entity to create.</param>
        public void Add(Vehicle entity)
        {
            if (entity == null)
            {
                throw new ArgumentException("Argumentos no validos");
            }

            var diff = DateTime.Now - entity.ManufacturingDate;
            if (diff.TotalDays > 5 * 365)
            {
                throw new ArgumentException("No se admiten vehiculos con más 5 años desde su fabricación");
            }

            _repoVehicle.Add(entity);
        }

        /// <summary>
        /// Query the list of vehicles availables.
        /// </summary>
        /// <returns>List of vehicles.</returns>
        public Collection<Vehicle> List()
        {
            return _repoVehicle.List();
        }

        /// <summary>
        /// Query the a vehicles by id.
        /// </summary>
        /// <param name="id">vehicle Identify.</param>
        /// <returns>Vehicle selected.</returns>
        public Vehicle SelectById(int id)
        {
            return _repoVehicle.SelectById(id);
        }
    }
}
