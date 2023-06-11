using System.Reflection;
using Acheve.AspNetCore.TestHost.Security;
using Acheve.TestHost;
using GtMotive.Estimate.Microservice.Api;
using GtMotive.Estimate.Microservice.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GtMotive.Estimate.Microservice.InfrastructureTests.Infrastructure
{
    public class Startup
    {
        public Startup(IWebHostEnvironment environment, IConfiguration configuration)
        {
            Environment = environment;
            Configuration = configuration;
        }

        public IWebHostEnvironment Environment { get; }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
#pragma warning disable CA1822
        public void Configure(IApplicationBuilder app)
#pragma warning restore CA1822
        {
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
#pragma warning disable CA1822
        public void ConfigureServices(IServiceCollection services)
#pragma warning restore CA1822
        {
            services.AddMediatR(typeof(Startup).GetTypeInfo().Assembly);

            services.AddAuthentication(TestServerDefaults.AuthenticationScheme)
                .AddTestServer();

            services.AddControllers(ApiConfiguration.ConfigureControllers)
                .WithApiControllers();

            services.AddBaseInfrastructure(true);
        }
    }
}
