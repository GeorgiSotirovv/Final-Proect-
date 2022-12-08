using CigarWorld.Data.Models;
using CigarWorld.Data.Models.Reviews;
using System.ComponentModel.DataAnnotations;
using static CigarWorld.Data.DataConstants.Cigar;

namespace CigarWorld.Models.DetailsModels
{
    public class CigarDetailsViewModel : BaseEditViewModel
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
        public string StrengthType { get; set; } = null!;

        public IEnumerable<StrengthType> StrengthTypes { get; set; } = new List<StrengthType>();

        public IEnumerable<CigarReview> CigarReviews { get; set; } = new List<CigarReview>();

        public string AddReviewToCigar { get; set; } = null!;
    }
}
