using System.Collections.Generic;
using System.Linq;
using PlattSampleApp.Models.Swapi;

namespace PlattSampleApp.Models
{
    public class StarshipsViewModel
    {
        public StarshipsViewModel(IEnumerable<Starship> starships)
        {
            Starships = starships.Select(x=>new StarshipDetailsViewModel(x)).ToList();
        }

        public List<StarshipDetailsViewModel> Starships { get; set; }
    }
}
