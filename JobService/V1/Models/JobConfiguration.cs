namespace JobService.API.V1.Models
{
    using Newtonsoft.Json;
    using JobService.Core.Models;

    /// <summary>
    /// 
    /// </summary>
    public class JobConfiguration
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "HttpJobs")]
        public HttpJobConfiguration[] HttpJobs { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "StoredProcedureJobs")]
        public StoredProcedureJobConfiguration[] StoredProcedureJobs { get; set; }
    }
}
