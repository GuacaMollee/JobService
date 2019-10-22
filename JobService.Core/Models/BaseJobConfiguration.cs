namespace JobService.Core.Models
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class BaseJobConfiguration
    {
        /// <summary>
        /// Name of the Job 
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Cron expression
        /// </summary>
        [JsonProperty(PropertyName = "duration")]
        public string Duration { get; set; } = null;

        /// <summary>
        /// In milliseconds (Default: 0)
        /// </summary>
        [JsonProperty(PropertyName = "delayed")]
        public double Delayed { get; set; } = 0.0;

        /// <summary>
        /// Tags which will be linked to the task in the dashboard
        /// </summary>
        [JsonProperty(PropertyName = "tags")]
        public IEnumerable<string> Tags { get; set; }
    }
}
