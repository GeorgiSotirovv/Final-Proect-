using CigarWorld.Data.Models;
using CigarWorld.Models.AddViewModels;
using System.ComponentModel.DataAnnotations;
using static CigarWorld.Data.DataConstants.Cigar;

namespace CigarWorld.Models.AddModels
{
    public class AddCigarViewModel : BaseAddViewModel

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

        [Required]
        public int StrengthId { get; set; }

        public IEnumerable<StrengthType> StrengthTypes { get; set; } = new List<StrengthType>();
    }
}
