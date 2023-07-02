using System;
using GtMotive.Estimate.Microservice.Domain.Entities;
using Xunit;

namespace GtMotive.Estimate.Microservice.UnitTests
{
    public class VehiclesShould
    {
        [Fact]
        public void NotBeOld()
        {
            Assert.Throws<ArgumentException>(() => new Vehicle("Marca nueva", new DateTime(2010, 10, 1)));
        }
    }
}
