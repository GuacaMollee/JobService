namespace JobService.Core.Models
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class HttpJobConfiguration : BaseJobConfiguration
    {
        [JsonProperty(PropertyName = "endpoint")]
        public string Endpoint { get; set; }

        [JsonProperty(PropertyName = "body")]
        public object Body { get; set; }

        [JsonProperty(PropertyName = "headers")]
        public IDictionary<string, string> Headers { get; set; }
    }
}
