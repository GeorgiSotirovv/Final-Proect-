using CigarWorld.Data.Models;
using CigarWorld.Data.Models.Reviews;
using System.ComponentModel.DataAnnotations;
using static CigarWorld.Data.DataConstants.Ashtray;

namespace CigarWorld.Models.DetailsModels
{
    public class AshtrayDetailsViewModel : BaseEditViewModel
    {
        public string Type { get; set; } = null!;

        public IEnumerable<AshtrayType> AshtrayTypes { get; set; } = new List<AshtrayType>();

        public IEnumerable<AshtrayReview> AshtrayReviews { get; set; } = new List<AshtrayReview>();

        public string AddReviewToAshtray { get; set; } = null!;
    }
}

