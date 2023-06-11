using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: CLSCompliant(false)]

namespace GtMotive.Estimate.Microservice.InfrastructureTests.Infrastructure
{
#pragma warning disable CA1063
#pragma warning disable S3881
    public abstract class InfrastructureTestBase : IDisposable
#pragma warning restore S3881
#pragma warning restore CA1063
    {
        protected InfrastructureTestBase()
        {
            var hostBuilder = new WebHostBuilder()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseEnvironment("IntegrationTest")
                .UseDefaultServiceProvider(options => { options.ValidateScopes = true; })
                .ConfigureAppConfiguration((context, builder) => { builder.AddEnvironmentVariables(); })
                .ConfigureTestServices(ConfigureTestServices)
                .UseStartup<Startup>();

            Server = new TestServer(hostBuilder);
        }

        protected TestServer Server { get; }

#pragma warning disable CA1063
#pragma warning disable CA1816
        public void Dispose()
#pragma warning restore CA1816
#pragma warning restore CA1063
        {
            Server.Dispose();
        }

        protected abstract void ConfigureTestServices(IServiceCollection services);
    }
}
