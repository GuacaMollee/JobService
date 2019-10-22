namespace JobService.Infra
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using JobService.Infra.Factories;
    using JobService.Infra.Utils;

    public static class Initialize
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            // Start IoC Registrations
            services.AddTransient<IConnectionStringFactory, ConnectionStringFactory>();

            services.AddTransient<IContextFactory<DeviceContext>, ContextFactory<DeviceContext>>();
            services.AddTransient<IContextFactory<ClientContext>, ContextFactory<ClientContext>>();
            services.AddTransient<IContextFactory<JobTagsContext>, ContextFactory<JobTagsContext>>();

            services.AddTransient<IUnitOfWork<DeviceContext>, UnitOfWork<DeviceContext>>();
            services.AddTransient<IUnitOfWork<ClientContext>, UnitOfWork<ClientContext>>();
            services.AddTransient<IUnitOfWork<JobTagsContext>, UnitOfWork<JobTagsContext>>();
            // End IoC Registrations
        }
    }
}
