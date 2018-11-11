using System.Collections.Generic;
using Newtonsoft.Json;

namespace PlattSampleApp.Models.Swapi
{
    public class Person : Result
    {
        /// <summary>
        /// The birth year of the person, using the in-universe standard of BBY or ABY - Before the Battle of Yavin or After the Battle of Yavin. The Battle of Yavin is a battle that occurs at the end of Star Wars episode IV: A New Hope.
        /// </summary>
        [JsonProperty("birth_year")]
        public string BirthYear { get; set; }

        /// <summary>
        /// The eye color of this person. Will be "unknown" if not known or "n/a" if the person does not have an eye.
        /// </summary>
        [JsonProperty("eye_color")]
        public string EyeColor { get; set; }

        /// <summary>
        /// The gender of this person. Either "Male", "Female" or "unknown", "n/a" if the person does not have a gender.
        /// </summary>
        [JsonProperty("gender")]
        public string Gender { get; set; }

        /// <summary>
        /// The hair color of this person. Will be "unknown" if not known or "n/a" if the person does not have hair.
        /// </summary>
        [JsonProperty("hair_color")]
        public string HairColor { get; set; }

        /// <summary>
        /// The height of the person in centimeters.
        /// </summary>
        [JsonProperty("height")]
        public string Height { get; set; }

        /// <summary>
        /// The mass of the person in kilograms.
        /// </summary>
        [JsonProperty("mass")]
        public string Mass { get; set; }

        /// <summary>
        /// The skin color of this person.
        /// </summary>
        [JsonProperty("skin_color")]
        public string SkinColor { get; set; }

        /// <summary>
        /// The URL of a planet resource, a planet that this person was born on or inhabits.
        /// </summary>
        [JsonProperty("homeworld")]
        public string Homeworld { get; set; }

        /// <summary>
        /// An array of species resource URLs that this person belongs to.
        /// </summary>
        [JsonProperty("species")]
        public IEnumerable<string> Species { get; set; }

        /// <summary>
        /// An array of starship resource URLs that this person has piloted.
        /// </summary>
        [JsonProperty("starships")]
        public IEnumerable<string> Starships { get; set; }

        /// <summary>
        /// An array of vehicle resource URLs that this person has piloted.
        /// </summary>
        [JsonProperty("vehicles")]
        public IEnumerable<string> Vehicles { get; set; }
    }
}
