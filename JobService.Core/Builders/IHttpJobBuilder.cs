using JobService.Core.Jobs;

namespace JobService.Core.Builders
{
    public interface IHttpJobBuilder
    {
        IJob Build();
    }
}