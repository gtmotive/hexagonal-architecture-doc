using System;
using GtMotive.Estimate.Microservice.Infrastructure.Persistence;
using GtMotive.Estimate.Microservice.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace GtMotive.Estimate.Microservice.FunctionalTests.Mocks
{
    public static class MockUnitOfWork
    {
        public static Mock<UnitOfWork> GetUnitOfWork()
        {
            var options = new DbContextOptionsBuilder<ApiDbContext>()
           .UseInMemoryDatabase(databaseName: $"ApiDbContext-{Guid.NewGuid()}")
           .Options;

            var apiDbContextFake = new ApiDbContext(options);
            apiDbContextFake.Database.EnsureDeleted();

            var mockUnitOfWork = new Mock<UnitOfWork>(apiDbContextFake);

            return mockUnitOfWork;
        }
    }
}
