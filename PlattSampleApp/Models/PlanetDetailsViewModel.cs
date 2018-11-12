using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using PlattSampleApp.Models.Swapi;

namespace PlattSampleApp.Models
{
    public class PlanetDetailsViewModel
    {
        public PlanetDetailsViewModel(Planet planet)
        {
            Name = planet.Name;
            Population = long.TryParse(planet.Population, out var population) ? population : (long?) null;
            Diameter = int.TryParse(planet.Diameter, out var diameter) ? diameter : (int?) null;
            Terrain = planet.Terrain;
            LengthOfYear = int.TryParse(planet.OrbitalPeriod, out var lengthOfYear) ? lengthOfYear : (int?) null;
        }

        [DisplayName("Planet Name")] public string Name { get; set; }

        [DisplayFormat(DataFormatString = "{0:N0}", NullDisplayText = "(Unknown)")]
        public long? Population { get; set; }

        [DisplayFormat(DataFormatString = "{0:N0}km", NullDisplayText = "(Unknown)")]
        public int? Diameter { get; set; }

        public string Terrain { get; set; }

        [DisplayName("Length of Year")]
        [DisplayFormat(DataFormatString = "{0:N0} days", NullDisplayText = "(Unknown)")]
        public int? LengthOfYear { get; set; }
    }
}
