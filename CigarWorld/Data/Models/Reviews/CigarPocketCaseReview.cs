using System.ComponentModel.DataAnnotations;

namespace CigarWorld.Data.Models.Reviews
{
    public class CigarPocketCaseReview
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Review { get; set; } = null!;

        [Required]
        public int CigarPocketCaseId { get; set; }
    }
}
