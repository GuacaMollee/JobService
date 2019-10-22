namespace JobService.Core
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using JobService.Core.Agents;
    using JobService.Core.Builders;
    using JobService.Core.Factories;
    using JobService.Core.Models;

    public static class Initialize
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            // Start IoC Registrations
            services.AddTransient<IJobFactory, JobFactory>();
            services.AddTransient<IStoredProcedureJobBuilder, StoredProcedureJobBuilder>();
            services.AddTransient<IHttpJobBuilder, HttpJobBuilder>();

            services.AddTransient<IAgent<HangfireTag>, TagAgent>();

            Infra.Initialize.Configure(services, configuration);
            // End IoC Registrations
        }
    }
}
