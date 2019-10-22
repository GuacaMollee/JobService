namespace JobService.Infra.Factories
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Options;
    using JobService.Common.Exceptions;
    using JobService.Infra.Configuration;
    using JobService.Infra.Utils;
    using System;

    public class ConnectionStringFactory : IConnectionStringFactory
    {
        private readonly DatabaseConnectionSettings _connectionSettings;

        public ConnectionStringFactory(IOptions<DatabaseConnectionSettings> connectionSettings)
        {
            _connectionSettings = connectionSettings?.Value;
        }

        public string Create<T>()
        {
            if(typeof(T) == typeof(DeviceContext))
            {
                return _connectionSettings?.DeviceConnection ?? ThrowConfigurationException();
            }

            if(typeof(T) == typeof(ClientContext))
            {
                return _connectionSettings?.ClientConnection ?? ThrowConfigurationException();
            }

            if(typeof(T) == typeof(JobTagsContext))
            {
                return _connectionSettings?.JobTagsConnection ?? ThrowConfigurationException();
            }

            return ThrowConfigurationException();
        }

        private string ThrowConfigurationException()
        {
            throw new ConfigurationException("There is no connection string for the database. Please revisit the configuration");
        }
    }
}
