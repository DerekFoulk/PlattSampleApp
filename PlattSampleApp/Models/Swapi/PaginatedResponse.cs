using System.Collections.Generic;

namespace PlattSampleApp.Models.Swapi
{
    public class PaginatedResponse<T> : IPaginatedResponse<T> where T : Result
    {
        public int Count { get; set; }

        public string Next { get; set; }

        public string Previous { get; set; }

        public IEnumerable<T> Results { get; set; }
    }
}
