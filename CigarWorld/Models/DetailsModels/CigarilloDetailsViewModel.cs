using CigarWorld.Data.Models;
using CigarWorld.Data.Models.Reviews;
using System.ComponentModel.DataAnnotations;

namespace CigarWorld.Models.DetailsModels
{
    public class CigarilloDetailsViewModel : BaseEditViewModel
    {
        [Required]
        public string Filter { get; set; } = null!;

        public IEnumerable<FilterType> FilterTypes { get; set; } = new List<FilterType>();

        public IEnumerable<CigarilloReview> CigarilloReviews { get; set; } = new List<CigarilloReview>();

        public string AddReviewToCigarillo{ get; set; } = null!;
    }
}
