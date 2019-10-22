namespace JobService.Core.Jobs
{
    using Hangfire.Server;
    using JobService.Core.Models;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IJob
    {
        Task Run<T>(T configuration, CancellationToken cancellationToken, PerformContext context) where T : BaseJobConfiguration;
    }
}