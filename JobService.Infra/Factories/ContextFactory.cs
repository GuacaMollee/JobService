namespace JobService.Infra.Factories
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Options;
    using JobService.Infra.Configuration;
    using System;
    using System.Data.SqlClient;

    public class ContextFactory<T> : IContextFactory<T> where T : DbContext
    {
        private readonly DatabaseConnectionSettings connectionOptions;
        private readonly HttpContext httpContext;
        private readonly IConnectionStringFactory connectionStringFactory;

        //hier data,anager implementeren
        public ContextFactory(
            IHttpContextAccessor httpContentAccessor,
            IOptions<DatabaseConnectionSettings> connectionOptions,
            IConnectionStringFactory connectionStringFactory)
        {
            this.httpContext = httpContentAccessor.HttpContext;
            this.connectionOptions = connectionOptions?.Value;
            this.connectionStringFactory = connectionStringFactory;
        }

        private void ValidateHttpContext()
        {
            if (this.httpContext == null)
            {
                throw new ArgumentNullException(nameof(this.httpContext));
            }
        }

        public T DbContext => Activator.CreateInstance(typeof(T), ChangeDatabaseNameInConnectionString().Options) as T;

        private DbContextOptionsBuilder<T> ChangeDatabaseNameInConnectionString()
        {
            ValidateDbConnection();

            // 1. Create Connection String Builder using Default connection string
            var sqlConnectionBuilder = new SqlConnectionStringBuilder(this.connectionStringFactory.Create<T>());

            // 4. Create DbContextOptionsBuilder with new Database name
            var contextOptionsBuilder = new DbContextOptionsBuilder<T>();

            contextOptionsBuilder.UseSqlServer(sqlConnectionBuilder.ConnectionString);

            return contextOptionsBuilder;
        }

        private void ValidateDbConnection()
        {
            if (string.IsNullOrEmpty(this.connectionOptions?.ClientConnection) || string.IsNullOrEmpty(this.connectionOptions?.DeviceConnection))
            {
                throw new ArgumentNullException(nameof(this.connectionOptions));
            }
        }
    }
}
