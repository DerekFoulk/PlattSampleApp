using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PlattSampleApp.Models.Swapi;

namespace PlattSampleApp.Services
{
    public class SwapiService
    {
        private readonly SwapiClient _swapiClient;

        public SwapiService()
        {
            _swapiClient = new SwapiClient();
        }

        public async Task<Planet> GetPlanet(int id)
        {
            var response = await _swapiClient.HttpClient.GetStringAsync($"planets/{id}");

            var planet = JsonConvert.DeserializeObject<Planet>(response);

            return planet;
        }

        public async Task<IEnumerable<Planet>> GetPlanets()
        {
            var results = new List<Planet>();

            var nextPage = "planets";

            while (!string.IsNullOrWhiteSpace(nextPage))
            {
                var planets = await GetPlanetsPage(nextPage);

                results.AddRange(planets.Results);

                nextPage = planets.Next;
            }

            return results;
        }

        private async Task<Planets> GetPlanetsPage(string uri)
        {
            var response = await _swapiClient.HttpClient.GetStringAsync(uri);

            var planets = JsonConvert.DeserializeObject<Planets>(response);

            return planets;
        }
    }
}
