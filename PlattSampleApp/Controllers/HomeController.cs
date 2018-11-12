using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PlattSampleApp.Models;
using PlattSampleApp.Services;

namespace PlattSampleApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISwapiService _swapiService;

        public HomeController(ISwapiService swapiService)
        {
            _swapiService = swapiService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Planets()
        {
            var planets = await _swapiService.GetPlanets();

            var model = new PlanetsViewModel(planets);

            return View(model);
        }

        public async Task<IActionResult> Planet(int id)
        {
            var planet = await _swapiService.GetPlanet(id);

            var model = new PlanetViewModel(planet);

            return View(model);
        }

        public async Task<ActionResult> Residents(string planetName)
        {
            var residents = await _swapiService.GetResidents(planetName);

            var model = new ResidentsViewModel(planetName, residents);

            return View(model);
        }

        public async Task<ActionResult> Vehicles()
        {
            var vehicles = await _swapiService.GetVehicles();

            var model = new VehiclesViewModel(vehicles);

            return View(model);
        }

        public ActionResult Starships()
        {
            return View();
        }

        public async Task<JsonResult> StarshipsJson()
        {
            var starships = await _swapiService.GetStarships();

            var model = starships.Select(x => new StarshipDetailsViewModel(x));

            return Json(model);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}
