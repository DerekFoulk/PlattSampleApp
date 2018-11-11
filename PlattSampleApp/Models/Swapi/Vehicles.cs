using System.Collections.Generic;

namespace PlattSampleApp.Models.Swapi
{
    public class Vehicles : IPaginatedResponse<Vehicle>
    {
        public int Count { get; set; }

        public string Next { get; set; }

        public string Previous { get; set; }

        public IEnumerable<Vehicle> Results { get; set; }
    }
}
