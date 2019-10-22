namespace JobService.Core.Factories
{
    using Hangfire;
    using Hangfire.Server;
    using Microsoft.Extensions.Logging;
    using JobService.Core.Builders;
    using JobService.Core.Jobs;
    using JobService.Core.Models;
    using System;
    using System.Threading;

    public class JobFactory : IJobFactory
    {
        private readonly IStoredProcedureJobBuilder storedProcedureJobBuilder;
        private readonly IHttpJobBuilder httpJobBuilder;
        private readonly ILogger logger;

        private PerformContext performContext = null;

        public JobFactory(ILogger<JobFactory> logger, IHttpJobBuilder httpJobBuilder, IStoredProcedureJobBuilder storedProcedureJobBuilder)
        {
            this.storedProcedureJobBuilder = storedProcedureJobBuilder;
            this.httpJobBuilder = httpJobBuilder;
            this.logger = logger;
        }

        public IJob Create<T>()
        {
            if (typeof(T) == typeof(HttpJobConfiguration))
            {
                return httpJobBuilder.Build();
            }

            if (typeof(T) == typeof(StoredProcedureJobConfiguration))
            {
                return storedProcedureJobBuilder.Build();
            }

            throw new NotImplementedException($"Type [{typeof(T)}] not implemented by the JobFactory");
        }

        public string GenerateContinuationJob<T>(string parentId, T item, CancellationToken cancellationToken) where T : BaseJobConfiguration
        {
            logger.LogDebug($"Start creating a delayed job named:{item.Name}");
            var identifier = BackgroundJob.ContinueJobWith(parentId, () => Create<T>().Run(item, cancellationToken, performContext), JobContinuationOptions.OnlyOnSucceededState);
            logger.LogDebug($"Finish creating a delayed job named:{item.Name}");

            return identifier;
        }

        public string GenerateDelayedJob<T>(T item, CancellationToken cancellationToken) where T : BaseJobConfiguration
        {
            logger.LogDebug($"Start creating a delayed job named:{item.Name}");
            var identifier = BackgroundJob.Schedule(() => Create<T>().Run(item, cancellationToken, performContext), TimeSpan.FromMilliseconds(item.Delayed));
            logger.LogDebug($"Finish creating a delayed job named:{item.Name}");

            return identifier;
        }

        public string GenerateFireAndForgetJob<T>(T item, CancellationToken cancellationToken) where T : BaseJobConfiguration
        {
            logger.LogDebug($"Start creating a fire and forget job named:{item.Name}");
            var identifier = BackgroundJob.Enqueue(() => Create<T>().Run(item, cancellationToken, performContext));
            logger.LogDebug($"Finish creating a fire and forget job named:{item.Name}");

            return identifier;
        }

        public string GenerateRecurringJob<T>(T item, CancellationToken cancellationToken) where T : BaseJobConfiguration
        {
            logger.LogDebug($"Start creating a recurring job named:{item.Name}");
            var timeZone = TimeZoneInfo.FindSystemTimeZoneById("Europe/Amsterdam");
            RecurringJob.AddOrUpdate(item.Name, () => Create<T>().Run(item, cancellationToken, performContext), item.Duration, timeZone: timeZone);
            logger.LogDebug($"Finish creating a recurring job named:{item.Name}");

            return item.Name;
        }
    }
}
