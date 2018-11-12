using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using PlattSampleApp.Models.Swapi;

namespace PlattSampleApp.Models
{
    public class VehicleStatsViewModel
    {
        public VehicleStatsViewModel(IGrouping<string, Vehicle> grouping)
        {
            ManufacturerName = grouping.Key;

            VehicleCount = grouping.Count();

            AverageCost = grouping.Select(x => double.Parse(x.CostInCredits)).Average();
        }

        [DisplayName("Manufacturer Name")] public string ManufacturerName { get; set; }

        [DisplayName("Vehicle Count")] public int VehicleCount { get; set; }

        [DisplayName("Average Cost")]
        [DisplayFormat(DataFormatString = "{0:N2}", NullDisplayText = "(Unknown)")]
        public double AverageCost { get; set; }
    }
}
