using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using PlattSampleApp.Models.Swapi;

namespace PlattSampleApp.Models
{
    public class SinglePlanetViewModel
    {
        public SinglePlanetViewModel(Planet planet)
        {
            Name = planet.Name;
            LengthOfDay = int.TryParse(planet.RotationPeriod, out var lengthOfDay) ? lengthOfDay : (int?) null;
            LengthOfYear = int.TryParse(planet.OrbitalPeriod, out var lengthOfYear) ? lengthOfYear : (int?) null;
            Diameter = int.TryParse(planet.Diameter, out var diameter) ? diameter : (int?) null;
            Climate = planet.Climate;
            Gravity = planet.Gravity;
            SurfaceWaterPercentage = int.TryParse(planet.SurfaceWater, out var surfaceWaterPercentage)
                ? surfaceWaterPercentage
                : (int?) null;
            Population = long.TryParse(planet.Population, out var population) ? population : (long?) null;
        }

        [DisplayName("Planet Name")] public string Name { get; set; }

        [DisplayName("Length of Day")]
        [DisplayFormat(DataFormatString = "{0:N0} hours", NullDisplayText = "(Unknown)")]
        public int? LengthOfDay { get; set; }

        [DisplayName("Length of Year")]
        [DisplayFormat(DataFormatString = "{0:N0} days", NullDisplayText = "(Unknown)")]
        public int? LengthOfYear { get; set; }

        [DisplayFormat(DataFormatString = "{0:N0}km", NullDisplayText = "(Unknown)")]
        public int? Diameter { get; set; }

        public string Climate { get; set; }

        public string Gravity { get; set; }

        [DisplayName("Surface Water")]
        [DisplayFormat(DataFormatString = "{0:N0}%", NullDisplayText = "(Unknown)")]
        public int? SurfaceWaterPercentage { get; set; }

        [DisplayFormat(DataFormatString = "{0:N0}", NullDisplayText = "(Unknown)")]
        public long? Population { get; set; }
    }
}
