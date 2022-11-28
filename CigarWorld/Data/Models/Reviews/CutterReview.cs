using System.ComponentModel.DataAnnotations;

namespace CigarWorld.Data.Models.Reviews
{
    public class CutterReview
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Review { get; set; }

        [Required]

        public int CutterId { get; set; }
    }
}
