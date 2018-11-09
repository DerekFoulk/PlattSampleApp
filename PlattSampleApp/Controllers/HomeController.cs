using System;
using System.Collections.Generic;
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
        private readonly SwapiService _swapiService;

        public HomeController(SwapiService swapiService)
        {
            _swapiService = swapiService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public ActionResult GetAllPlanets()
        {
            var model = new AllPlanetsViewModel();

            // TODO: Implement this controller action

            return View(model);
        }

        public async Task<IActionResult> GetPlanetTwentyTwo(int id)
        {
            var planet = await _swapiService.GetPlanet(id);

            var model = new SinglePlanetViewModel(planet);

            return View(model);
        }

        public ActionResult GetResidentsOfPlanetNaboo(string planetname)
        {
            var model = new PlanetResidentsViewModel();

            // TODO: Implement this controller action

            return View(model);
        }

        public ActionResult VehicleSummary()
        {
            var model = new VehicleSummaryViewModel();

            // TODO: Implement this controller action

            return View(model);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
