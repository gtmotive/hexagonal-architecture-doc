using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api;
using GtMotive.Estimate.Microservice.Infrastructure;
using GtMotive.Estimate.Microservice.Infrastructure.MongoDb.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

[assembly: CLSCompliant(false)]

namespace GtMotive.Estimate.Microservice.FunctionalTests.Infrastructure
{
#pragma warning disable CA1063
#pragma warning disable S3881
    public class FunctionalTestBase : IDisposable, IAsyncLifetime
#pragma warning restore S3881
#pragma warning restore CA1063
    {
        private ServiceProvider _serviceProvider;

        public IConfiguration Configuration { get; private set; }

        public virtual async Task InitializeAsync()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            var services = new ServiceCollection();
            Configuration = configuration;
            ConfigureServices(services);
            services.AddSingleton<IConfiguration>(configuration);

            _serviceProvider = services.BuildServiceProvider();

            await Task.CompletedTask;
        }

        public virtual async Task DisposeAsync()
        {
            await Task.CompletedTask;
        }

        protected T GetService<T>()
            where T : class
        {
            return _serviceProvider.GetService<T>();
        }

#pragma warning disable CA1816
#pragma warning disable SA1202
#pragma warning disable CA1063
        public void Dispose()
#pragma warning restore CA1063
#pragma warning restore SA1202
#pragma warning restore CA1816
        {
            _serviceProvider.Dispose();
        }

        protected virtual void ConfigureServices(IServiceCollection services)
        {
            services.AddApiDependencies();
            services.AddLogging();
            services.AddBaseInfrastructure(true);
            services.Configure<MongoDbSettings>(Configuration.GetSection("MongoDb"));
        }
    }
}
