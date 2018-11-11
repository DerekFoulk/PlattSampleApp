using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using PlattSampleApp.Models.Swapi;

namespace PlattSampleApp.Models
{
    public class VehicleSummaryViewModel
    {
        public VehicleSummaryViewModel(IEnumerable<Vehicle> vehicles)
        {
            var allVehicles = vehicles.ToList();
            var vehiclesWithPrice = allVehicles
                .Where(x => !x.CostInCredits.Equals("unknown", StringComparison.OrdinalIgnoreCase)).ToList();

            VehicleCount = vehiclesWithPrice.Count;

            ManufacturerCount = allVehicles.Select(x => x.Manufacturer).Distinct(StringComparer.OrdinalIgnoreCase)
                .Count();

            Details = vehiclesWithPrice.GroupBy(x => x.Manufacturer, StringComparer.OrdinalIgnoreCase)
                .Select(x => new VehicleStatsViewModel(x))
                .OrderByDescending(x => x.VehicleCount).ThenByDescending(x => x.AverageCost).ToList();
        }

        [DisplayName("Total Number of Vehicles with Known Cost")]
        public int VehicleCount { get; set; }

        [DisplayName("Total Number of Manufacturers")]
        public int ManufacturerCount { get; set; }

        public List<VehicleStatsViewModel> Details { get; set; }
    }
}
