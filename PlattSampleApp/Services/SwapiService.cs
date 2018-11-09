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
    }
}
