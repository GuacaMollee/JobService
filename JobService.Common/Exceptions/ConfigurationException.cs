namespace JobService.Common.Exceptions
{
    using System;

    public class ConfigurationException : Exception
    {
        public ConfigurationException() : base()
        {

        }

        public ConfigurationException(string message) : base(message)
        {

        }
    }
}
