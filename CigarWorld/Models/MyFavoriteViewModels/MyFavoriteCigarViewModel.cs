using CigarWorld.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace CigarWorld.Models.MyFavoriteViewModels
{
    public class MyFavoriteCigarViewModel : BaseFavoriteModel
    {
        [Required]
        public string Format { get; set; } = null!;

        [Required]
        public int Length { get; set; }  //The unit of measure is mm

        [Required]
        public double Ring { get; set; } //The unit of measure is CM

        [Required]
        public int SmokingDuration { get; set; } //The unit of measure is Minutes

        public string StrengthType { get; set; }

        public IEnumerable<StrengthType> StrengthTypes { get; set; } = new List<StrengthType>();
    }
}
