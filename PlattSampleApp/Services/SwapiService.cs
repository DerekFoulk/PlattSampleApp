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
            if (id <= 0)
                throw new ArgumentException($"{nameof(id)} must not be negative.", nameof(id));

            var response = await _swapiClient.HttpClient.GetStringAsync($"planets/{id}");

            var planet = JsonConvert.DeserializeObject<Planet>(response);

            return planet;
        }

        public async Task<Planet> GetPlanet(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException($"{nameof(name)} must not be null, empty or whitespace.", nameof(name));

            var planets = await CompilePaginatedResults<Planet, Planets>($"planets?search={name}");

            var planet = planets.FirstOrDefault();

            return planet;
        }

        public async Task<IEnumerable<Planet>> GetPlanets()
        {
            var planets = await CompilePaginatedResults<Planet, Planets>("planets");

            return planets;
        }

        public async Task<IEnumerable<Person>> GetResidents(string planetName)
        {
            if (string.IsNullOrWhiteSpace(planetName))
                throw new ArgumentException($"{nameof(planetName)} must not be null, empty or whitespace.", nameof(planetName));

            var planet = await GetPlanet(planetName);

            var people = await CompilePaginatedResults<Person, People>("people");

            var residents = people.Where(x => x.Homeworld == planet.Url);

            return residents;
        }

        public async Task<IEnumerable<Vehicle>> GetVehicles()
        {
            var vehicles = await CompilePaginatedResults<Vehicle, Vehicles>("vehicles");

            return vehicles;
        }

        private async Task<IEnumerable<TResult>> CompilePaginatedResults<TResult, TResults>(string uri) where TResults : IPaginatedResponse<TResult>
        {
            var results = new List<TResult>();

            var nextPage = uri;

            while (!string.IsNullOrWhiteSpace(nextPage))
            {
                var currentPage = await GetPage<TResults>(nextPage);

                results.AddRange(currentPage.Results);

                nextPage = currentPage.Next;
            }

            return results;
        }

        private async Task<T> GetPage<T>(string uri)
        {
            var response = await _swapiClient.HttpClient.GetStringAsync(uri);

            var results = JsonConvert.DeserializeObject<T>(response);

            return results;
        }
    }
}
