namespace JobService.Core.Builders
{
    using Hangfire.Tags.Attributes;
    using JobService.Core.Jobs;

    public class HttpJobBuilder : IHttpJobBuilder
    {
        [Tag("HttpJob")]
        public IJob Build()
        {
            return new HttpJob<object>();
        }
    }
}
