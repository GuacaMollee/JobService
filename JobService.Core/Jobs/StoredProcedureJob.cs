namespace JobService.Core.Jobs
{
    using Hangfire.Server;
    using Hangfire.Tags;
    using Microsoft.EntityFrameworkCore;
    using JobService.Core.Builders;
    using JobService.Core.Models;
    using JobService.Infra.Utils;
    using System;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class StoredProcedureJob : IJob
    {
        private readonly IUnitOfWork<ClientContext> unitOfWork;

        public StoredProcedureJob(IUnitOfWork<ClientContext> unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task Run<T>(T configuration, CancellationToken cancellationToken, PerformContext context) where T : BaseJobConfiguration
        {
            if (typeof(T) != typeof(StoredProcedureJobConfiguration))
            {
                throw new ArgumentException("Wrong configuration type for this job.");
            }

            var config = configuration as StoredProcedureJobConfiguration;

            context.AddTags(config.Tags);

            var parameterValues = config.Parameters.Select(pair => new SqlParameter(pair.Key, pair.Value));
            var parameterKeys = config.Parameters.Select(x => x.Key);
            var sqlCommand = SqlStoredProcedureStringBuilder.Build(config.StoredProcedureName, parameterKeys);

            unitOfWork.Context.Database.ExecuteSqlCommand(sqlCommand, parameterValues);

            await unitOfWork.Commit();
        }
    }
}
