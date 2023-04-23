using System.Collections.Generic;
using FluentAssertions;
using GtMotive.Estimate.Microservice.ApplicationCore.Common;
using Xunit;

namespace GtMotive.Estimate.Microservice.UnitTests
{
    public class AuthTests
    {
        /// <summary>
        /// GenerateJwtTest.
        /// </summary>
        [Fact]
        public void GenerateJwtTestReturnsEmpty()
        {
            var result = AuthHelper.GenerateJwt(null, new List<string>(), new List<string>(), new ApplicationCore.Identity.Models.JwtSettings());
            result.Should().BeNullOrEmpty();
        }
    }
}
