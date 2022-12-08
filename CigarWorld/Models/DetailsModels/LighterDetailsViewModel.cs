using CigarWorld.Data.Models.Reviews;
using System.ComponentModel.DataAnnotations;

namespace CigarWorld.Models.DetailsModels
{
    public class LighterDetailsViewModel : BaseEditViewModel
    {
        public IEnumerable<LighterReview> LighterReviews { get; set; } = new List<LighterReview>();

        public string AddReviewToLighter { get; set; } = null!;
    }
}
