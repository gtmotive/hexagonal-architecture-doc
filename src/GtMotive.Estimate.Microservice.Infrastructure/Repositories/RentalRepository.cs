using System;
using System.Collections.ObjectModel;
using System.Linq;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Interfaces.Repositories;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Infrastructure.SqlServer.Context;

namespace GtMotive.Estimate.Microservice.Infrastructure.Repositories
{
    public class RentalRepository : IRentalRepository
    {
        private readonly RentingContext context;

        public RentalRepository(RentingContext context)
        {
            this.context = context;
        }

        public Rental Add(Rental entity)
        {
            if (entity != null)
            {
                context.Rentals.Add(entity);
                context.SaveChanges();
            }

            return entity;
        }

        public void Delete(Rental entity)
        {
            if (entity != null)
            {
                context.Rentals.Remove(entity);
                context.SaveChanges();
            }
        }

        public void Edit(Rental entity)
        {
            throw new NotImplementedException();
        }

        public Collection<Rental> List()
        {
            throw new NotImplementedException();
        }

        public Rental SelectById(int id)
        {
            throw new NotImplementedException();
        }

        public Rental SelectByVehicleClient(int vehicleId, int clientId)
        {
            return vehicleId > 0 && clientId > 0
                ? context.Rentals.Where(x => x.ClientId.Equals(clientId) && x.VehicleId.Equals(vehicleId)).FirstOrDefault()
                : null;
        }
    }
}
