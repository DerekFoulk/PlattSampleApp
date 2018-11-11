using System.Collections.Generic;
using Newtonsoft.Json;

namespace PlattSampleApp.Models.Swapi
{
    public class Vehicle
    {
        /// <summary>
        /// The name of this vehicle. The common name, such as "Sand Crawler" or "Speeder bike".
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// The model or official name of this vehicle. Such as "All-Terrain Attack Transport".
        /// </summary>
        [JsonProperty("model")]
        public string Model { get; set; }

        /// <summary>
        /// The class of this vehicle, such as "Wheeled" or "Repulsorcraft".
        /// </summary>
        [JsonProperty("vehicle_class")]
        public string VehicleClass { get; set; }

        /// <summary>
        /// The manufacturer of this vehicle. Comma separated if more than one.
        /// </summary>
        [JsonProperty("manufacturer")]
        public string Manufacturer { get; set; }

        /// <summary>
        /// The length of this vehicle in meters.
        /// </summary>
        [JsonProperty("length")]
        public string Length { get; set; }

        /// <summary>
        /// The cost of this vehicle new, in Galactic Credits.
        /// </summary>
        [JsonProperty("cost_in_credits")]
        public string CostInCredits { get; set; }

        /// <summary>
        /// The number of personnel needed to run or pilot this vehicle.
        /// </summary>
        [JsonProperty("crew")]
        public string Crew { get; set; }

        /// <summary>
        /// The number of non-essential people this vehicle can transport.
        /// </summary>
        [JsonProperty("passengers")]
        public string Passengers { get; set; }

        /// <summary>
        /// The maximum speed of this vehicle in the atmosphere.
        /// </summary>
        [JsonProperty("max_atmosphering_speed")]
        public string MaxAtmospheringSpeed { get; set; }

        /// <summary>
        /// The maximum number of kilograms that this vehicle can transport.
        /// </summary>
        [JsonProperty("cargo_capacity")]
        public string CargoCapacity { get; set; }

        /// <summary>
        /// The maximum length of time that this vehicle can provide consumables for its entire crew without having to resupply.
        /// </summary>
        [JsonProperty("consumables")]
        public string Consumables { get; set; }

        /// <summary>
        /// An array of Film URL Resources that this vehicle has appeared in.
        /// </summary>
        [JsonProperty("films")]
        public IEnumerable<string> Films { get; set; }

        /// <summary>
        /// An array of People URL Resources that this vehicle has been piloted by.
        /// </summary>
        [JsonProperty("pilots")]
        public IEnumerable<string> Pilots { get; set; }

        /// <summary>
        /// The hypermedia URL of this resource.
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
