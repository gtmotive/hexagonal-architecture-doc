using System.Collections.ObjectModel;
using System.Linq;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Interfaces.Repositories;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Infrastructure.SqlServer.Context;

namespace GtMotive.Estimate.Microservice.Infrastructure.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly RentingContext context;

        public VehicleRepository(RentingContext context)
        {
            this.context = context;
        }

        public void Add(Vehicle entity)
        {
            if (entity != null)
            {
                context.Vehicles.Add(entity);
                context.SaveChanges();
            }
        }

        public void Delete(Vehicle entity)
        {
            if (entity != null)
            {
                var selected = SelectById(entity.VehicleId);
                if (selected != null)
                {
                    context.Vehicles.Remove(selected);
                    context.SaveChanges();
                }
            }
        }

        public void Edit(Vehicle entity)
        {
            if (entity != null)
            {
                var selected = SelectById(entity.VehicleId);
                if (selected != null)
                {
                    selected.Brand = entity.Brand;
                    selected.ManufacturingDate = entity.ManufacturingDate;
                    context.SaveChanges();
                }
            }
        }

        public Collection<Vehicle> List()
        {
            var result = context.Vehicles.ToList();

            return new Collection<Vehicle>(result);
        }

        public Vehicle SelectById(int id)
        {
            return context.Vehicles.Where(x => x.VehicleId == id).FirstOrDefault();
        }
    }
}
