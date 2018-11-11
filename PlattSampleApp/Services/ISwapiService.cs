using System.Collections.Generic;
using System.Threading.Tasks;
using PlattSampleApp.Models.Swapi;

namespace PlattSampleApp.Services
{
    public interface ISwapiService
    {
        Task<Planet> GetPlanet(int id);

        Task<Planet> GetPlanet(string name);

        Task<IEnumerable<Planet>> GetPlanets();

        Task<IEnumerable<Person>> GetResidents(string planetName);

        Task<IEnumerable<Vehicle>> GetVehicles();
    }
}
