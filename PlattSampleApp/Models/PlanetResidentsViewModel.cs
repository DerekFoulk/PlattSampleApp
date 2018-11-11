using System.Collections.Generic;
using System.Linq;
using PlattSampleApp.Models.Swapi;

namespace PlattSampleApp.Models
{
    public class PlanetResidentsViewModel
    {
        public PlanetResidentsViewModel(string planetName, IEnumerable<Person> residents)
        {
            PlanetName = planetName;

            var residentSummaries = residents.Select(x => new ResidentSummary(x)).OrderBy(x => x.Name).ToList();

            Residents = residentSummaries;
        }

        public string PlanetName { get; set; }

        public List<ResidentSummary> Residents { get; set; }
    }
}
