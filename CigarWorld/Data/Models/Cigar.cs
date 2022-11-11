using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static CigarWorld.Data.DataConstants.Cigar;

namespace CigarWorld.Data.Models
{
    public class Cigar
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(MaxBrandLenght, MinimumLength =MinBrandLenght)]
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
        [StringLength(MaxSmokingDurationLenght, MinimumLength = MinSmokingDurationLenght)]
        public int SmokingDuration { get; set; } //The unit of measure is Minutes

        [Required]
        [StringLength(MaxCountryOfManufacturingLenght, MinimumLength = MinCountryOfManufacturingLenght)]
        public string CountryOfManufacturing { get; set; } = null!;

        [Required]
        [StringLength(MaxCommentLenght, MinimumLength = MinCommentLenght)]
        public string Comment { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; }


        [Required]
        public int StrengthId { get; set; }

        [ForeignKey(nameof(StrengthId))]
        public StrengthType? StrengthType { get; set; }
    }
}
