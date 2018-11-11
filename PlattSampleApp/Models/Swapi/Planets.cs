﻿using System.Collections.Generic;

namespace PlattSampleApp.Models.Swapi
{
    public class Planets : IPaginatedResponse<Planet>
    {
        public int Count { get; set; }

        public string Next { get; set; }

        public string Previous { get; set; }

        public IEnumerable<Planet> Results { get; set; }
    }
}
