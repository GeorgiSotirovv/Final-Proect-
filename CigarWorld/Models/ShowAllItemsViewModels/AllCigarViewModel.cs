using CigarWorld.Data.Models;
using System.ComponentModel.DataAnnotations;
using static CigarWorld.Data.DataConstants.Cigar;
namespace CigarWorld.Models.Models
{
    public class AllCigarViewModel
    {
        [Required]
        public int Id { get; set; }

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
        [StringLength(MaxSmokingDurationLenght, MinimumLength = MinSmokingDurationLenght)]
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
        public string Strength { get; set; } = null!;

        public bool IsFavorite { get; set; }
    }
}
