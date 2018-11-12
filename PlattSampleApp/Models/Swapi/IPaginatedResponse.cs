using System.Collections.Generic;
using Newtonsoft.Json;

namespace PlattSampleApp.Models.Swapi
{
    public interface IPaginatedResponse<T>
    {
        [JsonProperty("count")] int Count { get; set; }

        [JsonProperty("next")] string Next { get; set; }

        [JsonProperty("previous")] string Previous { get; set; }

        [JsonProperty("results")] IEnumerable<T> Results { get; set; }
    }
}
