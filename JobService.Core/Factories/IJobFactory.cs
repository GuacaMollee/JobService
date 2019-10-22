using Hangfire;
using JobService.Core.Jobs;
using JobService.Core.Models;
using System.Threading;

namespace JobService.Core.Factories
{
    public interface IJobFactory
    {
        IJob Create<T>();

        string GenerateRecurringJob<T>(T item, CancellationToken cancellationToken) where T : BaseJobConfiguration;
        string GenerateFireAndForgetJob<T>(T item, CancellationToken cancellationToken) where T : BaseJobConfiguration;
        string GenerateDelayedJob<T>(T item, CancellationToken cancellationToken) where T : BaseJobConfiguration;
        string GenerateContinuationJob<T>(string parentId, T item, CancellationToken cancellationToken) where T : BaseJobConfiguration;
    }
}