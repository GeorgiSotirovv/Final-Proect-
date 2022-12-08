using CigarWorld.Data.Models;
using CigarWorld.Data.Models.Reviews;
using System.ComponentModel.DataAnnotations;

namespace CigarWorld.Models.DetailsModels
{
    public class CutterDetailsViewModel : BaseEditViewModel
    {
        [Required]
        public string Type { get; set; } = null!;

        public IEnumerable<CutterType> CutterTypes { get; set; } = new List<CutterType>();

        public IEnumerable<CutterReview> CutterReviews { get; set; } = new List<CutterReview>();

        public string AddReviewToCutter { get; set; } = null!;
    }
}
