using CigarWorld.Data.Models.Reviews;
using System.ComponentModel.DataAnnotations;

namespace CigarWorld.Models.EditViewModels
{
    public class EditCigarPocketCaseViewModel : BaseEditViewModel
    {
        [Required]
        public string MaterialOfManufacture { get; set; } = null!;

        [Required]
        public int Capacity { get; set; }

        public IEnumerable<CigarPocketCaseReview> CigarPocketCaseReviews { get; set; } = new List<CigarPocketCaseReview>();
    }
}
