using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using PlattSampleApp.Models.Swapi;

namespace PlattSampleApp.Models
{
    public class ResidentSummary
    {
        public ResidentSummary(Person person)
        {
            Name = person.Name;
            Height = int.TryParse(person.Height, out var height) ? height : (int?) null;
            Weight = int.TryParse(person.Mass, out var weight) ? weight : (int?) null;
            Gender = person.Gender;
            HairColor = person.HairColor;
            EyeColor = person.EyeColor;
            SkinColor = person.SkinColor;
        }

        public string Name { get; set; }

        [DisplayFormat(DataFormatString = "{0:N0} cm", NullDisplayText = "(Unknown)")]
        public int? Height { get; set; }

        [DisplayFormat(DataFormatString = "{0:N0} kg", NullDisplayText = "(Unknown)")]
        public int? Weight { get; set; }

        public string Gender { get; set; }

        [DisplayName("Hair Color")] public string HairColor { get; set; }

        [DisplayName("Eye Color")] public string EyeColor { get; set; }

        [DisplayName("Skin Color")] public string SkinColor { get; set; }
    }
}
