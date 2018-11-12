using System.Collections.Generic;
using System.Linq;
using PlattSampleApp.Models.Swapi;

namespace PlattSampleApp.Models
{
    public class ResidentsViewModel
    {
        public ResidentsViewModel(string planetName, IEnumerable<Person> residents)
        {
            PlanetName = planetName;

            var residentSummaries = residents.Select(x => new ResidentSummaryViewModel(x)).OrderBy(x => x.Name).ToList();

            Residents = residentSummaries;
        }

        public string PlanetName { get; set; }

        public List<ResidentSummaryViewModel> Residents { get; set; }
    }
}
