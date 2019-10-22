namespace JobService.Core.Builders
{
    using Hangfire.Tags.Attributes;
    using JobService.Core.Jobs;
    using JobService.Infra.Utils;

    public class StoredProcedureJobBuilder : IStoredProcedureJobBuilder
    {
        private readonly IUnitOfWork<ClientContext> unitOfWork;

        public StoredProcedureJobBuilder(IUnitOfWork<ClientContext> unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [Tag("StoredProcedureJob")]
        public IJob Build()
        {
            return new StoredProcedureJob(unitOfWork);
        }
    }
}
