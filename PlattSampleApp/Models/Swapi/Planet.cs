using System.Collections.Generic;
using Newtonsoft.Json;

namespace PlattSampleApp.Models.Swapi
{
    public class Planet : Result
    {
        /// <summary>
        ///     The number of standard hours it takes for this planet to complete a single rotation on its axis.
        /// </summary>
        [JsonProperty("rotation_period")]
        public string RotationPeriod { get; set; }

        /// <summary>
        ///     The number of standard days it takes for this planet to complete a single orbit of its local star.
        /// </summary>
        [JsonProperty("orbital_period")]
        public string OrbitalPeriod { get; set; }

        /// <summary>
        ///     The diameter of this planet in kilometers.
        /// </summary>
        [JsonProperty("diameter")]
        public string Diameter { get; set; }

        /// <summary>
        ///     The climate of this planet. Comma separated if diverse.
        /// </summary>
        [JsonProperty("climate")]
        public string Climate { get; set; }

        /// <summary>
        ///     A number denoting the gravity of this planet, where "1" is normal or 1 standard G. "2" is twice or 2 standard Gs.
        ///     "0.5" is half or 0.5 standard Gs.
        /// </summary>
        [JsonProperty("gravity")]
        public string Gravity { get; set; }

        /// <summary>
        ///     The terrain of this planet. Comma separated if diverse.
        /// </summary>
        [JsonProperty("terrain")]
        public string Terrain { get; set; }

        /// <summary>
        ///     The percentage of the planet surface that is naturally occurring water or bodies of water.
        /// </summary>
        [JsonProperty("surface_water")]
        public string SurfaceWater { get; set; }

        /// <summary>
        ///     The average population of sentient beings inhabiting this planet.
        /// </summary>
        [JsonProperty("population")]
        public string Population { get; set; }

        /// <summary>
        ///     An array of People URL Resources that live on this planet.
        /// </summary>
        [JsonProperty("residents")]
        public IEnumerable<string> Residents { get; set; }
    }
}
