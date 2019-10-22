namespace JobService.Dashboard.Server
{
    using Hangfire.Dashboard;
    using Hangfire.Logging;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;

    public class HttpJobDispatcher : IDashboardDispatcher
    {
        private static readonly ILog Logger = LogProvider.For<HttpJobDispatcher>();

        public Task Dispatch(DashboardContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            return Task.CompletedTask;
        }
    }
}
