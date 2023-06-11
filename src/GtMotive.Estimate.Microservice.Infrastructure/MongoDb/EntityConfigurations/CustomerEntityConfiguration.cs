using System;
using GtMotive.Estimate.Microservice.Domain.Aggregates.CustomerAggregate;
using MongoDB.Bson.Serialization;

namespace GtMotive.Estimate.Microservice.Infrastructure.MongoDb.EntityConfigurations
{
    public class CustomerEntityConfiguration : EntityConfigurationBase<Customer>
    {
        public CustomerEntityConfiguration(IAppDbContext appDbContext)
            : base(appDbContext)
        {
        }

        protected override void RegisterClassMap(BsonClassMap<Customer> classMap)
        {
            if (classMap == null)
            {
                throw new ArgumentNullException(nameof(classMap));
            }

            classMap.MapIdProperty(x => x.Id);
            classMap.MapMember(c => c.Name).SetIsRequired(true);
            classMap.MapMember(c => c.Bookings).SetIsRequired(true);
            classMap.MapCreator(c => new Customer(c.Id, c.Name, c.Bookings));
        }
    }
}
