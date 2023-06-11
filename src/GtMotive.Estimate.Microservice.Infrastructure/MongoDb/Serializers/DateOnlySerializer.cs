using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace GtMotive.Estimate.Microservice.Infrastructure.MongoDb.Serializers
{
    /// <summary>
    /// Workaround for https://jira.mongodb.org/browse/CSHARP-3717.
    /// </summary>
    internal class DateOnlySerializer : StructSerializerBase<DateOnly>
    {
#pragma warning disable SA1129
#pragma warning disable CA1805
        private static readonly TimeOnly ZeroTimeComponent = new();
#pragma warning restore CA1805
#pragma warning restore SA1129

        public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, DateOnly value)
        {
            var dateTime = value.ToDateTime(ZeroTimeComponent);
            var ticks = BsonUtils.ToMillisecondsSinceEpoch(dateTime.ToUniversalTime());
            context.Writer.WriteDateTime(ticks);
        }

        public override DateOnly Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            var ticks = context.Reader.ReadDateTime();
            var dateTime = BsonUtils.ToDateTimeFromMillisecondsSinceEpoch(ticks).ToLocalTime();
            return new DateOnly(dateTime.Year, dateTime.Month, dateTime.Day);
        }
    }
}
