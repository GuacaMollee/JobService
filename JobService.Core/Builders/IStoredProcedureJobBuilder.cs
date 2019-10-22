using JobService.Core.Jobs;

namespace JobService.Core.Builders
{
    public interface IStoredProcedureJobBuilder
    {
        IJob Build();
    }
}