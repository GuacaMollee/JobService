namespace JobService.Core.Jobs
{
    using Hangfire.Server;
    using Hangfire.Tags;
    using JobService.Core.Models;
    using JobService.Infra.Services;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class HttpJob<Tout> : IJob
    {
        public async Task Run<T>(T configuration, CancellationToken cancellationToken, PerformContext context) where T : BaseJobConfiguration
        {
            if (typeof(T) != typeof(HttpJobConfiguration))
            {
                throw new ArgumentException("Wrong configuration type for this job.");
            }

            var config = configuration as HttpJobConfiguration;

            context.AddTags(config.Tags);

            var restService = new RestService<object, Tout>(config.Endpoint);

            await restService.Post(config.Body, config.Headers, null, cancellationToken);
        }
    }
}
