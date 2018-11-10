using System.Collections.Generic;

namespace PlattSampleApp.Models.Swapi
{
    public class People : IPaginatedResponse<Person>
    {
        public int Count { get; set; }

        public string Next { get; set; }

        public string Previous { get; set; }

        public IEnumerable<Person> Results { get; set; }
    }
}
