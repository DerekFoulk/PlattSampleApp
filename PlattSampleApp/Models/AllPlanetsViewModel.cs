using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using PlattSampleApp.Models.Swapi;

namespace PlattSampleApp.Models
{
    public class AllPlanetsViewModel
    {
        public AllPlanetsViewModel(IEnumerable<Planet> planets)
        {
            var planetDetails = planets.Select(x => new PlanetDetailsViewModel(x)).ToList();

            Planets = planetDetails.OrderByDescending(x => x.Diameter).ToList();
            AverageDiameter = planetDetails.Where(x => x.Diameter != null).Select(x => (int)x.Diameter).Average();
        }

        public List<PlanetDetailsViewModel> Planets { get; set; }

        [DisplayName("Average Diameter")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public double AverageDiameter { get; set; }
    }
}
