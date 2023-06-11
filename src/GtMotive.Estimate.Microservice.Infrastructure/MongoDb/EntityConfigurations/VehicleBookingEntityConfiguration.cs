using System;
using GtMotive.Estimate.Microservice.Domain.Aggregates.CustomerAggregate;
using MongoDB.Bson.Serialization;

namespace GtMotive.Estimate.Microservice.Infrastructure.MongoDb.EntityConfigurations
{
    public class VehicleBookingEntityConfiguration : EntityConfigurationBase<VehicleBooking>
    {
        public VehicleBookingEntityConfiguration(IAppDbContext appDbContext)
            : base(appDbContext)
        {
        }

        protected override void RegisterClassMap(BsonClassMap<VehicleBooking> classMap)
        {
            if (classMap == null)
            {
                throw new ArgumentNullException(nameof(classMap));
            }

            classMap.MapIdProperty(x => x.Id);
            classMap.MapMember(c => c.BookingDate).SetIsRequired(true);
            classMap.MapMember(c => c.ReturnDate).SetIsRequired(true);
            classMap.MapMember(c => c.VehicleId).SetIsRequired(true);
            classMap.MapMember(c => c.IsActive).SetIsRequired(true);
            classMap.MapCreator(c => new VehicleBooking(c.Id, c.BookingDate, c.ReturnDate, c.VehicleId, c.IsActive));
        }
    }
}
