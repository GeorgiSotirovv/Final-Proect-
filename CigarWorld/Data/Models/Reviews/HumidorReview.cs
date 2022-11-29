using System.ComponentModel.DataAnnotations;

namespace CigarWorld.Data.Models.Reviews
{
    public class HumidorReview
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Review { get; set; } = null!;

        [Required]

        public int HumidorId { get; set; }
    }
}
