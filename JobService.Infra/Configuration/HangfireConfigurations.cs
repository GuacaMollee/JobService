namespace JobService.Infra.Configuration
{
    public class HangfireConfigurations
    {
        public string[] Queues { get; set; }
        public string ServerName { get; set; }
        public string ServerTimeout { get; set; }
        public int WorkerCount { get; set; }
    }
}
