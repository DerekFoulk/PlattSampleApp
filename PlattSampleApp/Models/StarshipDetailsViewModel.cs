using System.Collections.Generic;
using PlattSampleApp.Models.Swapi;

namespace PlattSampleApp.Models
{
    public class StarshipDetailsViewModel
    {
        public StarshipDetailsViewModel(Starship starship)
        {
            Name = starship.Name;
            Class = starship.StarshipClass;
            Manufacturer = starship.Manufacturer;
            Cost = int.TryParse(starship.CostInCredits, out var cost) ? cost : (int?)null;
            Length = int.TryParse(starship.Length, out var length) ? length : (int?)null;
            RequiredCrew = int.TryParse(starship.Crew, out var requiredCrew) ? requiredCrew : (int?)null;
            PassengerCapacity = int.TryParse(starship.Passengers, out var passengerCapacity) ? passengerCapacity : (int?)null;
            MaxSpeed = int.TryParse(starship.MaxAtmospheringSpeed, out var maxSpeed) ? maxSpeed : (int?)null;
            HyperdriveRating = double.TryParse(starship.HyperdriveRating, out var hyperdriveRating) ? hyperdriveRating : (double?)null;
            MaxMegalightsPerHour = int.TryParse(starship.Mglt, out var maxMegalightsPerHour) ? maxMegalightsPerHour : (int?)null;
            CargoCapacity = long.TryParse(starship.CargoCapacity, out var cargoCapacity) ? cargoCapacity : (long?)null;
            ConsumablesLongevity = starship.Consumables;
            Pilots = string.Join(", ", starship.Pilots);
        }

        public string Name { get; set; }

        public string Class { get; set; }

        public string Manufacturer { get; set; }

        public double? Cost { get; set; }

        public int? Length { get; set; }

        public int? RequiredCrew { get; set; }

        public int? PassengerCapacity { get; set; }

        public int? MaxSpeed { get; set; }

        public double? HyperdriveRating { get; set; }

        public int? MaxMegalightsPerHour { get; set; }

        public long? CargoCapacity { get; set; }

        public string ConsumablesLongevity { get; set; }

        public string Pilots { get; set; }
    }
}
