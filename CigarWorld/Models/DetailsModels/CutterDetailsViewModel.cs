using CigarWorld.Data.Models;
using CigarWorld.Data.Models.Reviews;
using System.ComponentModel.DataAnnotations;

namespace CigarWorld.Models.DetailsModels
{
    public class CutterDetailsViewModel
    {
        [Required]
        public string Brand { get; set; } = null!;

        [Required]
        public string CountryOfManufacturing { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        public string Comment { get; set; } = null!;

        [Required]
        public string Type { get; set; } = null!;

        public IEnumerable<CutterType> CutterTypes { get; set; } = new List<CutterType>();

        public IEnumerable<CutterReview> CutterReviews { get; set; } = new List<CutterReview>();
    }
}
