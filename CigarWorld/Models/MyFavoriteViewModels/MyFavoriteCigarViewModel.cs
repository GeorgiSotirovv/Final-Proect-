using CigarWorld.Data.Models;
using System.ComponentModel.DataAnnotations;
using static CigarWorld.Data.DataConstants.Cigar;

namespace CigarWorld.Models.MyFavoriteViewModels
{
    public class MyFavoriteCigarViewModel : BaseFavoriteModel
    {
        [Required]
        [StringLength(MaxFormatLenght, MinimumLength = MinFormatLenght)]
        public string Format { get; set; } = null!;

        [Required]
        [Range(MinLengthLenght, MaxLengthLenght)]
        public int Length { get; set; }  //The unit of measure is mm

        [Required]
        [Range(MinRingLenght, MaxRingLenght)]
        public double Ring { get; set; } //The unit of measure is CM

        [Required]
        [Range(MinSmokingDurationLenght, MaxSmokingDurationLenght)]
        public int SmokingDuration { get; set; } //The unit of measure is Minutes

        public string StrengthType { get; set; } = null!;

        public IEnumerable<StrengthType> StrengthTypes { get; set; } = new List<StrengthType>();
    }
}
