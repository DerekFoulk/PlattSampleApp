using System.Collections.Generic;
using Newtonsoft.Json;

namespace PlattSampleApp.Models.Swapi
{
    public abstract class Result
    {
        /// <summary>
        ///     The name of this resource.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        ///     An array of Film URL Resources that this resource has appeared in.
        /// </summary>
        [JsonProperty("films")]
        public IEnumerable<string> Films { get; set; }

        /// <summary>
        ///     The hypermedia URL of this resource.
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
