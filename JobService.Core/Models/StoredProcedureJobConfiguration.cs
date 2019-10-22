namespace JobService.Core.Models
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class StoredProcedureJobConfiguration : BaseJobConfiguration
    {
        [JsonProperty(PropertyName = "storedProcedureName")]
        public string StoredProcedureName { get; set; }

        [JsonProperty(PropertyName = "parameters")]
        public IDictionary<string, string> Parameters { get; set; }
    }
}
