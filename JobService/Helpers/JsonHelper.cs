namespace JobService.API.Helpers
{
    using Newtonsoft.Json;
    using System.IO;

    /// <summary>
    /// JSON helper
    /// </summary>
    public static class JsonHelper
    {
        /// <summary>
        /// Prettify a json string
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static string JsonPrettify(this string json)
        {
            using (var stringReader = new StringReader(json))
            using (var stringWriter = new StringWriter())
            {
                var jsonReader = new JsonTextReader(stringReader);
                var jsonWriter = new JsonTextWriter(stringWriter) { Formatting = Formatting.Indented };
                jsonWriter.WriteToken(jsonReader);
                return stringWriter.ToString();
            }
        }
    }
}
