namespace JobService.Dashboard
{
    using Hangfire;
    using Hangfire.Dashboard;
    using JobService.Dashboard.Dashboard;
    using JobService.Dashboard.Dashboard.Pages;
    using JobService.Dashboard.Server;
    using JobService.Dashboard.Utils;
    using System.Reflection;

    public static class GlobalConfigurationExtension
    {
        public static IGlobalConfiguration UseHangfireDashboardExtention(this IGlobalConfiguration config, HangfireOptions options = null)
        {
            if (options == null) options = new HangfireOptions();
            var assembly = typeof(HangfireOptions).GetTypeInfo().Assembly;

            NavigationMenu.Items.Add(page => new MenuItem("Add jobs", page.Url.To("/addjobs"))
            {
                Active = page.RequestPath.StartsWith("/addjobs")
            });

            DashboardRoutes.Routes.Add("/dispatcher", new HttpJobDispatcher());
            DashboardRoutes.Routes.AddRazorPage("/addjobs", x => new AddJobPage());

            var jsPath = DashboardRoutes.Routes.Contains("/js[0-9]+") ? "/js[0-9]+" : "/js[0-9]{3}";
            DashboardRoutes.Routes.Append(jsPath, new EmbeddedResourceDispatcher(assembly, "JobService.Dashboard.Content.addjob.js"));
            DashboardRoutes.Routes.Append(jsPath, new EmbeddedResourceDispatcher(assembly, "JobService.Dashboard.Content.cron.js"));
            DashboardRoutes.Routes.Append(jsPath, new DynamicJsDispatcher(options));
            
            return config;
        }
    }
}
