using CigarWorld.Data.Models;
using System.ComponentModel.DataAnnotations;
using static CigarWorld.Data.DataConstants.Cigar;

namespace CigarWorld.Models.AddModels
{
    public class AddCigarViewModel
    {
        [Required]
        [StringLength(MaxBrandLenght, MinimumLength = MinBrandLenght)]
        public string Brand { get; set; } = null!;

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
        [StringLength(MaxCountryOfManufacturingLenght, MinimumLength = MinCountryOfManufacturingLenght)]
        public string CountryOfManufacturing { get; set; } = null!;

        [Required]
        [StringLength(MaxCommentLenght, MinimumLength = MinCommentLenght)]
        public string Comment { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        public int StrengthId { get; set; }

        public int StrengthType { get; set; } 

        public IEnumerable<StrengthType> StrengthTypes { get; set; } = new List<StrengthType>();
    }
}
