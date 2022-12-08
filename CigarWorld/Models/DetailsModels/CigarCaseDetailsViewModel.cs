using CigarWorld.Data.Models.Reviews;
using System.ComponentModel.DataAnnotations;
using static CigarWorld.Data.DataConstants.CigarPocketCase;

namespace CigarWorld.Models.DetailsModels
{
    public class CigarCaseDetailsViewModel : BaseEditViewModel
    {
        [Required]
        [StringLength(MaxMaterialOfManufactureLenght, MinimumLength = MinMaterialOfManufactureLenght)]
        public string MaterialOfManufacture { get; set; } = null!;

        [Required]
        public int Capacity { get; set; }

        public IEnumerable<CigarPocketCaseReview> CigarPocketCaseReviews { get; set; } = new List<CigarPocketCaseReview>();

        public string AddReviewToCigarPocketCase { get; set; } = null!;
    }
}
