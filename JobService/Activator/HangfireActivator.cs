namespace JobService.API.Activator
{
    using Hangfire;
    using System;

    /// <summary>
    /// 
    /// </summary>
    public class HangfireActivator : JobActivator
    {
        private readonly IServiceProvider _serviceProvider;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceProvider"></param>
        public HangfireActivator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public override object ActivateJob(Type type)
        {
            return _serviceProvider.GetService(type);
        }
    }
}
