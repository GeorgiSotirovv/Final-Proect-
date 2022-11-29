using CigarWorld.Data.Models;
using CigarWorld.Data.Models.Reviews;
using System.ComponentModel.DataAnnotations;

namespace CigarWorld.Models.DetailsModels
{
    public class CigarDetailsViewModel
    {

        [Required]
        public string Brand { get; set; } = null!;

        [Required]
        public string Format { get; set; } = null!;

        [Required]
        public int Length { get; set; }  //The unit of measure is mm

        [Required]
        public double Ring { get; set; } //The unit of measure is CM

        [Required]
        public int SmokingDuration { get; set; } //The unit of measure is Minutes

        [Required]
        public string CountryOfManufacturing { get; set; } = null!;

        [Required]
        public string Comment { get; set; } = null!;

        [Required]
        public string StrengthType { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        public IEnumerable<StrengthType> StrengthTypes { get; set; } = new List<StrengthType>();

        public IEnumerable<CigarReview> CigarReviews { get; set; } = new List<CigarReview>();
    }
}
