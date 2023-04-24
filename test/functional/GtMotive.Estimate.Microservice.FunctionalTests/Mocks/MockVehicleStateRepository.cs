using System.Collections.Generic;
using AutoFixture;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Infrastructure.Persistence;

namespace GtMotive.Estimate.Microservice.FunctionalTests.Mocks
{
    public static class MockVehicleStateRepository
    {
        public static void AddDataRepository(ApiDbContext apiDbContextFake)
        {
            var fixture = new Fixture();
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            var data = new List<VehicleState>
            {
                fixture.Build<VehicleState>()
                .With(tr => tr.Name, "test-state")
                .With(tr => tr.Id, 99)
                .Create()
            };

            if (apiDbContextFake != null)
            {
                apiDbContextFake.VehicleStates!.AddRange(data);
                apiDbContextFake.SaveChanges();
            }
        }
    }
}
