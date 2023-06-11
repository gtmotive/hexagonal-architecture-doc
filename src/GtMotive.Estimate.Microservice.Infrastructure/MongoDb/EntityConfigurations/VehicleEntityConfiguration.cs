using System;
using GtMotive.Estimate.Microservice.Domain.Aggregates.VehicleAggregate;
using MongoDB.Bson.Serialization;

namespace GtMotive.Estimate.Microservice.Infrastructure.MongoDb.EntityConfigurations
{
    public class VehicleEntityConfiguration : EntityConfigurationBase<Vehicle>
    {
        public VehicleEntityConfiguration(IAppDbContext appDbContext)
            : base(appDbContext)
        {
        }

        protected override void RegisterClassMap(BsonClassMap<Vehicle> classMap)
        {
            if (classMap == null)
            {
                throw new ArgumentNullException(nameof(classMap));
            }

            classMap.MapIdProperty(x => x.Id);
            classMap.MapMember(c => c.Model).SetIsRequired(true);
            classMap.MapMember(c => c.ManufacturingDate).SetIsRequired(true);
            classMap.MapMember(c => c.IsAvailable).SetIsRequired(true);
            classMap.MapCreator(c => new Vehicle(c.Id, c.Model, c.ManufacturingDate, c.IsAvailable));
        }
    }
}
