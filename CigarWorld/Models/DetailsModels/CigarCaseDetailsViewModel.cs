using CigarWorld.Data.Models.Reviews;
using System.ComponentModel.DataAnnotations;

namespace CigarWorld.Models.DetailsModels
{
    public class CigarCaseDetailsViewModel
    {
        [Required]
        public string Brand { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        public string CountryOfManufacturing { get; set; } = null!;

        [Required]
        public string MaterialOfManufacture { get; set; } = null!;

        [Required]
        public int Capacity { get; set; }

        [Required]
        public string Comment { get; set; } = null!;

        public IEnumerable<CigarPocketCaseReview> CigarPocketCaseReviews { get; set; } = new List<CigarPocketCaseReview>();
    }
}
