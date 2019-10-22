namespace JobService
{
    using Hangfire;
    using Hangfire.Tags.SqlServer;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.ApiExplorer;
    using Microsoft.AspNetCore.Routing;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Configuration.EnvironmentVariables;
    using Microsoft.Extensions.Configuration.Json;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using Microsoft.Extensions.PlatformAbstractions;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using JobService.API;
    using JobService.API.Filters;
    using JobService.API.Helpers;
    using JobService.API.V1.Controllers;
    using JobService.Dashboard;
    using JobService.Infra.Configuration;
    using Swashbuckle.AspNetCore.SwaggerGen;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;

    /// <summary>
    /// 
    /// </summary>
    public class Startup
    {
        private readonly ILogger logger;

        private const string DefaultBackgroundJobOptionsKey = "DefaultBackgroundJobOptions";
        private const string DatabaseConnectionSettingsKey = "DatabaseConnectionSettings";
        private const string ClientConnectionKey = "ClientConnection";
        private const string HangfireConfigurationKey = "HangfireConfiguration";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="logger"></param>
        public Startup(IConfiguration configuration, ILogger<Startup> logger)
        {
            Configuration = configuration;
            this.logger = logger;
        }

        /// <summary>
        /// 
        /// </summary>
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHealthChecks();

            Console.WriteLine($"CONFIG AND ENVIRONMENT VARIABLES: {JsonConvert.SerializeObject(Configuration.ToDictionary()).JsonPrettify()}");

            services.Configure<RouteOptions>(options => options.LowercaseUrls = true);
            services.Configure<DatabaseConnectionSettings>(Configuration.GetSection(DatabaseConnectionSettingsKey));
            services.Configure<HangfireConfigurations>(Configuration.GetSection(HangfireConfigurationKey));

            services.AddMvc(options => { options.EnableEndpointRouting = false; }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddHangfire(config =>
            {
                config.UseSqlServerStorage(Configuration.GetSection(string.Join(':', new[] { DatabaseConnectionSettingsKey, ClientConnectionKey })).Value);
                config.UseHangfireDashboardExtention(new HangfireOptions());
                config.UseTagsWithSql();
                //config.UseHangfireHttpJob();
            });

            services.AddApiVersioning(o =>
            {
                o.ReportApiVersions = true;
                o.AssumeDefaultVersionWhenUnspecified = true;
                o.DefaultApiVersion = new ApiVersion(1, 0);

                o.Conventions.Controller<JobController>().HasApiVersion(new ApiVersion(1, 0));
            });

            services.AddVersionedApiExplorer(
                options =>
                {
                    // add the versioned api explorer, which also adds IApiVersionDescriptionProvider service
                    // note: the specified format code will format the version as "'v'major[.minor][-status]"
                    options.GroupNameFormat = "'v'VVV";

                    // note: this option is only necessary when versioning by url segment. the SubstitutionFormat
                    // can also be used to control the format of the API version in route templates
                    options.SubstituteApiVersionInUrl = true;
                });

            // Start IoC Registrations
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            Core.Initialize.Configure(services, Configuration);
            // End IoC Registrations

            services.AddSwaggerGen(
                options =>
                {
                    // add a custom operation filter which sets default values
                    options.OperationFilter<SwaggerDefaultValues>();

                    // integrate xml comments
                    options.IncludeXmlComments(XmlCommentsFilePath);
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        /// <param name="provider"></param>
        /// <param name="serviceProvider"></param>
        /// <param name="lifetime"></param>
        public void Configure(
            IApplicationBuilder app,
            IHostingEnvironment env,
            IApiVersionDescriptionProvider provider,
            IServiceProvider serviceProvider,
            IApplicationLifetime lifetime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            var hangfireConfiguration = Configuration.GetSection(HangfireConfigurationKey).Get<HangfireConfigurations>();
            var hangfireOptions = new BackgroundJobServerOptions()
            {
                WorkerCount = hangfireConfiguration.WorkerCount,
                Queues = hangfireConfiguration.Queues,
                ServerName = hangfireConfiguration.ServerName,
                ServerTimeout = TimeSpan.Parse(hangfireConfiguration.ServerTimeout)
            };

            app.UseHangfireServer(hangfireOptions);

            //DashboardRoutes.Routes.AddRazorPage("/addjobs", x => new JobService.Dashboard.Dashboard.Pages._Dashboard_Pages_AddJob());
            //NavigationMenu.Items.Add(page => new MenuItem("Add jobs", page.Url.To("/addjobs"))
            //{
            //    Active = page.RequestPath.StartsWith("/addjobs")
            //});

            app.UseHangfireDashboard("/hangfire", new DashboardOptions
            {
                Authorization = new[] { new HangfireAuthorizationFilter() }
            });

            app.UseSwagger();
            app.UseSwaggerUI(
                options =>
                {
                    foreach (var description in provider.ApiVersionDescriptions)
                    {
                        options.SwaggerEndpoint(
                            $"/swagger/{description.GroupName}/swagger.json",
                            description.GroupName.ToUpperInvariant());
                    }
                });
        }

        private static string XmlCommentsFilePath
        {
            get
            {
                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var fileName = typeof(Startup).GetTypeInfo().Assembly.GetName().Name + ".xml";
                return Path.Combine(basePath, fileName);
            }
        }
    }
}
