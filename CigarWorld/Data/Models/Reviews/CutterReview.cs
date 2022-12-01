using System.ComponentModel.DataAnnotations;

namespace CigarWorld.Data.Models.Reviews
{
    public class CutterReview
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Review { get; set; } = null!;

        [Required]

        public int CutterId { get; set; }

        [Required]
        public string Commenter { get; set; } = null!;
    }
}
