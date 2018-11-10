using System;
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
            var planets = new List<Planet>();

            var nextPage = "planets";

            while (!string.IsNullOrWhiteSpace(nextPage))
            {
                var currentPage = await GetPlanetsPage(nextPage);

                planets.AddRange(currentPage.Results);

                nextPage = currentPage.Next;
            }

            return planets;
        }

        public async Task<IEnumerable<Person>> GetResidents(string planetName)
        {
            if (string.IsNullOrWhiteSpace(planetName))
                throw new ArgumentException($"{nameof(planetName)} must not be null, empty or whitespace.", nameof(planetName));

            var planets = await GetPlanets();
            var planet = planets.SingleOrDefault(x => x.Name == planetName);

            if (planet == null)
                throw new Exception("Unknown planet requested.");

            var people = new List<Person>();

            var nextPage = "people";

            while (!string.IsNullOrWhiteSpace(nextPage))
            {
                var currentPage = await GetPeoplePage(nextPage);

                people.AddRange(currentPage.Results);

                nextPage = currentPage.Next;
            }

            var residents = people.Where(x => x.Homeworld == planet.Url);

            return residents;
        }

        // TODO: Combine the following two methods
        private async Task<Planets> GetPlanetsPage(string uri)
        {
            var response = await _swapiClient.HttpClient.GetStringAsync(uri);

            var planets = JsonConvert.DeserializeObject<Planets>(response);

            return planets;
        }

        private async Task<People> GetPeoplePage(string uri)
        {
            var response = await _swapiClient.HttpClient.GetStringAsync(uri);

            var people = JsonConvert.DeserializeObject<People>(response);

            return people;
        }
    }
}
